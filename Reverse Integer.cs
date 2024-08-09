public class Solution {
    public int Reverse(int x) {
        int y;
        if (x == 0 || x > Int32.MaxValue || x < Int32.MinValue) return 0;

        var result = "";
        var multiplier = 1;

        if (x < 0){
            x *= -1;
            multiplier = -1;
        }

        while (x >= 1){
            var str = x % 10;

            if (str != 0 || result != ""){
                result += $"{str}";
            }

            x = (int)Math.Floor((decimal)x / 10);
        }

        if (!Int32.TryParse(result, out y)) return 0;
        
        return Int32.Parse(result) * multiplier;
    }
}
