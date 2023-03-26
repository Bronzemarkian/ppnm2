Out.txt : main.exe
		mono main.exe <input.txt 1>$@ 2>log
# above means input.txt is 'fed' to main.exe, and then the output 1 is
# sent to $@, name of method, so Out.txt, and errors to log?

main.exe : main.cs genlist.dll
		mcs -target:exe -out:$@ \
		$(addprefix -reference:,$(filter %.dll,$^)) \
		$(filter %.cs,$^)

genlist.dll : genlist.cs
		mcs -target:library -out:$@ $<

clean:
		$(RM) *.exe