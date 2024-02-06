using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using InTheHand.Net;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;

namespace CDP_VR_Tester
{
    public partial class Form1 : Form
    {
        private readonly byte CurMajorVersion = 1, CurMinorVersion = 0; //定义两个字节变量，用于存放当前主版本号和当前次版本号

        private bool alsend_darkness = false;
        private bool alsend_seethrough = false;
        private bool alsend_freezepitch = false;
        private bool alsend_pitchval = false;
        private bool alsend_sceneval = false;

        private const int TRANSFERREDBYTES = 4 * 2 + 1;

        private byte m_CurBattery, m_oldBattery; //定义两个字节变量，用于存放当前电量和上一次的电量
        private byte m_CurMajorVersion, m_oldMajorVersion, m_CurMinorVersion, m_oldMinorVersion; //定义四个字节变量，用于存放当前主版本号、上一次的主版本号、当前次版本号和上一次的次版本号
        
        private BluetoothClient bluetoothClient; //定义蓝牙客户端对象

        private BluetoothRadio bluetoothRadio; //定义蓝牙适配器对象

        private BluetoothDeviceInfo[] deviceList; // 存储搜索到的设备列表

        //Guid serialPortUUID = new Guid("00001101-0000-1000-8000-00805F9B34FB");
        //Guid mGUID = Guid.Parse("c1db6770-a359-11e6-80f5-76304dec7eb7");
        Guid mGUID = Guid.Parse("00001101-0000-1000-8000-00805F9B34FB");

        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            if (lb_devicelist.SelectedIndex >= 0 && deviceList != null && lb_devicelist.SelectedIndex < deviceList.Length)
            {
                try
                {
                    BluetoothDeviceInfo deviceToConnect = deviceList[lb_devicelist.SelectedIndex]; //获取要连接的蓝牙设备

                    bluetoothClient = new BluetoothClient(); //实例化蓝牙客户端对象
                    bluetoothClient.BeginConnect(deviceToConnect.DeviceAddress, mGUID, new AsyncCallback(ConnectCallback), bluetoothClient); //开始连接蓝牙设备
                    Btn_Disconnect.Enabled = true; //启用断开连接按钮
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"连接蓝牙设备过程中出错: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("请先选择要连接的蓝牙设备！");
            }
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                BluetoothClient bluetoothClient = (BluetoothClient)ar.AsyncState; //获取蓝牙客户端对象
                bluetoothClient.EndConnect(ar); //结束连接蓝牙设备
                MessageBox.Show("蓝牙设备连接成功！");

                //启动接收数据线程
                Thread readThread = new Thread(new ThreadStart(ReceiveData))
                {
                    IsBackground = true
                };
                readThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"连接蓝牙设备过程中出错: {ex.Message}");
            }
        }

        private void ReceiveData()
        {
            try 
            {
                byte[] buffer = new byte[TRANSFERREDBYTES]; // 定义一个字节数组，用于存放接收到的数据

                while (true)
                {
                    if (bluetoothClient != null && bluetoothClient.Connected)
                    {
                        int bytesRead = bluetoothClient.GetStream().Read(buffer, 0, TRANSFERREDBYTES); //接收数据
                        if (bytesRead > 0)
                        {
                            //处理接收到的数据
                            ProcessReceivedData(buffer, bytesRead);
                        }
                    }
                    else
                    {
                        // 适当处理连接丢失的情况
                        break;
                    }
                    Thread.Sleep(100); // 线程休眠100毫秒
                }
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"接收数据过程中出错: {ex.Message}");
                });
            }
        }

        private void ProcessReceivedData(byte[] buffer, int bytesRead)
        {

            // 确保接收到的数据至少有3个字节
            if (bytesRead >= 3)
            {
                // 解析接收到的数据
                m_CurBattery = buffer[0]; //获取当前电量
                m_CurMajorVersion = buffer[1]; //获取当前主版本号
                m_CurMinorVersion = buffer[2]; //获取当前次版本号

                //判断当前电量、当前主版本号和当前次版本号是否与上一次的电量、主版本号和次版本号相同
                //如果不相同，则更新界面
                if (m_CurBattery != m_oldBattery || m_CurMajorVersion != m_oldMajorVersion || m_CurMinorVersion != m_oldMinorVersion)
                {
                    // 使用 Invoke 在 UI 线程上更新 UI
                    this.Invoke((MethodInvoker)delegate
                    {
                        UpdateUI(m_CurBattery, m_CurMajorVersion, m_CurMinorVersion); //更新界面
                    });

                    // 更新上一次的电量、主版本号和次版本号
                    m_oldBattery = m_CurBattery; //将当前电量赋值给上一次的电量
                    m_oldMajorVersion = m_CurMajorVersion; //将当前主版本号赋值给上一次的主版本号
                    m_oldMinorVersion = m_CurMinorVersion; //将当前次版本号赋值给上一次的次版本号
                }
            }
        }

        /*
        private void ReadData()
        {
            try
            {
                byte[] buffer = new byte[TRANSFERREDBYTES]; //定义一个字节数组，用于存放接收到的数据
                int bytes = bluetoothClient.Client.Receive(buffer); //接收数据
                if (bytes > 0)
                {
                    //解析接收到的数据
                    m_CurBattery = buffer[0]; //获取当前电量
                    m_CurMajorVersion = buffer[1]; //获取当前主版本号
                    m_CurMinorVersion = buffer[2]; //获取当前次版本号
                    if (m_CurBattery != m_oldBattery || m_CurMajorVersion != m_oldMajorVersion || m_CurMinorVersion != m_oldMinorVersion)
                    {
                        UpdateUI(m_CurBattery, m_CurMajorVersion, m_CurMinorVersion); //更新界面
                        m_oldBattery = m_CurBattery; //将当前电量赋值给上一次的电量
                        m_oldMajorVersion = m_CurMajorVersion; //将当前主版本号赋值给上一次的主版本号
                        m_oldMinorVersion = m_CurMinorVersion; //将当前次版本号赋值给上一次的次版本号
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"接收数据过程中出错: {ex.Message}");
            }
        }
        */

        private void UpdateUI(int batteryLevel, int majorVersion, int minorVersion) 
        {
            // 更新电量
            if (pbBattery.InvokeRequired)
            {
                pbBattery.Invoke(new Action(() => pbBattery.Value = batteryLevel));
            }
            else
            {
                pbBattery.Value = batteryLevel;
            }
            // 更新版本号
            string version = $"{majorVersion}.{minorVersion}";
            if (tbVersion.InvokeRequired)
            {
                tbVersion.Invoke(new Action(() => tbVersion.Text = version));
            }
            else
            {
                tbVersion.Text = version;
            }
        }

        private void Btn_Disconnect_Click(object sender, EventArgs e)
        {
            bluetoothRadio.Mode = RadioMode.PowerOff; //关闭蓝牙适配器

            if (bluetoothClient != null && bluetoothClient.Connected) //判断蓝牙设备是否已连接
            {
                try
                {
                    bluetoothClient.Close();
                    bluetoothClient.Dispose();
                    MessageBox.Show("蓝牙设备已断开连接！");
                    Btn_Disconnect.Enabled = false; // 禁用断开连接按钮
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"断开蓝牙设备连接过程中出错: {ex.Message}");
                }
            }
            else  //蓝牙设备未连接
            {
                MessageBox.Show("蓝牙设备未连接！");
                Btn_Disconnect.Enabled = false; // 禁用断开连接按钮
            }
        }

        private void Btn_Darkness_Click(object sender, EventArgs e)
        {
            alsend_darkness = true; //设置alsend_darkness变量的值为true
            BluetoothSendData(); //发送数据
        }

        private void Btn_Seethrough_Click(object sender, EventArgs e)
        {
            alsend_seethrough = true; //设置alsend_seethrough变量的值为true
            BluetoothSendData(); //发送数据
        }

        private void Btn_FreezePitch_Click(object sender, EventArgs e)
        {
            alsend_freezepitch = true; //设置alsend_freezepitch变量的值为true
            BluetoothSendData(); //发送数据
        }

        private void Btn_SetPitch_Click(object sender, EventArgs e)
        {
            alsend_pitchval = true; //设置alsend_pitchval变量的值为true
            BluetoothSendData(); //发送数据
        }

        private void Btn_SetScene_Click(object sender, EventArgs e)
        {
            alsend_sceneval = true; //设置alsend_sceneval变量的值为true
            BluetoothSendData(); //发送数据
        }

        private void Cb_bluetooth_CheckedChanged(object sender, EventArgs e)
        {
            if (Cb_bluetooth.Checked)
            {
                //启动蓝牙功能
                StartBluetooth();
            }
            else
            {
                //关闭蓝牙功能
                StopBluetooth();
            }
        }

        private void StartBluetooth()
        {
            try 
            {
                //检查蓝牙适配器是否可用
                if (!BluetoothRadio.IsSupported)
                {
                    MessageBox.Show("当前电脑没有蓝牙适配器或蓝牙适配器不可用！");
                    return;
                }

                //获取本地蓝牙适配器
                bluetoothRadio = BluetoothRadio.PrimaryRadio;

                if (bluetoothRadio == null)
                {
                    MessageBox.Show("当前电脑没有蓝牙适配器或蓝牙适配器不可用！");
                    return;
                }

                //确保蓝牙适配器是开启的
                if (bluetoothRadio.Mode != RadioMode.Discoverable)
                {
                    bluetoothRadio.Mode = RadioMode.Discoverable;
                }

                /*
                //开始搜索附近的蓝牙设备、
                bluetoothClient.BeginDiscoverDevices(255, true, true, true, false, null, null);
                MessageBox.Show("开始搜索附近的蓝牙设备！");
                */
            }

            catch (Exception ex)
            {
                MessageBox.Show($"启动蓝牙过程中出错: {ex.Message}");
            }

            MessageBox.Show("蓝牙功能已启动！");
        }

        private void StopBluetooth()
        {
            //关闭蓝牙功能
            BluetoothRadio.PrimaryRadio.Mode = RadioMode.PowerOff;

            if (bluetoothClient != null && bluetoothClient.Connected)
            {
                bluetoothClient.Close();
                bluetoothClient.Dispose();
            }

            MessageBox.Show("蓝牙功能已关闭！");
        }

        /*
         * 查找蓝牙设备
         */
        private void Btn_FindDevice_Click(object sender, EventArgs e)
        {
            //检查蓝牙适配器是否可用
            if (Cb_bluetooth.Checked)
            {
                lb_devicelist.Items.Clear(); //清空列表框中的内容
                try
                {
                    BluetoothClient client = new BluetoothClient(); //实例化蓝牙客户端对象
                    deviceList = client.DiscoverDevices(); //获取附近的蓝牙设备

                    if (deviceList.Length == 0) //判断是否搜索到蓝牙设备
                    {
                        MessageBox.Show("未搜索到蓝牙设备！");
                        return;
                    }

                    foreach (BluetoothDeviceInfo device in deviceList)
                    {
                        lb_devicelist.Items.Add(device.DeviceName); //将蓝牙设备的名称添加到列表框中
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"搜索蓝牙设备过程中出错: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("请先启动蓝牙功能！");
            }
        }

        private void BluetoothSendData() 
        {
            byte[] buffer = new byte[TRANSFERREDBYTES]; //定义一个字节数组，用于存放要发送的数据

            buffer[0] = CurMajorVersion; //将当前主版本号赋值给buffer[0]
            buffer[1] = CurMinorVersion; //将当前次版本号赋值给buffer[1]

            buffer[2] = alsend_seethrough ? (byte)0x80 : (byte)0x00; //如果alsend_seethrough变量的值为true，则将buffer数组的第三个元素的值设置为0x80，否则设置为0x00
            buffer[3] = alsend_darkness ? (byte)0x80 : (byte)0x00; //如果alsend_darkness变量的值为true，则将buffer数组的第四个元素的值设置为0x80，否则设置为0x00
            buffer[4] = alsend_freezepitch ? (byte)0x80 : (byte)0x00; //如果alsend_freezepitch变量的值为true，则将buffer数组的第五个元素的值设置为0x80，否则设置为0x00
            buffer[5] = alsend_pitchval ? (byte)tb_pitch.Value : (byte)0x80; //如果alsend_pitchval变量的值为true，则将buffer数组的第六个元素的值设置为tb_pitch滑动条的值，否则设置为0x80
            buffer[6] = alsend_sceneval ? (byte)tb_scene.Value : (byte)0x80; //如果alsend_sceneval变量的值为true，则将buffer数组的第七个元素的值设置为tb_scene滑动条的值，否则设置为0x80

            // 第八和九字节保留
            buffer[7] = 0x00;
            buffer[8] = 0x00;

            try 
            {
                if (bluetoothClient != null && bluetoothClient.Connected) //判断蓝牙设备是否已连接
                {
                    bluetoothClient.GetStream().Write(buffer, 0, TRANSFERREDBYTES); //发送数据
                    MessageBox.Show("数据发送成功！");
                    
                }
                else //蓝牙设备未连接
                {
                    MessageBox.Show("蓝牙设备未连接！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发送数据过程中出错: {ex.Message}");
            }

            // 重置发送标志位
            alsend_seethrough = false; //设置alsend_seethrough变量的值为false
            alsend_darkness = false; //设置alsend_darkness变量的值为false
            alsend_freezepitch = false; //设置alsend_freezepitch变量的值为false
            alsend_pitchval = false; //设置alsend_pitchval变量的值为false
            alsend_sceneval = false; //设置alsend_sceneval变量的值为false
        }
    }
}

