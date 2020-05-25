--COP4020
--Maurizio Altamura

isPrime n = ip n [2..((isqrt (n-1))+1)]
    where
    ip _ [] = True
    ip n (x:xs)
        | n `mod` x == 0 = False
        | otherwise = ip n xs

isqrt :: Integral i => i -> i
isqrt = floor . sqrt . fromIntegral

primeList n = 2 : go ((n*2)-1) 1 2
  where
  go n c p
    | c == n = []
    | isPrime p = p : go n (c+1) (p+2)
    | otherwise = go n c (p+1)

dropEvery _ [] = []
dropEvery n xs = take (n-1) xs ++ dropEvery n (drop n xs)

problem1 n = dropEvery 2 (primeList n)


------------------
fib 0 = 0
fib 1 = 1
fib n = fib(n-1) + fib(n-2)

fibList n = [fib x | x <- [1..n]]

fibList' n = go n 1 1
  where
  go n f s
    | (f+s) > n = []
    | otherwise = (f+s) : go n s (f+s)


problem2 n = go n 1 1
  where
  go n f s
    | (f+s) > n = []
    | otherwise = if head(reverse(show (f+s))) == '3' then (f+s) : go n s (f+s) else go n s (f+s)


-------------------

mult5 n = n `mod` 5 == 0

exact3Factors n = length[x | x <- [1..n], n `mod` x == 0 ] == 3

problem3 n = [x | x <- [1..n], (mult5 x || exact3Factors x)]






