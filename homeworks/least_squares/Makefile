Outputfile = Out.txt

exp.svg : exp.gpi exp.data
	gnuplot $<

exp.data $(Outputfile): main.exe known.data
	mono main.exe -outfile:$(Outputfile) -outfile_data:exp.data <known.data


main.exe : main.cs qrgs.cs leastsq.cs matrix.dll
	mcs -target:exe -out:$@ qrgs.cs main.cs leastsq.cs -reference:matrix.dll

DIR = ../../matlib/matrix
matrix.dll : $(DIR)/matrix.cs $(DIR)/vector.cs
	mcs -target:library -out:./matrix.dll $^

known.data : Makefile
	>$@  
	echo 1 117 5 >> $@
	echo 2 100 5 >> $@
	echo 3 88 5 >> $@
	echo 4 72 4 >> $@
	echo 6 53 4 >> $@
	echo 9 29.5 3 >> $@
	echo 10 25.2 3 >> $@
	echo 13 15.2 2 >> $@
	echo 15 11.1 2 >> $@
# format: x  y  dy

.PHONEY : clean
clean : 
	rm -f *.exe *.dll [Oo]ut* *.data *.log  *.svg *.txt utputfile
