Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs qrgs.cs matrix.dll
	mcs -target:exe -out:$@ qrgs.cs main.cs -reference:matrix.dll

# reference for smarter method below, but less obvious one. Same as above
main2.exe : main.cs qrgs.cs matrix.dll
	mcs -target:exe -out:$@ \
	$(filter %.cs, $^) \
	$(addprefix -reference:, $(filter %.dll,$^))
	

DIR = ../../matlib/matrix
matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs
	mcs -target:library -out:./matrix.dll $^

.PHONEY : clean
clean : 
	rm -f *.exe *.dll [Oo]ut*