--Maurizio Altamura
--COP4020

multiplyTwo x y = x*y

multiplyThree x y z = x*y*z

first_a n = [x | x <- [1..n], (x `mod` 6 == 0) || (x `mod` 11 == 0)]

isMult6Or11 x = (x `mod` 6 == 0) || (x `mod` 11 == 0)
first_b n = [x | x <- [1..n], isMult6Or11 x]

second_a n = [x | x <- [1..n], (reverse(show x) == show x), head(show x) == '3']

isPalindromeThatStartsWithDigit3 n = (reverse(show n) == show n) && head(show n) == '3'
second_b n = [x | x <- [1..n], isPalindromeThatStartsWithDigit3 x]