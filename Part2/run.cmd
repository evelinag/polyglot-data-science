@echo off
cls

install\paket.bootstrapper.exe
if errorlevel 1 (
  exit /b %errorlevel%
)

install\paket.exe restore
if errorlevel 1 (
  exit /b %errorlevel%
)

packages\FAKE\tools\FAKE.exe run.fsx %*
