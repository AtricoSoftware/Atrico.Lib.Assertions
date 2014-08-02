:: @echo off

:: Build targets
msbuild Atrico.Lib.Assertions.csproj /t:Build /p:Configuration="Release 4.0"
msbuild Atrico.Lib.Assertions.csproj /t:Build /p:Configuration="Release"

:: Package
nuget pack -Symbols -IncludeReferenced -OutputDir bin -Prop Configuration="Release"