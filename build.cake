#tool "nuget:?package=xunit.runner.console"

var target = Argument("target", "Default");
var solution = File("./PredictiveModelling.sln");

Task("Default")
	.IsDependentOn("xUnit");

Task("Build")
	.Does(() => {
		DotNetBuild(solution);
	});

Task("xUnit")
	.IsDependentOn("Build")
	.Does(() => {
		DotNetCoreTest("./PredictiveModellingTest/PredictiveModellingTest.csproj");
		});

RunTarget(target);