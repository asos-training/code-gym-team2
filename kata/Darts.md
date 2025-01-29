# Introduction

Darts is a game where there's a circle divided into 20 segments worth 1 to 20 points.  In the centre is a bulls eye worth 50 points surrounded by a larger circle worth 25 points.  On the outer edge there is a small ring where the points for the segment are doubled and there is a ring around the mid point of the radius where the points for the segment are tripled.  If this description isn't intutitive then check out this [Wikipedia article](https://en.wikipedia.org/wiki/Darts#/media/File:Dartboard_diagram.svg)

# Rules
Both players start at 501 and must reduce that score to 0 by subtracting the score from each dart from that score. The last dart *must* be either a double or a bullseye

# Input 
The current score as an integer

# Output
A string representing the way to get to 0 in the smallest numbers of darts

## Notation
Space separated values with valid outputs being either the numbers 1 - 20 prefixed with D for double and T for triple or B for bulleye and O for outer bulls eye.

# Example

501 = T20 T20 T20 T20 T20 T20 T20 T19 D12

10 = D5

50 = B

# Extension A

Can you adjust your algorithm to be able to use an arbitrary number of darts rather than the most efficient number?

# Extension B

There are actually multiple versions of the 9 dart finish, that is going from 501 to 0 in 9 darts, can you find them all?
