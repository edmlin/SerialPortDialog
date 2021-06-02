# SerialPortDialog
A WPF serial port configuration dialog.  
![](https://github.com/edmlin/SerialPortDialog/raw/master/screenshot.jpg)
## Usage
```C#
var port = new System.IO.Ports.SerialPort("COM1", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
var diag = new SerialPortDialog.SerialPortDialog();
diag.GetSerialPortSettings(port);
diag.ShowDialog();
if(diag.DialogResult==true)
{
    diag.SetSerialPort(port);
}
```
