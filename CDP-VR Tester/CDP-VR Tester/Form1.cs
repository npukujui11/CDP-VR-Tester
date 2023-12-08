using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using InTheHand.Net;
using System.Threading;

namespace CDP_VR_Tester
{
    public partial class Form1 : Form
    {
        private BluetoothClient bluetoothClient;
        private BluetoothDeviceInfo vrDevice;
        private readonly Guid serviceGuid = new Guid("00001101-0000-1000-8000-00805F9B34FB");
        public Form1()
        {
            InitializeComponent();
            bluetoothClient = new BluetoothClient();
        }

        private byte[] BuildCommandPacket(bool requestVersion, bool setSeethrough, bool setDarkness, bool setFreezePitch, bool setPitch, bool requestBattery, int scene, int pitch)
        {
            byte[] packet = new byte[3];
            packet[0] = 0;
            packet[1] = 0;
            packet[2] = 0;

            // 第 1 位：请求软件版本号
            if (requestVersion) packet[0] |= 0x80;

            // 第 9 位：设置 Seethrough 模式
            if (setSeethrough) packet[0] |= 0x01;

            // 第 10 位：设置 Darkness 模式
            if (setDarkness) packet[1] |= 0x80;

            // 第 11 位：设置 Freeze Pitch 模式
            if (setFreezePitch) packet[1] |= 0x40;

            // 第 12 位：设置 Set Pitch 模式
            if (setPitch) packet[1] |= 0x20;

            // 第 13 位：请求电池电量
            if (requestBattery) packet[1] |= 0x10;

            // 第 14-15 位：设置 VR 场景
            if (scene >= 0 && scene <= 3) packet[1] |= (byte)(scene << 4);

            // 第 16-21 位：设置 Pitch 值, -10-10
            if (pitch >= -10 && pitch <= 10) packet[1] |= (byte)(pitch + 10);

            return packet;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // 这里需要替换为 VR 眼镜的真实蓝牙地址
                BluetoothAddress vrDeviceAddress = BluetoothAddress.Parse("VR_DEVICE_BLUETOOTH_ADDRESS");
                vrDevice = new BluetoothDeviceInfo(vrDeviceAddress);

                bluetoothClient.BeginConnect(vrDevice.DeviceAddress, serviceGuid, new AsyncCallback(ConnectCallback), bluetoothClient);

                btnConnect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bluetooth connection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnConnect.Enabled = true;
            }
        }

        private void ConnectCallback(IAsyncResult result)
        {
            try
            {
                bluetoothClient.EndConnect(result);

                // 连接成功，可以发送命令到 VR 眼镜
                this.Invoke((MethodInvoker)delegate
                {
                    richTextBox1.AppendText("Bluetooth connection was successful.\n"); // 在富文本richTextBox1中返回“连接成功”的文本
                    btnDisconnect.Enabled = true; // 连接成功，可以断开连接
                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"Bluetooth connection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnConnect.Enabled = true; // 连接失败，可以再次尝试连接
                    btnDisconnect.Enabled = false; // 连接失败，不允许断开连接
                });
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (bluetoothClient.Connected)
            {
                bluetoothClient.Close();

                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false; // 连接断开，不允许再次断开连接
                richTextBox1.AppendText("The Bluetooth connection is already cancelled.\n"); // 在富文本richTextBox1中返回“连接已断开”的文本
            }
        }

        private void btnDarkness_Click(object sender, EventArgs e)
        {
            if (bluetoothClient.Connected)
            {
                byte[] command = BuildCommandPacket(false, false, true, false, false, false, 0, 0);
                bluetoothClient.GetStream().Write(command, 0, command.Length);
            }
        }

        private void btnSeethrough_Click(object sender, EventArgs e)
        {
            if (bluetoothClient.Connected)
            {
                byte[] command = BuildCommandPacket(false, true, false, false, false, false, 0, 0);
                bluetoothClient.GetStream().Write(command, 0, command.Length);
            }
        }
    }
}
