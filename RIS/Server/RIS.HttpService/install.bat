%windir%\Microsoft.NET\Framework\v4.0.30319\installutil .\RIS.HttpService.exe
net start "RIS.HttpService" 

ping 127.0.0.1 -t