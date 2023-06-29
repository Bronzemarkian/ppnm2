erf.svg : erf.gpi Out.txt
	gnuplot erf.gpi

Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs integrator.cs
	mcs -target:exe -out:$@ integrator.cs main.cs 



.PHONEY : clean
clean : 
	rm -f *.exe *.dll [Oo]ut*