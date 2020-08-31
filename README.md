# DbMetaGen

Comprises of two parts:
* A dotnet tool to get SQL metadata
* A source generator to read the metadata and compile a static class  

## Usage

/DbMetagen/DbMetagen.Provider

* Pack and install tool  

`dotnet pack`  

`dotnet tool install --global --add-source ./nupkg DbMetaGen.Provider`  

* Use tool to generate DbMetadata.json in current directory. Uses _Default_ ConnectionStrings key in appsettings.json  

`cd ..\DemoApp`  

`dbmetagen`  


* Souce generator
DemoApp has a reference to DbMetagen.Generator analyzer project.  

It reads DbMetadata.json and outputs the Db c# class for use in the DemoApp
