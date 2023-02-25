#RM = rm ---force

all: Out.txt

Out.txt : cmdline.exe stdin.exe filestream.exe inputfile.txt Makefile
	>$@
	
	echo "Reading numbers from command-line arguments:" >>$@
	mono cmdline.exe -numbers:1e-2,-2e4,3.1415 1>>$@ 2>>log
	
	echo "Reading numbers from stdandard input:" >>$@
	mono stdin.exe <inputfile.txt 1>>$@ 2>>log
	
	echo "Reading numbers from a file and writing to a file:" >>$@
	mono filestream.exe -input:inputfile.txt -output:outfile.txt \
		1>>$@ 2>>log
	echo "here is a copy of the output:" >>$@
	cat outfile.txt >> $@

cmdline.exe : cmdline.cs
	mcs -target:exe -out:$@ \
	$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

stdin.exe : stdin.cs
	mcs -target:exe -out:$@ \
	$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

filestream.exe : filestream.cs
	mcs -target:exe -out:$@ \
	$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

numbers.txt : Makefile
	echo "-numbers:-7.7e-8,8.8e-2,9.9e-3" > $@

inputfile.txt : Makefile
	echo -1.1e-3 >$@
	echo 2e-4  >>$@
	echo -3e-5 >>$@

.PHONEY : clean
clean:
	$(RM) *.exe *.dll [Oo]ut* log*

test:
	echo $(RM)