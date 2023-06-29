point = 6.5

lspline.svg qspline_test.svg : lspline.gpi qspline_test.gpi lspline.data
	gnuplot lspline.gpi
	gnuplot qspline_test.gpi

Out.txt lspline.data : main.exe test.data
	mono main.exe -z:$(point) <test.data 1> lspline.data 2> Out.txt 

main.exe : main.cs spline.cs matrix.dll
	mcs -target:exe -out:$@ main.cs spline.cs -reference:matrix.dll

DIR = ../../matlib/matrix
matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs
	mcs -target:library -out:./matrix.dll $^

test.data : Makefile
	>$@  
	echo 1 2 >> $@
	echo 2 6 >> $@
	echo 3 2 >> $@
	echo 4 1 >> $@
	echo 5 5 >> $@
	echo 6 7 >> $@
	echo 7 8 >> $@

clean : 
	rm -f *.exe *.dll [Oo]ut* *.data *.svg

