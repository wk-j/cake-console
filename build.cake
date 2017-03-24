#l "Tasks/Clean.cake"

Task("Restore").Does(() => {
    var solutions = GetFiles("./**/*.sln");
    foreach(var sol in solutions)
    {
        Information("Restoring {0}", sol);
        NuGetRestore(sol);
    }
});

Task("Build").Does(() => {
    DotNetBuild("CakeConsole.sln");
});

var target = Argument("target", "default");
RunTarget(target);