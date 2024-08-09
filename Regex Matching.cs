public class Solution {
    public bool IsMatch(string s, string p){
        var sCharArray = s.ToCharArray();
        var pCharArray = p.ToCharArray();

        int indexP = 0;

        for (int i=0; i<s.Length; i++){
            if (indexP >= p.Length) return false;

            if (pCharArray[indexP] == '.' || sCharArray[i] == pCharArray[indexP]){
                indexP++;
            }
            else if (pCharArray[indexP] == '*'){
                if (pCharArray[indexP - 1] == '.') return true;
                else if (sCharArray[i] != pCharArray[indexP - 1]) {
                    indexP++;
                    i--;
                }
            }
            else {
                indexP++;
                if (indexP >= p.Length) return false;

                if (pCharArray[indexP] == '*') {
                    indexP++;
                    i--;
                    continue;
                }
            }
        }

        return true;
    }
}
