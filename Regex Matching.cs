public class Solution {
    public bool IsMatch(string s, string p){
        var sCharArray = s.ToCharArray();
        var pCharArray = p.ToCharArray();

        bool isSubmit = false;

        int indexP = 0;
        var indexThreshold = new Dictionary<int, int>();

        var result = false;

        for (int i=0; i<20; i++){
            if (!isSubmit) Console.WriteLine(i);
            if (!isSubmit) Console.WriteLine(indexP);

            if (i >= s.Length) {
                if (!isSubmit) Console.WriteLine("reach max index s");
                var isCharPrevious = pCharArray[indexP - 1] != '*';
                while (indexP < p.Length) {
                    if (!isSubmit) Console.WriteLine(isCharPrevious + " " + pCharArray[indexP]);
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
                        indexP++;

                        if (indexP < p.Length && pCharArray[indexP] == '*'){
                            indexP++;
                            continue;
                        }

                        if (indexThreshold.Any()) {
                            if (!isSubmit) Console.WriteLine("got indexThreshold value " + string.Join(", ", indexThreshold.Select(s => $"{s.Key}={s.Value}")));
                            indexP--;
                            result = false;

                            while (!result && indexThreshold.Any()) {
                                if (!indexThreshold.Any()) return false;

                                var lastIndexDict = indexThreshold.Last();

                                for (int j=i-1; j>lastIndexDict.Key; j--) {
                                    if (sCharArray[j] == pCharArray[indexP]) {
                                        if (!isSubmit) Console.WriteLine("element match checking index threshold " + pCharArray[indexP] + " " + sCharArray[j]);
                                        i = j;
                                        indexThreshold.Add(j, indexP);
                                        indexP++;
                                        result = true;
                                        break;
                                    }
                                }

                                if (result) break;

                                indexThreshold.Remove(lastIndexDict.Key);
                                indexP = lastIndexDict.Value;
                            }

                            continue;
                        }
                        else {
                            return false;
                        }

                        if (isCharPrevious) break;
                        isCharPrevious = true;
                        result = false;
                    }

                    indexP++;
                }
                break;
            }

            if (indexP >= p.Length) {
                if (pCharArray[indexP - 1] == '*' && result) {
                    if (!isSubmit) Console.WriteLine("reach p but previous *");
                    indexP--;
                }
                else if (i >= s.Length) {
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

            if (sCharArray[i] == pCharArray[indexP] || pCharArray[indexP] == '.') {
                if (!isSubmit) Console.WriteLine("match: " + sCharArray[i] + " " + pCharArray[indexP]);
                result = true;
                indexP++;

                if (indexP >= p.Length) continue;

                if (pCharArray[indexP] != '*') {// && pCharArray[indexP - 1] != '.'){
                    indexThreshold.Add(i, indexP - 1);
                }

                continue;
            }
            else if (pCharArray[indexP] == '*') {
                if (!isSubmit) Console.WriteLine("* on element p");
                if (pCharArray[indexP - 1] == '.') {
                    result = true;
                    if (!isSubmit) Console.WriteLine("previous element match: " + pCharArray[indexP - 1]);
                    indexP--;
                }
                else if (sCharArray[i] == pCharArray[indexP - 1]) {
                    result = true;
                    if (!isSubmit) Console.WriteLine("previous element match: " + pCharArray[indexP - 1]);
                }
                else {
                    result = false;
                    i--;
                    if (!isSubmit) Console.WriteLine("previous element doesn't match");
                }

                indexP++;
            }
            else {
                indexP++;
                if (!isSubmit) Console.WriteLine("element doesn't match");

                if (indexP < p.Length && pCharArray[indexP] == '*'){
                    indexP++;
                    i--;
                    continue;
                }

                if (indexThreshold.Any()) {
                    if (!isSubmit) Console.WriteLine("got indexThreshold value " + string.Join(", ", indexThreshold.Select(s => $"{s.Key}={s.Value}")));
                    indexP--;
                    // Check up until before the last indexThreshold
                    // if it's 3, check only until 4
                    // if still doesn't find a match, remove the last index
                    // then do it again with the new last index
                    // until empty, then return false
                    // if found match, add this new index into index Threshold

                    // do it again with the next element on p
                    result = false;

                    while (!result) {
                        if (!indexThreshold.Any()) return false;

                        var lastIndexDict = indexThreshold.Last();

                        for (int j=i-1; j>lastIndexDict.Key; j--) {
                            if (sCharArray[j] == pCharArray[indexP]) {
                                if (!isSubmit) Console.WriteLine("element match checking index threshold " + pCharArray[indexP] + " " + sCharArray[j]);
                                i = j;
                                indexThreshold.Add(j, indexP);
                                indexP++;
                                result = true;
                                break;
                            }
                        }

                        if (result) break;

                        indexThreshold.Remove(lastIndexDict.Key);
                        indexP = lastIndexDict.Value;
                    }

                    continue;
                }
                else {
                    return false;
                }
            }

            /*
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
            }*/
        }

        return result;
    }
}

// Testcase
/*"aa"
"a"
"aa"
"a*"
"ab"
".*"
"caab"
"c*a*b."
"caab"
"c*a*b*."
"aaa"
".*"
"abcd"
"d*"
"a"
"a*a"*/
