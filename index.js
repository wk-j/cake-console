#!/usr/bin/env node

var spawn = require('child_process').spawn;

function getPath() {
	if(process.platform === "win32") {
		return __dirname + "/Source/CakeConsole.Core/Dist/Windows/CakeConsole.Core.exe";
	}
	else if(process.platform === "darwin") {
		return __dirname + "/Source/CakeConsole.Core/Dist/MacOS/CakeConsole.Core";
	} 
	else {
		return __dirname + "/Source/CakeConsole.Core/Dist/Linux/CakeConsole.Core";
	}
}

var path = getPath();
spawn(path, [], { stdio: "inherit"});