@echo off
setlocal
set paket=%~dp0\.paket\paket.exe

if not exist %paket% (
    pushd %~dp0
    rmdir /q /s %temp%\nuget\paket
    nuget install -out %temp%\nuget -excludeversion paket
    xcopy %temp%\nuget\paket\tools\paket.exe .\.paket\
    popd
)

%paket% %*
endlocal