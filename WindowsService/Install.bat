C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe %~dp0WindowsService.exe
Net Start Service1
sc config Service1 start= auto
pause