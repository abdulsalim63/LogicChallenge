public class Solution {
    public string Convert(string s, int numRows) {
        if (s.Length <= numRows || numRows == 1) return s;

        var maxIndex = s.Length - 1;
        var chrArray = s.ToCharArray();

        var result = "";
        var gapIndex = (numRows * 2) - 2;

        for (int i=0,j=0; i<numRows; i++,j++){
            if (i == 0 || i == numRows - 1){
                while (j <= maxIndex){
                    result += chrArray[j];
                    j += gapIndex;
                }
            }
            else {
                result += chrArray[j];
                j += gapIndex - (i*2);

                while (j <= maxIndex) {
                    for (int k=1; k<=2; k++){
                        if (k % 2 != 0){
                            result += chrArray[j];
                            j += i*2;
                        }
                        else if (j <= maxIndex) {
                            result += chrArray[j];
                            j += gapIndex - (i*2);
                        }
                    }
                }
            } 
            j=i;
        }

        return result;
    }
}
