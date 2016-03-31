#!/bin/bash
if test "$OS" = "Windows_NT"
then
  MONO=""
else
  MONO="mono"
fi

$MONO install/paket.bootstrapper.exe
exit_code=$?
if [ $exit_code -ne 0 ]; then
  exit $exit_code
fi
if [ -e "paket.lock" ]
then
  $MONO install/paket.exe restore
else
  $MONO install/paket.exe install
fi
exit_code=$?
if [ $exit_code -ne 0 ]; then
  exit $exit_code
fi
