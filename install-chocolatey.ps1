if (!([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator")) { Start-Process powershell.exe "-NoProfile -ExecutionPolicy Bypass -File `"$PSCommandPath`"" -Verb RunAs; exit }

Write-Host 'Chocolatey will be instaled';
Write-Host -NoNewLine 'Press any key to continue...';
$null = $Host.UI.RawUI.ReadKey('NoEcho,IncludeKeyDown');

iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))

Write-Host 'Nodejs will be installed';
Write-Host -NoNewLine 'Press any key to continue...';
$null = $Host.UI.RawUI.ReadKey('NoEcho,IncludeKeyDown');

iex 'choco install nodejs'
iex 'refreshenv'
Write-Host 'Nodejs installed';
Write-Host 'NPM packages will be installed now';
Write-Host -NoNewLine 'Press any key to continue...';
$null = $Host.UI.RawUI.ReadKey('NoEcho,IncludeKeyDown');

$s = 'pushd ' + $PSScriptRoot;
iex $s;
iex 'cd Front'
iex 'npm install -g gulp'
iex 'npm install -g jspm'
iex 'npm run install-deps'

Write-Host 'Front-end packages installed';
Write-Host -NoNewLine 'Press any key to continue...';
$null = $Host.UI.RawUI.ReadKey('NoEcho,IncludeKeyDown');