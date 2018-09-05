%windir%\Microsoft.NET\Framework\v4.0.30319\installutil .\RIS.TCPService.exe
net start "RIS.TCPService" 

ping 127.0.0.1 -t