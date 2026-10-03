# LeetCode

## LeetCode Account

Username: 7V5DqS2LTd

LeetCode Profile: https://leetcode.com/u/7V5DqS2LTd/

[Account submission file](../submission/leetcode/account.md)

## Valid Anagram

Problem URL: https://leetcode.com/problems/valid-anagram/

![Provided Valid Anagram result](images/valid-anagram-accepted.png)

Evidence status: the supplied screenshot shows **Accepted under Test Result**. It does not show an accepted Submit/submission-detail record. Full submission acceptance still needs verification.

[C# solutions and complete explanations](../submission/leetcode/leetcode.md)

### Explanation of the visible solution

- If the strings have different lengths, it returns false immediately.
- It converts each string to a character array and sorts both arrays.
- It compares the sorted arrays using `SequenceEqual`. Matching sorted characters show that each character appears the same number of times, regardless of its original position.
- Character frequencies can also be compared with counters: increment a character's count for the first string, decrement it for the second, then check that all counts are zero. The pictured solution uses sorting rather than counters.
- For equal-length strings of length n, time complexity is O(n log n), because sorting dominates. Space complexity is O(n), because two character arrays are created.

The visible `SequenceEqual` call is a LINQ extension. The screenshot is preserved as supplied. The separate `leetcode.md` includes the same sorting approach with a simple comparison loop instead, so the written solution uses no LINQ. The pictured submission and the revised code should not be treated as identical acceptance evidence.

## Greatest Common Divisor of Strings

Problem URL: https://leetcode.com/problems/greatest-common-divisor-of-strings/

![Provided GCD of Strings result](images/gcd-of-strings-accepted.png)

Evidence status: the supplied screenshot shows **Accepted under Test Result**. It does not show an accepted Submit/submission-detail record. Full submission acceptance still needs verification.

### Explanation of the visible solution

- A string divides another string when repeating it a whole number of times produces that other string. For example, ABC divides ABCABC.
- The visible code compares `str1 + str2` with `str2 + str1`. If they differ, the strings do not share a repeating base pattern, so it returns an empty string.
- If they match, the greatest valid pattern length is the greatest common divisor of the two string lengths. The solution calls `GCD` and returns a prefix of that length from `str1`.
- With the usual Euclidean GCD helper, the length calculation takes O(log(min(m, n))) time, where m and n are the input lengths. Concatenation and string comparison dominate, making the total time O(m + n).
- Auxiliary space is O(m + n), because the compatibility check creates concatenated strings; the returned substring also requires storage.
- The lower part of the GCD helper is cropped in the screenshot. The separate `leetcode.md` completes it with the standard Euclidean algorithm; those cropped lines are reconstructed, not transcribed from unseen source.

## Screenshot location

The official assignment explicitly requires `LeetCode/images/`, so these copies are retained. Following the user's folder correction, the supplied screenshots are also included in `submission/leetcode/` with a README containing the problem links.
