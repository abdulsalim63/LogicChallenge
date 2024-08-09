public class Solution {
    public int MyAtoi(string s) {
        var multiplier = 1;
        bool fixedMultiplier = false;
        var result = "";

        var charArray = s.ToCharArray();

        for (int i=0; i<charArray.Count(); i++) {
            int j;

            if ((charArray[i] == ' ' || charArray [i] == '_') && !fixedMultiplier) {
                continue;
            }
            else if (Int32.TryParse(charArray[i].ToString(), out j)) {
                fixedMultiplier = true;

                if (result == "" && charArray[i] == '0'){
                    continue;
                }

                result += $"{charArray[i]}";
            }
            else if ((charArray[i] == '-' || charArray[i] == '+') && result == "" && !fixedMultiplier){
                if (charArray[i] == '-'){
                    fixedMultiplier = true;
                    multiplier = -1;
                }
                else {
                    fixedMultiplier = true;
                    continue;
                }
            }
            else break;
        }
        Console.WriteLine("result: " + result);
        
        int k;
        if (result == ""){
            Console.WriteLine("case 1");
            return 0;
        }
        else if (!Int32.TryParse(result, out k)){
            Console.WriteLine("case 2");
            if (multiplier > 0){
                return Int32.MaxValue;
            }
            else return Int32.MinValue;
        }
        else return Int32.Parse(result) * multiplier;
    }
}
