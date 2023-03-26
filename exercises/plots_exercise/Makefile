DLLS = $(addprefix -reference:,$(filter %.dll,$^))
CODE = $(filter %.cs,$^)

erf.svg : erf.gpi erf.data known.data
	gnuplot $<

erf.data : main.exe
	mono $< >$@

main.exe : main.cs sfuns.dll
	mcs -reference:sfuns.dll main.cs

sfuns.dll : erf.cs
	mcs -target:library -out:$@ $^

known.data : Makefile
	>$@
	echo 0.06 0.067 >> $@
	echo 0.5 0.520 >> $@
	echo 1 0.842 >> $@
	echo 1.8 0.989 >> $@
	echo 2.4 0.999 >> $@


