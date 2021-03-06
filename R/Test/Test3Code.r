
#Change the directory
#getwd()
#setwd("C:/Users/mauri/OneDrive/Documents/Programming Languages/R/Test")

fin <- read.csv("test3data.csv", na.strings=c(""))

# filter rev
fin$Revenue <- as.character(fin$Revenue)
fin$Revenue <- gsub('[$,]','',fin$Revenue)
fin$Revenue <- gsub(' Dollars','',fin$Revenue)
fin$Revenue <- as.numeric(fin$Revenue)

# filter exp
fin$Expenses <- as.character(fin$Expenses)
fin$Expenses <- gsub('[$,]','',fin$Expenses)
fin$Expenses <- gsub(',','',fin$Expenses)
fin$Expenses <- as.numeric(fin$Expenses)

# fill rev, exp, profit
fin$Revenue[which(is.na(fin$Revenue))] <- mean(fin$Revenue, na.rm = TRUE)
fin$Expenses[which(is.na(fin$Expenses))] <- mean(fin$Expenses, na.rm = TRUE)
fin$Profit[which(is.na(fin$Profit))] <- (fin$Revenue - fin$Expenses)

# remove missing industry 
fin <- fin[!is.na(fin$Industry),]

# fill states
fin$State[which(is.na(fin$State) & fin$City=="Sacramento")] <- "California"
fin$State[which(is.na(fin$State) & fin$City=="Cheyenne")] <- "Wyoming"
fin$State[which(is.na(fin$State) & fin$City=="Jackson")] <- "Mississippi"


# profit for months of 6
profit6 <- median(fin$Profit[which(fin$Month == 6)], na.rm = TRUE)
profit6



#################################

library(ggplot2)

cherry2 <- read.csv("cherry.csv")
cherry2 <- cherry2[ , c(2,3)]

barplot(t(as.matrix(cherry2)), main = "Graph", xlab = "Id", col = c("blue", "red"), legend = c("Height", "Volume"), beside=TRUE, names.arg = c(1:31))


# symmetry - was symmetric in regards to the height, but not in volume
#		symmetrical about 15 for height
#		symmetrical about 20 for volume
# middle - the volume grows towards the right, height does not
#		middle is about 16 for height
#		middle is about 19 for volume
# spread - height is not skewed, volume is skewed right
# unusual features - nothing


#################################

cherry3 <- read.csv("cherry.csv")
cherry3line <- lm(cherry3$Height ~ cherry3$Volume)

plot(cherry3$Volume, cherry3$Height, xlab="Volume", ylab="Height", main="Height vs. Volume")
abline(cherry3line)





