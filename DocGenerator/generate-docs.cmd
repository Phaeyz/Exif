setlocal
set libName=Phaeyz.Exif
set repoUrl=https://github.com/Phaeyz/Exif
dotnet run ..\%libName%\bin\Debug\net9.0\%libName%.dll ..\docs --source %repoUrl%/blob/main/%libName% --namespace %libName% --clean
endlocal