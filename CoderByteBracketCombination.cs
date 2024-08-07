using System;
using System.Collections.Generic;
using System.Linq;

class MainClass {

  public static int BracketCombinations(int num) {
    // code goes here  
    if (num == 1 || num == 2) return num;

    var dict = new Dictionary<int, int>{
      {3, 2}
    };

    for (int i=3; i<=num; i++){
      var distinctCombination = new List<string>();
      var currentCount = 1;

      var baseCombination = Enumerable.Repeat(1, i).ToList();

      // Console.WriteLine("\nbase: " + string.Join(",", baseCombination));
      distinctCombination.Add(string.Join("", baseCombination));

      for (int j=i-1 ; j>=1; j--){
        baseCombination = new List<int> {
          i - j + 1
        };
        
        if (j != 1) {
          baseCombination.AddRange(Enumerable.Repeat(1, j - 1));
        }

        // Console.WriteLine($"\n{j} element: " + string.Join(",", baseCombination));

        distinctCombination.Add(string.Join("", baseCombination.OrderByDescending(x => x)));
        // Console.WriteLine("combination: " + string.Join(",", distinctCombination));
        currentCount += Count(baseCombination, dict);

        if (j != 1) {
          var baseSwitchingIndex = 0;
          while (true) {
            // Console.WriteLine("base index: " + baseSwitchingIndex);
            baseCombination[baseSwitchingIndex]--;
            baseCombination[baseSwitchingIndex + 1]++;
            // Console.WriteLine("switching combination: " + string.Join(",", baseCombination));

            
            if (baseCombination[baseSwitchingIndex] < baseCombination[baseSwitchingIndex + 1]){
              if (baseCombination.Count - 1  == baseSwitchingIndex + 1) {
                // Console.WriteLine("break");
                break;
              }
              else if (distinctCombination.Contains(string.Join("", baseCombination.OrderByDescending(x => x)))){
                // Console.WriteLine("continue");
                baseSwitchingIndex++;
                continue;
              }
              else {
                baseSwitchingIndex++;
                continue;
              }
            }

            // Console.WriteLine($"{j} element: " + string.Join(",", baseCombination));
            distinctCombination.Add(string.Join("", baseCombination.OrderByDescending(x => x)));
            
            // Console.WriteLine("combination: " + string.Join(",", distinctCombination));

            currentCount += Count(baseCombination, dict);
          }
        }
      }

      dict.Add(i + 1, currentCount);
    }
    
    // Console.WriteLine("dict: \n" + string.Join("\n", dict.Select(s => $"{s.Key} {s.Value}")));

    return dict[num + 1];

  }

  public static int Factorial(int num) {
    if (num == 1) return 1;
    else return num * (Factorial(num - 1));
  }

  public static int Count(List<int> baseCombination,  Dictionary<int, int> dict){
    var groupBaseCombination = baseCombination.GroupBy(x => x)
        .Select(x => x.Count())
        .Where(x => x > 1);

    var divider = 1;
    foreach (var div in groupBaseCombination) {
      divider *= Factorial(div);
    }
    
    var totalDictToMultiply = dict.Where(x => baseCombination.Contains(x.Key)).Select(s => s.Value);
    
    var multiplier = 1;
    foreach (var mult in totalDictToMultiply) {
      multiplier *= mult;
    }

    var result = (Factorial(baseCombination.Count) / divider) * multiplier;

    // Console.WriteLine("result: " + result);
    return result;
  }

  static void Main() {  

    // keep this function call here
    Console.WriteLine(BracketCombinations(Console.ReadLine()));
  } 

}
