Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs minimize.cs optimize.cs matrix.dll
	mcs -target:exe -out:$@ main.cs minimize.cs optimize.cs -reference:matrix.dll


DIR = ../matlib/matrix
matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs
	mcs -target:library -out:./matrix.dll $^


.PHONEY : clean
clean : 
	rm -f *.exe *.dll [Oo]ut*