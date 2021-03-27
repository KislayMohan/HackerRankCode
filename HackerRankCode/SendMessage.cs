using System.IO.Ports;
using System.Threading;

namespace HackerRankCode
{
    public class SendMessage
    {
        /*
        private SerialPort SMSPort;
        private Thread SMSThread;
        private Thread ReadThread;
        public static bool _Continue = false;
        public static bool _ContSMS = false;
        private bool _Wait = false;
        public static bool _ReadPort = false;
        public delegate void SendingEventHandler(bool Done);
        public event SendingEventHandler Sending;
        public delegate void DataReceivedEventHandler(string Message);
        public event DataReceivedEventHandler DataReceived;

        public SendMessage(ref string COMMPORT)
        {
            SMSPort = new SerialPort();
            SMSPort.PortName = COMMPORT;
            SMSPort.BaudRate = 9600;
            SMSPort.Parity = Parity.None;
            SMSPort.DataBits = 8;
            SMSPort.StopBits = StopBits.One;
            SMSPort.Handshake = Handshake.RequestToSend;
            SMSPort.DtrEnable = true;
            SMSPort.RtsEnable = true;
            SMSPort.NewLine = System.Environment.NewLine;
            ReadThread = new Thread(
                new ThreadStart(ReadPort));
        }

        public bool SendSMS(string CellNumber, string SMSMessage)
        {
            string MyMessage = null;
            //Check if Message Length <= 160
            if (SMSMessage.Length <= 160)
                MyMessage = SMSMessage;
            else
                MyMessage = SMSMessage.Substring(0, 160);
            if (IsOpen == true)
            {
                SMSPort.WriteLine("AT+CMGS=" + CellNumber + "r");
                _ContSMS = false;
                SMSPort.WriteLine(MyMessage + System.Environment.NewLine + (char)(26));
                _Continue = false;
                Sending?.Invoke(false);
            }
            return false;
        }

        private void ReadPort()
        {
            string SerialIn = null;
            byte[] RXBuffer = new byte[SMSPort.ReadBufferSize + 1];
            while (SMSPort.IsOpen == true)
            {
                if ((SMSPort.BytesToRead != 0) & (SMSPort.IsOpen == true))
                {
                    while (SMSPort.BytesToRead != 0)
                    {
                        SMSPort.Read(RXBuffer, 0, SMSPort.ReadBufferSize);
                        SerialIn =
                            SerialIn + System.Text.Encoding.ASCII.GetString(
                            RXBuffer);
                        if (SerialIn.Contains(">") == true)
                        {
                            _ContSMS = true;
                        }
                        if (SerialIn.Contains("+CMGS:") == true)
                        {
                            _Continue = true;
                            Sending?.Invoke(true);
                            _Wait = false;
                            SerialIn = string.Empty;
                            RXBuffer = new byte[SMSPort.ReadBufferSize + 1];
                        }
                    }
                    DataReceived?.Invoke(SerialIn);
                    SerialIn = string.Empty;
                    RXBuffer = new byte[SMSPort.ReadBufferSize + 1];
                }
            }
        }

        public void Open()
        {
            if (IsOpen == false)
            {
                SMSPort.Open();
                ReadThread.Start();
            }
        }

        public void Close()
        {
            if (IsOpen == true)
            {
                SMSPort.Close();
            }
        }
        */
    }
}
