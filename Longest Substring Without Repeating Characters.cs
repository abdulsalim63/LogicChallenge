public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var length = s.Length;
        var longestUniqueString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~ ";

        if (s.Contains(longestUniqueString)) return longestUniqueString.Length;

        for (int i=length; i>=1; i--){
            for (int j=0; j<=length - i; j++){
                var subString = s.Substring(j, i);
                var groupSubString = subString.ToCharArray().GroupBy(x => x);

                if (!groupSubString.Any(x => x.Count() > 1)) return i;
            }
        }
        return 0;
    }
}
