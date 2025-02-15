setlocal
set lib=Phaeyz.Exif
set repoUrl=https://github.com/Phaeyz/Exif
dotnet run ..\%lib%\bin\Debug\net9.0\%lib%.dll ..\docs --source %repoUrl%/blob/main/%lib% --namespace %lib% --clean
endlocal