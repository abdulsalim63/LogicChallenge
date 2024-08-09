public class Solution {
    public string LongestPalindrome(string s) {
        for (int i=s.Length; i>=1; i--){
            for (int j=0; j<=s.Length - i; j++){
                var subString = s.Substring(j, i);
                // Console.WriteLine(s.Substring(j, i));

                // var breakLoop = false;

                // for (int k=0; k<Math.Floor((decimal)i / 2); k++){
                //     // Console.WriteLine(subString[k]);
                //     // Console.WriteLine(subString[i - (k + 1)]);

                //     if (subString[k] != subString[i - (k + 1)]){
                //         breakLoop = true;
                //         break;
                //     }
                // }

                // if (breakLoop) continue;

                // return s.Substring(j, i);

                if (subString.Substring(0, 1) != subString.Substring(i - 1, 1)) continue;

                var reverse = string.Join("", subString.ToCharArray().Reverse());

                if (subString == reverse) return subString;
            }
        }

        return s;
    }
}
