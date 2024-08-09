public class Solution {
    public bool IsPalindrome(int x) {
        var str = x.ToString();
        var reverse = string.Join("", str.ToCharArray().Reverse());

        return str == reverse;
    }
}
