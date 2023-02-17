#RM = rm ---force     # this by default

all:Out.txt

Out.txt : main.exe Makefile infile.txt numbers.txt
	mono main.exe hello world \
		-input:infile.txt		  \
		-output:outfile.txt       \
		-numbers:1,2,3,4,5,6 1> $@ 2> log < infile.txt 
	cat infile.txt | mono main.exe hello world \
		-input:infile.txt		  \
		-output:outfile.txt       \
		$$(cat numbers.txt) 1>> $@ 2>> log 
#redirecting standard inputs

main.exe : main.cs input.dll
	mcs -target:exe -out:$@ \
	$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

# other convention, need $ to adress variable or function, string default
# filter finds all files of .cs ?

input.dll : input.cs
	mcs -target:library -out:$@ $(filter %.cs,$^)

numbers.txt : Makefile
	echo "-numbers:7,8,9" > $@

# double $ signals that the variable is not for Makefile, strips of one
# $ and sends the rest to shell

infile.txt : Makefile
	echo 1 >$@
	echo 2 >>$@
	echo 3 >>$@

.PHONEY : clean
clean:
	$(RM) *.exe *.dll [Oo]ut* log*
# quick and dirty, dont actually do it, put actual files
test:
	echo $(RM)
