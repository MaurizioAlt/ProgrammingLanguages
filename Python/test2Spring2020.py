import random
import math

from graphics import *

import numpy as np
import scipy as sp
import pandas as pd
import matplotlib as mpl
import seaborn as sns

def test2Problem1(string):
    if len(string) == 0:
        return string
    elif string[0] in ('a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y'):
        return test2Problem1(string[1:]) + ''
    else:
        return test2Problem1(string[1:]) + string[0]


def isPrime(n):

    def _isPrime(n,divisor):
        if n ==2:
            return True
        if divisor >= math.sqrt(n)+1:
            return True
        if n % divisor == 0:
            return False
        return _isPrime(n,divisor+1)

    return _isPrime(n,2)

def test2Problem2(n):

    count = 0
    num = 2
    while count < (2*n):
         if isPrime(num):
            #primeBank.append(num)
            count = count + 1
         num = num + 1


    
    primeBank = [x for x in range(2, num) if isPrime(x)]

    return primeBank[::2]



url = "http://rcs.bu.edu/examples/python/data_analysis/Salaries.csv"
df = pd.read_csv(url)

def test2Problem3a():
    val = (df['salary'].mean())
    val = round(val, 2)
    return val

def test2Problem3b():
    df_f = df[ df['sex'] == 'Female']
    df_f = df_f[ df_f['rank'] == 'AsstProf']

    val = (df_f['salary'].mean())
    val = round(val, 2)
    return val

def test2Problem3c():
    newOne = df['salary'].std()
    val = round(newOne, 2)
    return val



def test2Problem4():
    
    win = GraphWin('Face', 200, 250) # give title and dimensions
    win.setCoords(0,0,200,250)
    win.setBackground('yellow')
    
    eye1 = Circle(Point(50,200), 25) # set center and radius
    eye1.setFill("orange")
    eye1.setWidth(2)
    eye1.draw(win)

    eye11 = Circle(Point(50,200), 2) # set center and radius
    eye11.setFill('black')
    eye11.draw(win)

    eye2 = Circle(Point(150, 200), 25)
    eye2.setFill('green')
    eye2.setWidth(2)
    eye2.draw(win)

    eye22 = Circle(Point(150,200), 2) # set center and radius
    eye22.setFill('black')
    eye22.draw(win)

    rect = Rectangle(Point(40, 90), Point(160, 70))
    rect.setFill('blue')
    rect.setWidth(2)
    rect.draw(win)

    vertices = [Point(100, 170), Point(75, 120), Point(125, 120)]
    triangle = Polygon(vertices)
    triangle.setFill('red')
    triangle.setOutline('black')
    triangle.setWidth(2)  # width of boundary line
    triangle.draw(win)

    message = Text(Point(win.getWidth()/2, 40), 'It is another day in paradise')
    message2 = Text(Point(win.getWidth()/2, 20), 'Click the mouse to continue')
    message.draw(win)
    message2.draw(win)
    message.setTextColor('orange')
    message2.setTextColor('blue')
    message.setSize(10)
    message2.setSize(10)
    
    win.getMouse()
    win.close()


