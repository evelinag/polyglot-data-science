@echo off
install\paket.bootstrapper.exe
if errorlevel 1 (
  exit /b %errorlevel%
)
if not exist paket.lock (
  install\paket.exe install
) else (
  install\paket.exe restore
)
if errorlevel 1 (
  exit /b %errorlevel%
)