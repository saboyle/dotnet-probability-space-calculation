#tool "nuget:?package=xunit.runner.console&version=2.4.1"

var target = Argument("target", "Default");
var solution = File("./PredictiveModelling.sln");

Task("Default")
	.IsDependentOn("xUnit");

Task("Build")
	.Does(() => {
		MSBuild(solution);
	});

Task("xUnit")
	.IsDependentOn("Build")
	.Does(() => {
		DotNetCoreTest("./PredictiveModellingTest/PredictiveModellingTest.csproj");
		});

RunTarget(target);