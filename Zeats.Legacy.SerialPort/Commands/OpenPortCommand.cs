using System.IO.Ports;

namespace Zeats.Legacy.SerialPort.Commands
{
    public class OpenPortCommand
    {
        public string PortName { get; set; }
        public Parity Parity { get; set; }
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public StopBits StopBits { get; set; }
    }
}