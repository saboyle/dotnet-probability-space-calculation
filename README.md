# wpf-dotnet-probability-space-visualisation

[![Build Status](https://travis-ci.com/saboyle/wpf-dotnet-probability-space-visualisation.svg?branch=master)]

Exploratory project enabling setup of various automated CI/CD components and services:

* .NetCore
* C#

## Components under consideration / evaluation
* Cake
* Travis CI
* Jenkins
* Code Climate
* Sonar Cloud
* Team City

## Running Notes
* Example running Cake file created / included in root i.e.
``` powershell
./build.ps1
```

* Currently works Travis CI with automated build / badge status update.
* Currently working with Jenkins using Cake build script.
* Code climate integration limited to code analysis. Sonar Cloud will be evaluated as an alternative.
* Problems with Code Climate coverage reporting [suspected platform issue].

### To execute from the command line
```
dotnet restore
dotnet test ./PredictiveModellingTest/PredictiveModellingTest.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput=./PredictiveModellingTest/cobertura.xml
```


