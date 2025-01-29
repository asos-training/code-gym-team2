# Making change part 2

Based on: https://www.codewars.com/kata/5365c93f8d004c94c90002e7/javascript

Given an amount of change to return (from 1 - 100 cents) write code that calculates the number of possible permutations given the American coin demoniations: 100, 50, 25, 10, 5, 1

## Example

For example if the amount of change is 6 cents then the following combinations would be valid

- 5 1
- 1 1 1 1 1 1

Note that 

- 1 5
- 5 1

And all variations on this theme are counted as one possible permutation for the purposes of this exercise i.e. order of coins does not matter


## Extension 1

List all the combinations rather than just counting them.

## Extension 2 

Count all possible re-orderings for the different combinations as well i.e. treating 2,1 and 1,2 as different combinations