test.svg oscillator.svg b1.svg b2.svg b3.svg: test.gpi oscillator.gpi b1.gpi b2.gpi b3.gpi Out.txt
	gnuplot test.gpi 
	gnuplot oscillator.gpi
	gnuplot b1.gpi
	gnuplot b2.gpi
	gnuplot b3.gpi

Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs rkstep12.cs matrix.dll
	mcs -target:exe -out:$@ rkstep12.cs main.cs -reference:matrix.dll


DIR = ../../matlib/matrix
matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs
	mcs -target:library -out:./matrix.dll $^


.PHONEY : clean
clean : 
	rm -f *.exe *.dll [Oo]ut* *.data *.svg

