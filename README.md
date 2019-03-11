# NetWx
Cross-platform .NET Core command line tool to get the current weather conditions

## Sample Command:
kiad is the NWS weather station code for Washington-Dulles International Airport.
This can be substituted with any NWS weather station code.

[List of NWS station codes](http://www.nws.noaa.gov/emwin/sitename.htm) 

On Windows:
```
NetWx.exe kiad
```
On Linux:
```
./NetWx kiad
```

## Build Instructions
Build using Visual Studio or with the .NET Core CLI.

**CLI Instructions**
```
dotnet publish -c Release -r win10-x64
```
or
```
dotnet publish -c Release -r linux-x64
```
