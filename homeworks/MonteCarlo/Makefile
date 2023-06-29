
mc.svg mcq.svg compare.svg : mc.gpi mcq.gpi compare.gpi Out.txt
	gnuplot mc.gpi 
	gnuplot mcq.gpi
	gnuplot compare.gpi

Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs mc.cs matrix.dll
	mcs -target:exe -out:$@ mc.cs main.cs -reference:matrix.dll


DIR = ../../matlib/matrix
matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs
	mcs -target:library -out:./matrix.dll $^


.PHONEY : clean
clean : 
	rm -f *.exe *.dll [Oo]ut*
