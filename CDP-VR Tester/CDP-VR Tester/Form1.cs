﻿using System;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;

namespace CDP_VR_Tester
{
    public partial class Form1 : Form
    {
        private bool m_RunReadThread;
        private IntPtr m_hSocket;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            connectBluetooth();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectBluetooth();
        }

        private void btnDarkness_Click(object sender, EventArgs e)
        {

        }

        private void btnSeethrough_Click(object sender, EventArgs e)
        {

        }

        private void btnFreezePitch_Click(object sender, EventArgs e)
        {

        }

        private void btnSetPitch_Click(object sender, EventArgs e)
        {

        }

        private void btnSetScene_Click(object sender, EventArgs e)
        {

        }

        /*
         * BluetoothReadThread函数用于接收蓝牙设备发送的数据
         * recv函数用于接收数据      
         */
        private void BluetoothReadThread()
        {

        }

        [DllImport("ws2_32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern Int32 WSAStartup(Int16 wVersionRequested, out WSAData wsaData);

        [DllImport("ws2_32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern Int32 WSACleanup();

        [DllImport("ws2_32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int WSALookupServiceBegin(byte[] pQuerySet, LookupFlags dwFlags, out IntPtr lphLookup);

        [DllImport("ws2_32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int WSALookupServiceNext(IntPtr hLookup, LookupFlags dwFlags, ref int lpdwBufferLength, byte[] pResults);

        [DllImport("ws2_32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int WSALookupServiceEnd(IntPtr hLookup);

        [DllImport("ws2_32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr socket(int af, int socket_type, int protocol);

        [DllImport("ws2_32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int closesocket(IntPtr s);

        [DllImport("Ws2_32.dll")]
        private static extern int connect(IntPtr s, ref SOCKADDR_BTH addr, int addrsize);

        [DllImport("ws2_32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern Int32 WSAGetLastError();

        [DllImport("Ws2_32.dll")]
        private static extern int setsockopt(IntPtr s, int level, int optname, ref int optval, int optlen);

        [DllImport("Ws2_32.dll")]
        private static extern int recv(IntPtr s, IntPtr buf, int len, System.Net.Sockets.SocketFlags flags);

        [DllImport("Ws2_32.dll")]
        private static extern int send(IntPtr s, IntPtr buf, int len, System.Net.Sockets.SocketFlags flags);

        /*
         * LookupFlags枚举用于存放查找标志
         */
        [Flags()]
        private enum LookupFlags : uint
        {
            Containers = 0x0002,
            ReturnName = 0x0010,
            ReturnAddr = 0x0100,
            ReturnBlob = 0x0200,
            FlushCache = 0x1000,
            ResService = 0x8000,
        }

        /*
         * SockProtocols枚举用于存放蓝牙协议的值
         */
        [Flags()]
        private enum SockProtocols : short
        {
            L2CAP = 0x0100,
            RFCOMM = 0x0003,
            BTHPROTO_RFCOMM = 0x0003,
            SDP = 0x0001,
        }

        /*
         * WSAData结构体用于存放Winsock库的信息
         */
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct WSAData
        {
            public Int16 wVersion;
            public Int16 wHighVersion;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 257)]
            public String szDescription;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
            public String szSystemStatus;

            public Int16 iMaxSockets;
            public Int16 iMaxUdpDg;
            public IntPtr lpVendorInfo;
        }

        /*
         * GUID结构体用于存放GUID
         */
        [StructLayout(LayoutKind.Sequential)]
        private struct GUID
        {
            public int a;
            public short b;
            public short c;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] d;
        }

        /*
         * SOCKADDR_BTH结构体用于存放蓝牙设备的地址
         */
        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        private struct SOCKADDR_BTH
        {
            public ushort addressFamily; //地址族
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] btAddr; //蓝牙地址
            public GUID guid; //GUID
            public int port; //端口
            public short dummy; //保留
        }

        /*
         * WSAQUERYSET结构体用于存放蓝牙设备的信息
         */
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct WSAQUERYSET
        {
            public Int32 dwSize;
            public IntPtr szServiceInstanceName;
            public IntPtr lpServiceClassId;
            public IntPtr lpVersion;
            public IntPtr lpszComment;
            public Int32 dwNameSpace;
            public IntPtr lpNSProviderId;
            public IntPtr lpszContext;
            public Int32 dwNumberOfProtocols;
            public IntPtr lpafpProtocols;
            public IntPtr lpszQueryString;
            public Int32 dwNumberOfCsAddrs;
            public IntPtr lpcsaBuffer;
            public Int32 dwOutputFlags;
            public IntPtr Blob;
        }

        /*
         * SOCKET_ADDRESS结构体用于存放蓝牙设备的地址
         */
        [StructLayout(LayoutKind.Sequential)]
        private struct SOCKET_ADDRESS
        {
            public IntPtr lpSockaddr;
            public Int32 iSockaddrLength;
        }

        /*
         * CSADDR_INFO结构体用于存放蓝牙设备的信息
         * SOCKADDR_BTH结构体用于存放蓝牙设备的地址
         */
        [StructLayout(LayoutKind.Sequential)]
        private struct CSADDR_INFO
        {
            internal SOCKET_ADDRESS LocalAddr;
            internal SOCKET_ADDRESS RemoteAddr;
            internal Int32 iSocketType;
            internal SockProtocols iProtocol;
        }

        /*
         * FindBtAddress函数用于查找特定名称的蓝牙设备的地址
         * WSALookupServiceBegin函数用于开始查找蓝牙设备
         * WSALookupServiceNext函数用于查找下一个蓝牙设备的信息
         * WSALookupServiceEnd函数用于结束查找蓝牙设备
         */
        private SOCKADDR_BTH FindBtAddress(string devicename)
        {
            SOCKADDR_BTH sOCKADDR_BTH = new SOCKADDR_BTH(); //定义一个SOCKADDR_BTH结构体
            LookupFlags lookupFlags = LookupFlags.ReturnAddr | LookupFlags.ReturnName | LookupFlags.ReturnAddr; //定义查找标志
            WSAQUERYSET wSAQUERYSET = new WSAQUERYSET(); //定义一个WSAQUERYSET结构体

            int wSAQUERYSETSize = Marshal.SizeOf(wSAQUERYSET); //获取WSAQUERYSET结构体的大小
            wSAQUERYSET.dwSize = wSAQUERYSETSize; //设置WSAQUERYSET结构体的大小
            wSAQUERYSET.dwNameSpace = 16; //设置WSAQUERYSET结构体的dwNameSpace成员的值为16，表示蓝牙服务

            byte[] wSAQUERYSETBuff = new byte[wSAQUERYSETSize]; //定义一个字节数组，用于存放WSAQUERYSET结构体的数据
            IntPtr wSAQUERYSETBuffPtr = Marshal.AllocHGlobal(wSAQUERYSETSize); //分配内存，用于存放WSAQUERYSET结构体的数据
            Marshal.StructureToPtr(wSAQUERYSET, wSAQUERYSETBuffPtr, false); //将WSAQUERYSET结构体的数据拷贝到wSAQUERYSETBuffPtr指向的内存中
            Marshal.Copy(wSAQUERYSETBuffPtr, wSAQUERYSETBuff, 0, wSAQUERYSETSize); //将wSAQUERYSETBuffPtr指向的内存中的数据拷贝到wSAQUERYSETBuff数组中
            Marshal.FreeHGlobal(wSAQUERYSETBuffPtr); //释放wSAQUERYSETBuffPtr指向的内存

            IntPtr intPtr = IntPtr.Zero; //定义一个IntPtr类型的变量，用于存放查找到的蓝牙设备的信息

            int result = WSALookupServiceBegin(wSAQUERYSETBuff, lookupFlags, out intPtr); //开始查找蓝牙设备
            if (intPtr == IntPtr.Zero || result != 0) //如果没有查找到蓝牙设备或者查找失败
            {
                return sOCKADDR_BTH; //返回一个SOCKADDR_BTH结构体，其成员的值均为0
            }

            int buffsize = 1024; //定义一个整型变量，用于存放查找到的蓝牙设备的信息的大小
            byte[] buffer = new byte[buffsize]; //定义一个字节数组，用于存放查找到的蓝牙设备的信息
            bool bCont = true; //定义一个bool类型的变量，用于指示是否查找到了蓝牙设备

            while (bCont)
            {
                result = WSALookupServiceNext(intPtr, lookupFlags, ref buffsize, buffer);
                if (result == 0) //如果查找成功
                {
                    wSAQUERYSETBuffPtr = Marshal.AllocHGlobal(wSAQUERYSETSize); //分配内存，用于存放查找到的蓝牙设备的信息
                    Marshal.Copy(buffer, 0, wSAQUERYSETBuffPtr, wSAQUERYSETSize); //将buffer数组中的数据拷贝到wSAQUERYSETBuffPtr指向的内存中
                    wSAQUERYSET = (WSAQUERYSET)Marshal.PtrToStructure(wSAQUERYSETBuffPtr, wSAQUERYSET.GetType()); //将wSAQUERYSETBuffPtr指向的内存中的数据转换为WSAQUERYSET结构体
                    string str = Marshal.PtrToStringUni(wSAQUERYSET.szServiceInstanceName); //将wSAQUERYSET.szServiceInstanceName指向的内存中的数据转换为字符串

                    if (str == devicename)
                    {
                        bCont = false; //设置bCont变量的值为false，表示查找到了蓝牙设备
                        CSADDR_INFO csai = new CSADDR_INFO(); //定义一个CSADDR_INFO结构体
                        csai = (CSADDR_INFO)Marshal.PtrToStructure(wSAQUERYSET.lpcsaBuffer, csai.GetType()); //将wSAQUERYSET.lpcsaBuffer指向的内存中的数据转换为CSADDR_INFO结构体
                        sOCKADDR_BTH = (SOCKADDR_BTH)Marshal.PtrToStructure(wSAQUERYSET.lpcsaBuffer, sOCKADDR_BTH.GetType()); //将wSAQUERYSET.lpcsaBuffer指向的内存中的数据转换为SOCKADDR_BTH结构体
                    }
                    Marshal.FreeHGlobal(wSAQUERYSETBuffPtr); //释放intPtr2指向的内存
                }
                else //如果查找失败
                {
                    bCont = false; //设置bCont变量的值为false，表示没有查找到蓝牙设备
                }
            }

            WSALookupServiceEnd(intPtr); //结束查找蓝牙设备

            return sOCKADDR_BTH; //返回查找到的蓝牙设备的信息
        }

        private void DisconnectBluetooth()
        {
            m_RunReadThread = false; //设置m_RunReadThread变量的值为false
            if (m_hSocket == IntPtr.Zero) //如果m_hSocket变量的值为0
                return; //返回
            closesocket(m_hSocket); //关闭蓝牙套接字
            m_hSocket = IntPtr.Zero; //设置m_hSocket变量的值为0
            WSACleanup(); //清理Winsock库
        }

        /*
         * connectBluetooth函数用于连接蓝牙设备
         * socket函数用于创建一个蓝牙套接字
         * connect函数用于连接蓝牙设备
         * setsockopt函数用于设置超时时间
         * BluetoothReadThread函数用于接收蓝牙设备发送的数据                                               
         */
        private int connectBluetooth()
        {
            WSAData d; //定义一个WSAData结构体
            WSAStartup(0x202, out d); //初始化Winsock库

            SOCKADDR_BTH btaddress = FindBtAddress("CDP-VR"); //查找名称为CDP-VR的蓝牙设备的地址
            if (btaddress.btAddr == null) //如果没有查找到名称为CDP-VR的蓝牙设备
            {
                WSACleanup(); //清理Winsock库
                return -1; //返回-1，表示没有查找到名称为CDP-VR的蓝牙设备
            }

            int AF_BTH = 32; //定义一个整型变量，用于存放蓝牙地址族的值
            int BTHPROTO_RFCOMM = 3; //定义一个整型变量，用于存放蓝牙协议的值
            int SOCK_STREAM = 1; //定义一个整型变量，用于存放流式套接字的值

            m_hSocket = socket(AF_BTH, SOCK_STREAM, BTHPROTO_RFCOMM); //创建一个蓝牙套接字

            if (m_hSocket.ToInt32() == -1) //如果创建蓝牙套接字失败
            {
                WSACleanup(); //清理Winsock库
                return -2; //返回-2，表示创建蓝牙套接字失败
            }

            SOCKADDR_BTH btsockaddr = new SOCKADDR_BTH(); //定义一个SOCKADDR_BTH结构体
            Guid guid = new Guid("00001101-0000-1000-8000-00805F9B34FB"); //定义一个GUID结构体，用于存放蓝牙服务的GUID

            btsockaddr.addressFamily = (ushort)AF_BTH; //设置btsockaddr结构体的addressFamily成员的值为AF_BTH
            btsockaddr.btAddr = btaddress.btAddr; //设置btsockaddr结构体的btAddr成员的值为btaddress结构体的btAddr成员的值

            btsockaddr.guid.a = 0x1101; //设置btsockaddr结构体的guid成员的a成员的值为0x1101
            btsockaddr.guid.b = 0x0000; //设置btsockaddr结构体的guid成员的b成员的值为0x0000
            btsockaddr.guid.c = 0x1000; //设置btsockaddr结构体的guid成员的c成员的值为0x1000
            btsockaddr.guid.d = new byte[8]; //设置btsockaddr结构体的guid成员的d成员的值为{ 0x80, 0x00, 0x00, 0x80, 0x5F, 0x9B, 0x34, 0xFB }
            btsockaddr.guid.d[0] = 0x80; //设置btsockaddr结构体的guid成员的d成员的第一个元素的值为0x80
            btsockaddr.guid.d[1] = 0x00; //设置btsockaddr结构体的guid成员的d成员的第二个元素的值为0x00
            btsockaddr.guid.d[2] = 0x00; //设置btsockaddr结构体的guid成员的d成员的第三个元素的值为0x00
            btsockaddr.guid.d[3] = 0x80; //设置btsockaddr结构体的guid成员的d成员的第四个元素的值为0x80
            btsockaddr.guid.d[4] = 0x5F; //设置btsockaddr结构体的guid成员的d成员的第五个元素的值为0x5F
            btsockaddr.guid.d[5] = 0x9B; //设置btsockaddr结构体的guid成员的d成员的第六个元素的值为0x9B
            btsockaddr.guid.d[6] = 0x34; //设置btsockaddr结构体的guid成员的d成员的第七个元素的值为0x34
            btsockaddr.guid.d[7] = 0xFB; //设置btsockaddr结构体的guid成员的d成员的第八个元素的值为0xFB

            btsockaddr.port = 0; //设置btsockaddr结构体的port成员的值为0

            int size = Marshal.SizeOf(btsockaddr); //获取btsockaddr结构体的大小

            if (connect(m_hSocket, ref btsockaddr, size) == -1) //连接蓝牙设备
            {
                int error = WSAGetLastError(); //获取最后一次发生的错误
                WSACleanup(); //清理Winsock库
                m_hSocket = IntPtr.Zero; //设置m_hSocket变量的值为0

                return -3; //返回-3，表示连接蓝牙设备失败
            }

            int tio = 1000; //定义一个整型变量，用于存放超时时间
            if (setsockopt(m_hSocket, 0x0000ffff, 0x00001006, ref tio, 4) == -1) //设置超时时间
            {
                DisconnectBluetooth(); //断开蓝牙设备的连接

                return -4; //返回-4，表示设置超时时间失败
            }

            Thread thread = new Thread(new ThreadStart(BluetoothReadThread)); //定义一个线程，用于接收蓝牙设备发送的数据

            return 0;
        }
    }

}