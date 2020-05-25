
import Data.List
import Data.Char
import qualified Data.Map as M

isPrime n = ip n [2..((isqrt (n-1))+1)]
  where
  ip _ [] = True
  ip n (x:xs)
    | n == 2 = True
    | n `mod` x == 0 = False
    | otherwise = ip n xs

isqrt :: Integral i => i -> i
isqrt = floor . sqrt . fromIntegral

--

sumOfReverse n = n + (read (reverse(show n)))

charValue c = (fromEnum c) - 48

allDigitsOdd n  = go (show n)
    where
    go (x:xs)
        | even (charValue x) = True
        | null xs = True
        | otherwise = go xs

lastDigitZero n = n `mod` 10 == 0

howManyRevs n = length[x | x <- [1..(n-1)] , not(lastDigitZero x), allDigitsOdd (sumOfReverse x) ]

--

-- 60 5 true
isDivisibleBy1ToN v n = go v [1..n]
    where
    go v (x:xs)
        | v `mod` x  /= 0 = False
        | null xs = True
        | otherwise = go v xs

smallest n = go n 1
  where
  go n v
    | isDivisibleBy1ToN v n = v
    | otherwise = go n (v+1)

--

sumOfSquares n = sum[ x^2 | x <- [1..n] ]
squareOfSums n = (sum[ x | x <- [1..n] ])^2

difference n = (squareOfSums n) - (sumOfSquares n)

--

primeFactors n = maximum[x | x <- [2..n], isPrime x, n `mod` x == 0]

--

--n is the nth target prime
--c current count
--p current testing prime
primeList n = go  n 1 2
  where
  go n c p
    | c > n = []
    | isPrime p = p : go n (c+1) (p+1)
    | otherwise = go n c (p+1)

findNthPrime n = last(primeList n)


---------------------------------------------------------------------------------------------------------------

--triangle numbers

triangleNumber n = sum[x | x <- [1..n]]

triangleNumberRec n = go n 1 0
  where 
  go n c t
    | c >= n = t
    | otherwise = go n (c+1) (t+c)

factorsOf n = [x | x <- [1..n], n `mod`  x == 0 ]

numFactorsOf n = length(factorsOf n)

factorsOfRec n = go n 1
  where
  go n c
    | c > n = []
    | n `mod` c == 0 = c : (go n (c+1))
    | otherwise = go n (c+1)

solveProblem f = go 1 f
  where
  go c f 
    | numFactorsOf (triangleNumber c) > f = triangleNumber c
    | otherwise = go (c+1) f

-----------

--Collatz Sequences

chain 1 = [1]
chain n 
  | even n = n : chain (n `div` 2)
  | odd n = n : chain (n*3+1)

isLong xs = length xs > 15

numLongChains n = length (go n 1)
  where 
  go n c
    | c > n = []
    | isLong (chain c) = chain c : go n (c+1)
    | otherwise = go n (c+1)

--

numLongChains' :: Int  
numLongChains' = length (filter (\xs -> length xs > 15) (map chain [1..100]))

--------

--square digits loop

squareADigit c = ((fromEnum c)-48)^2
processDigits xs = sum[squareADigit x | x <- xs]
squareDigits n = processDigits (show n)

generateSequence n
  | n == 1 = 1
  | n == 89 = 89
  | otherwise = generateSequence (squareDigits n)

count89s n = length [x | x <- [1..(n-1)], generateSequence x == 89 ]

---------

--consecutive prime adding

listOfPrimes n = [ x | x <- [2..(n-1)], isPrime x]

getConsecutivePrimes xs = go xs 1 (length xs)
  where
  go xs c 1
    | c >= 1 = []
    | isPrime (sum(take c xs)) = take c xs : go xs (c+1) 1
    | otherwise = go xs (c+1) 1

listAllConsecutivePrimes n = concat [ getConsecutivePrimes (drop x (listOfPrimes n)) | x <- [1..(n-1)] ]
--concat = list of lists into one list 

findLongest n = go (listAllConsecutivePrimes n) []
  where
  go (xs:xxs) longestList
    | null xxs = longestList
    | length xs > (length longestList) = go xxs xs
    | otherwise = go xxs longestList

theGreatest m xxs = sum[xs | xs <- xxs, (length xs) == m ]

-------------------------------

--plaindrome primes

isPalindrome n = (show n) == (reverse (show n))

isSumOfConsecutiveSquares n s = isocs n s 0
  where
  isocs n s t
    | t == n = True
    | t > n = False
    | otherwise = isocs n (s+1) (t+(s*s))

listEm n s = [ x | x <- [1..n], isPalindrome x, isSumOfConsecutiveSquares x s ]

solveProblem2 n = lpntacs n 1
  where
  lpntacs n s
    | s > (isqrt n) = []
    | (length (listEm n s)) > 0 = listEm n s : lpntacs n (s+1)
    | otherwise = lpntacs n (s+1)

-----------------------------------------------

--fold l, r
--accumulator


------------------------------------------------------

--Pythagorean Theorem
--one triple equals 1000
--find product

pythTriple n = [(a,b,c, a*b*c) | a <- [1..n], b <- [1..n], c <- [1..n], a < b, b < c, a < c, (a^2+b^2)==c^2, a+b+c==1000]

-------------------

--sum of primes

sumOfPrimes n = sum [x | x <- [1..(n-1)],isPrime x]

-----------------------

--primes, permutations

listOf4DigitPrimes = [ x | x <- [1000..9999], isPrime x]

primePermutations xs = go xs 0 1 2
  where
  go xs x y z
    | (x > (length xs)-1) = []
    | (y > (length xs)-1) = go xs (x+1) 0 z
    | (z > (length xs)-1) = go xs x (y+1) 0
    | otherwise = (x,y,z) : go xs x y (z+1)

---------------------

--factorial
--sum of digits

factorial 0 = 1
factorial n = n * factorial (n-1)

numberToIntList n = map digitToInt (show n)

sumOfFactorialDigits n = sum (numberToIntList (factorial n))

---------------------------

--non-abundant sums

getDivisors n = [ x | x <- [1..(n-1)], n `mod` x == 0]

isAbundant n = (sum (getDivisors n))>n

listAbundant n = [ x | x <- [1..n], isAbundant x]

isSumOfTwoAbundants n = go n (listAbundant n) 0 0
  where
  go n xs f s
    | f >= (length xs) = False
    | s >= (length xs) = go n xs (f+1) 0
    | not (isAbundant (xs !! f)) = go n xs f (s+1)
    | not (isAbundant (xs !! s)) = go n xs f (s+1)
    | (xs !! f)+(xs !! s)==n = True
    | otherwise = go n xs f (s+1)

solveProblem' n = [ x | x<-[1..n],not (isSumOfTwoAbundants n)]

-------------------------------------------------






















