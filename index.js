#!/usr/bin/env node

var spawn = require('child_process').spawn;
var process = require("process");

var file = __dirname + "/CakeConsole/bin/Debug/CakeConsole.exe";

if(process.platform === "win32") {
    spawn(file, [], { stdio: "inherit"});
} else {
    spawn("mono", [file] , {stdio: "inherit"});
}