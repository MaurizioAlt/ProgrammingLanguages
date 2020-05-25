file <- read.csv("review.csv", header = TRUE)
file[file$overall >= 4.0, ]