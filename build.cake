#l "Tasks/Clean.cake"

Task("Build").Does(() => {
    DotNetBuild("CakeConsole.sln");
});

var target = Argument("target", "default");
RunTarget(target);