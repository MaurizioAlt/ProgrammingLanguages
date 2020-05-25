
#Lipogram List Comprehension Function

def word_smith(string1, string2):

    wordBank = string1.split()
    wordBank = [i.replace(i, ''.join(e for e in i if e.isalnum()) ) for i in wordBank]
    
    validLetters = ''.join(e for e in string2 if e.isalnum())
    validLetters = list(validLetters)

    #print(validLetters)
    #print(wordBank)
    #print(len(wordBank))

    newWordBank = []
    for i in wordBank:
        if (len(i) > 3):
            
            if ( i[0] == 'a' or\
                 i[0] == 'e' or\
                 i[0] == 'i' or\
                 i[0] == 'o' or\
                 i[0] == 'u' or\
                 i[0] == 'y' or\
                 i[0] == 'A' or\
                 i[0] == 'E' or\
                 i[0] == 'I' or\
                 i[0] == 'O' or\
                 i[0] == 'U' or\
                 i[0] == 'Y') :
                newWordBank.append(i)
                continue
                    
            for x in i:
                for y in validLetters:

                    if( (x==y) ):
                            #( x for x in i if x==z for y in validLetters if x==z for z in y if x==z)   ):
                    #print(x + '==' + y)
                        newWordBank.append(i)
                        break

    newWordBank = list(dict.fromkeys(newWordBank))      
    #print(newWordBank)
    return len(newWordBank)


def base_builder(n):

    def getSum(n): 
        sum = 0
        while (n != 0): 
            sum = sum + int(n % 10) 
            n = int(n/10)
        return sum

    array = []
    def recur(n):
        if (n == 0):
            array.append(0)
            return
        array.append(n % 4)
        r = n // 4
        if(r == 0):
            return
        recur(r)

    recur(n)
    quad = int(''.join(map(str,array[::-1])))
    return (getSum(quad), quad)


