import math
import random

##import numpy as np
##import scipy as sp
##import pandas as pd
##import matplotlib as mpl
##import seaborn as sns


#class

#fibonacci
def fibList( max ):
    list = [1,1,2]
    def nextFib( f, s, mx ):
        if f + s >= mx:
            return
        else:
            list.append( f + s )
        nextFib( s, f+s, mx )
    nextFib(1,2,max)
    return list

#Primes
def isPrime(n):

    def _isPrime(n,divisor):
        if n ==2:
            True
        if divisor >= math.sqrt(n)+1:
            return True
        if n % divisor == 0:
            return False
        return _isPrime(n,divisor+1)

    return _isPrime(n,2)

#Fibonacci
#def fib(n):


#Factorial
def factorial(n):
    if n <= 1:
        return 1
    else:
        return n*factorial(n-1)

###every nth fibonacci
##def everyNthFib(n,step):
##    fibList = fibonacci(n)
##    retList = []
##
##    def everyNth(n,counter,fibList):
##        if counter >= n
##            return
##        if counter % step == 0:
##            retList.



#url

##url1 = "http://rcs.bu.edu/examples/python/data_analysis/Salaries.csv"
##url2 = "http://rcs.bu.edu/examples/python/data_analysis/flights.csv"
##
##df = pd.read_csv(url1)
##
##subset = df['salary']
##
##print("max:{} min:{} cnt:{}".format(np.max(subset), np.min(subset), subset.count ))



#test2 list comp, recur, pandas, picture
    
#Graphics













    









