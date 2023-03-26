Out.txt : jacobi.exe
	mono jacobi.exe -rmax:10 -dr:0.3 > Out.txt

jacobi.exe : jacobi.cs matrix.dll
	mcs -reference:matrix.dll jacobi.cs


DIR = $(HOME)/Csharp/ppnm/matlib/matrix
matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs
	mcs -target:library -out:./matrix.dll $^

.PHONEY : clean
clean : 
	rm -f *.exe *.dll [Oo]ut*