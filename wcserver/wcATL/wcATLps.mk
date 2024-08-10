
wcATLps.dll: dlldata.obj wcATL_p.obj wcATL_i.obj
	link /dll /out:wcATLps.dll /def:wcATLps.def /entry:DllMain dlldata.obj wcATL_p.obj wcATL_i.obj \
		kernel32.lib rpcndr.lib rpcns4.lib rpcrt4.lib oleaut32.lib uuid.lib \

.c.obj:
	cl /c /Ox /DWIN32 /D_WIN32_WINNT=0x0400 /DREGISTER_PROXY_DLL \
		$<

clean:
	@del wcATLps.dll
	@del wcATLps.lib
	@del wcATLps.exp
	@del dlldata.obj
	@del wcATL_p.obj
	@del wcATL_i.obj
