var target = Argument("target", "Default");

if (TeamCity.IsRunningOnTeamCity) {
    target = "UnitTest";
}

var configuration = Argument("configuration", "Release");

var projectName = "SiegeApi";

var baseDirectory = MakeAbsolute(Directory("."));

var buildDirectory = baseDirectory + "/build";
var outputDirectory = buildDirectory + "/output";
var packageDirectory = baseDirectory + "/packages";

var solutionFile = String.Format("{0}/{1}.sln", baseDirectory, projectName);

IEnumerable<string> stdout;
StartProcess ("git", new ProcessSettings {
    Arguments = "describe --tags --abbrev=0",
    RedirectStandardOutput = true,
}, out stdout);
List<String> result = new List<string>(stdout);

var version = "0.0.0";
if (result.Count > 0) {
    version = result[0];
}

Task("Default")
    .IsDependentOn("Compile");

Task("Clean")
    .Does(() =>
    {
        CleanDirectories(buildDirectory);
    });

Task("Init")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        CreateDirectory(buildDirectory);
        CreateDirectory(outputDirectory);
        CreateDirectory(outputDirectory + "/bin");
    });

Task("Version")
    .IsDependentOn("Init")
    .Does(() =>
    {
        Information("MARKING THIS BUILD AS VERSION " + version);

        
        CreateAssemblyInfo(buildDirectory + "/CommonAssemblyInfo.cs", new AssemblyInfoSettings {
            Version = version,
            FileVersion = version,
            InformationalVersion = version,
            Copyright = String.Format("(c) Julian Easterling {0}", DateTime.Now.Year),
            Company = String.Empty,
            Configuration = configuration
        });
    });

Task("PackageClean")
    .Does(() =>
    {
        CleanDirectories(packageDirectory);
    });

Task("PackageRestore")
    .IsDependentOn("Init")
    .Does(() =>
    {
        DotNetCoreRestore(solutionFile);

        // In a CI environment, there really isn't any value to the packages' PDB files and it confuses the code coverage task
        var files = GetFiles(packageDirectory + "/**/*.pdb");
        DeleteFiles(files);
    });

Task("Compile")
    .IsDependentOn("PackageRestore")
    .IsDependentOn("Version")
    .Does(() =>
    {
        StartProcess ("dotnet", new ProcessSettings {
            Arguments = "publish --output " + outputDirectory + " --configuration Release -v n" 
        });
    });

Task("Test")
    .IsDependentOn("UnitTest");

Task("UnitTest")
    .IsDependentOn("Compile")
    .Does(() =>
    {
    DotNetCoreTest(
        baseDirectory + "/UnitTests/UnitTests.csproj",
        new DotNetCoreTestSettings() 
        {
            Configuration = configuration,
            NoBuild = true
        });
    });

Task("Package")
    .IsDependentOn("Test")
    .Does(() =>
    {
        var nuGetPackSettings = new NuGetPackSettings {
            Version = version,
            OutputDirectory = buildDirectory
        };

        var nuspecFiles = GetFiles(baseDirectory + "\\*.nuspec");

        NuGetPack(nuspecFiles, nuGetPackSettings);
    });

RunTarget(target);
