#Maurizio Altamura

#problem 1
def problem1(x,y):
        print(x*y)

#problem 2
def problem2(x,y,z):
        return(x*y*z)

#problem 3
def first_a(n):
        return [x for x in range(n)
            if x % 6 == 0 or x % 11 == 0]
        
#problem 4
def first_b(n):
        def isMult6Or11(n):
            return( n % 6 == 0 or n % 11 ==0 )
        return [x for x in range (n)
            if isMult6Or11(x)]

#problem 5
def second_a(n):
        return [x for x in range (n)
            if str(x) == (str(x))[::-1] and str(x)[:1] == '3' ]

#problem 6
def second_b(n):
        def isPalindromeThatStartsWithDigit3(n):
            return n
        return [x for x in range (n)
            if str(x) == (str(x))[::-1] and str(x)[:1] == '3' ]
