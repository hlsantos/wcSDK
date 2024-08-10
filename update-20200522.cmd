	git add   wcserver/WcSDK-DotNet.sln
	git add   wcserver/c#/WinServerAPI/WinServerAPI.csproj
	git add   wcserver/c#/WinServerAPI/bin/Debug/WinServerAPI.dll
	git add   wcserver/c#/examples/BSMiniRPTC#.NET/bin/BSMiniRPT.exe
	git add   wcserver/c#/examples/BSMiniRPTC#.NET/bin/WinServerAPI.dll
	git add   wcserver/c#/examples/wcDoor32/wcDoor32-example1/wcDoor32-Example1-Program.cs
	git add   wcserver/c#/examples/wcDoor32/wcDoor32-example2/wcDoor32-Example2-Program.cs
	git add   wcserver/c#/examples/wcDoor32/wcDoor32-example3/wcDoor32-Example3-Program.cs
	git add   wcserver/c#/examples/wcDoor32/wcDoor32-example4/wcDoor32-Example4-Program.cs
	git add   wcserver/c#/includes/wcDoor32API.cs
	git add   wcserver/c#/includes/wcServerAPI.cs
	git add   wcserver/vb.net/examples/BSMiniRPT.NET/bin/BSMiniRPT.exe
	git add   wcserver/vb.net/examples/BSMiniRPT.NET/bin/WinServerAPI.dll

	git rm -f  wcserver/c#/WinServerAPI/bin/Debug/WinServerAPI.pdb
	git rm -f   wcserver/c#/examples/BSMiniRPTC#.NET/bin/BSMiniRPT.pdb
	git rm -f  wcserver/c#/examples/BSMiniRPTC#.NET/bin/WinServerAPI.pdb
	git rm -f  wcserver/vb.net/examples/BSMiniRPT.NET/bin/BSMiniRPT.pdb
	git rm -f wcserver/vb.net/examples/BSMiniRPT.NET/bin/WinServerAPI.pdb


	git add wcserver/c#/includes/describe
	git add wcserver/c#/includes/wcBasic-cmdline.cs
	git add wcserver/c#/includes/wildcat.system.cs
	git add wcserver/cpp/lib64xpd/
	git add wcserver/php/code/describe


goto :eof
    git commit -m "wcSDK Update. Cleanup"

    rem git push -u origin master


