$nodePath = (where node).Path
if (-not $nodePath) {
    Write-Host "Installing Node.js..."
    Invoke-WebRequest -Uri https://nodejs.org/dist/v18.13.0/node-v18.13.0-x64.msi -OutFile nodejs.msi
    Start-Process msiexec.exe -ArgumentList "/i nodejs.msi /quiet", "/log nodejs-install.log" -Wait
    Remove-Item -Path nodejs.msi
}
elseif (-not (Test-Path $nodePath)) {
    Write-Host "Installing Node.js..."
    Invoke-WebRequest -Uri https://nodejs.org/dist/v18.13.0/node-v18.13.0-x64.msi -OutFile nodejs.msi
    Start-Process msiexec.exe -ArgumentList "/i nodejs.msi /quiet", "/log nodejs-install.log" -Wait
    Remove-Item -Path nodejs.msi
}


$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Definition

cd "$scriptPath\isa-front"

npm install webpack-dev-server@latest --save-dev

npm install

npm start
