<div align="center">

![Zeats](https://zeatsbalancaautomatica.blob.core.windows.net/icons/nuget.png)

</div>

# zeats-legacy-serial-port

Extensions to solve common problems when working with SerialPort

[![Build Status](https://dev.azure.com/zeats/Legacy/_apis/build/status/zeats-legacy-serial-port?branchName=master)](https://dev.azure.com/zeats/Legacy/_build/latest?definitionId=19&branchName=master)
[![NuGet](https://img.shields.io/nuget/v/Zeats.Legacy.SerialPort.svg)](https://www.nuget.org/packages/Zeats.Legacy.SerialPort)

## Installation

```PM>
Install-Package Zeats.Legacy.SerialPort
```

## Extensions

### SerialPortManager.Get(string portName)
Get a SerialPort
```c#
SerialPortManager.Get("COM1") /* return SerialPort COM1 */
SerialPortManager.Get("COM2") /* return SerialPort COM2 */
```
---

### SerialPortManager.Open(OpenPortCommand command)
Open connection with serial port
```c#

public class OpenPortCommand
{
    public string PortName { get; set; }
    public Parity Parity { get; set; }
    public int BaudRate { get; set; }
    public int DataBits { get; set; }
    public StopBits StopBits { get; set; }
}

SerialPortManager.Open(command) /* return SerialPort */
```
---

### SerialPortManager.Close(string portName)
Close the connection with serial port
```c#
SerialPortManager.Close("COM1")
```
---

### SerialPortManager.Write(string portName, string message)
Write a message in a serial port
```c#
SerialPortManager.Write("COM1", "SAMPLE-MESSAGE")
SerialPortManager.Write("COM1", Convert.ToChar(5).ToString(CultureInfo.InvariantCulture))
```
---

### SerialPortManager.ReadExisting(string portName, string message)
Get a message from a serial port
```c#
SerialPortManager.ReadExisting("COM1") /* return string */
```
---