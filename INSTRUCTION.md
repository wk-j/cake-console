## Instruction

```
chmod +x /usr/lib/node_modules/cake-console/Source/CakeConsole.Core/Dist/Linux/CakeConsole.Core

npm link
npm unlink

dotnet publish -c release -r win10-x64          Source/CakeConsole.Core/CakeConsole.Core.fsproj --output Dist/Windows
dotnet publish -c release -r osx.10.10-x64      Source/CakeConsole.Core/CakeConsole.Core.fsproj --output Dist/MacOS
dotnet publish -c release -r ubuntu.14.04-x64   Source/CakeConsole.Core/CakeConsole.Core.fsproj --output Dist/Linux
```