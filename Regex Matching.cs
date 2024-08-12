public class Solution {
    public bool IsMatch(string s, string p){
        var sCharArray = s.ToCharArray();
        var pCharArray = p.ToCharArray();

        bool isSubmit = false;

        int indexP = 0;
        int indexThreshold = 0;

        var result = false;

        for (int i=0; i<20; i++){
            if (!isSubmit) Console.WriteLine(i);
            if (!isSubmit) Console.WriteLine(indexP);

            if (i >= s.Length) {
                var isCharPrevious = false;
                while (indexP < p.Length) {
                    if (pCharArray[indexP] == '*') {
                        isCharPrevious = false;
                        result = true;
                    }
                    else if (pCharArray[indexP] == '.') {
                        if (isCharPrevious) {
                            result = false;
                        }
                        else result = true;

                        isCharPrevious = false;
                    }
                    else {
                        if (isCharPrevious) break;
                        isCharPrevious = true;
                        result = false;
                    }

                    indexP++;
                }
                break;
            }

            if (indexP >= p.Length) {
                if (i >= s.Length) {
                    if (!isSubmit) Console.WriteLine("reach p and s index");
                    break;
                }
                else {
                    if (!isSubmit) Console.WriteLine(sCharArray[i]);
                    if (!isSubmit) Console.WriteLine("reach p index with s left");
                    result = false;
                    break;
                }
            }
            
            if (!isSubmit) Console.WriteLine(sCharArray[i]);
            if (!isSubmit) Console.WriteLine(pCharArray[indexP]);

            if (pCharArray[indexP] == '.' || sCharArray[i] == pCharArray[indexP]){
                if (!isSubmit) Console.WriteLine("same character or .");
                result = true;
                indexP++;
            }
            else if (pCharArray[indexP] == '*'){
                if (pCharArray[indexP - 1] == '.'){
                    if (indexP + 1 >= p.Length) {
                        if (!isSubmit) Console.WriteLine("last p character is .*");
                        return true;
                    }
                    else{
                        // check if the rest is match between s and p
                        indexThreshold = i;
                        // temp
                        return true;
                    }
                }
                else if (sCharArray[i] == pCharArray[indexP - 1]) {
                    if (!isSubmit) Console.WriteLine("* with match previous char");
                    result = true;
                }
                else if (sCharArray[i] != pCharArray[indexP - 1]) {
                    if (!isSubmit) Console.WriteLine("* with doesn't match previous char");
                    result = false;
                    indexP++;
                    i--;
                }
            }
            else {
                indexP++;
                if (indexP >= p.Length) {
                    if (!isSubmit) Console.WriteLine("char doesn't match and last index");
                }

                if (pCharArray[indexP] == '*') {
                    if (!isSubmit) Console.WriteLine("char doesn't match and next s char is *");
                    indexP++;
                    i--;
                    continue;
                }
            }
        }

        return result;
    }
}
