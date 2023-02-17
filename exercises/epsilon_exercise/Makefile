Out.txt : main.exe
		mono main.exe > Out.txt

main.exe : main.cs
		mcs main.cs -target:exe -out:$@ 

.PHONEY : clean
clean : 
		rm -f Out.txt main.exe