@echo off
cls
tools\nant\bin\NAnt.exe -buildfile:default.build -l:_build.log %*

