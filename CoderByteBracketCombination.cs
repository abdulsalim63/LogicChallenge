using System;
using System.Collections.Generic;
using System.Linq;

class MainClass {

  public static int BracketCombinations(int num) {
    // code goes here  
    if (num == 0) return 1;
    if (num == 1 || num == 2) return num;

    var isSubmit = true;

    var dict = new Dictionary<int, int>{
      {3, 2}
    };

    for (int i=3; i<=num; i++){
      // if (i != num) isSubmit = true;
      // else isSubmit = false;

      var distinctCombination = new List<string>();
      var currentCount = 1;

      var baseCombination = Enumerable.Repeat(1, i).ToList();

      if (!isSubmit) Console.WriteLine("\nbase: " + string.Join(",", baseCombination));
      distinctCombination.Add(string.Join("", baseCombination));

      for (int j=i-1 ; j>=1; j--){
        baseCombination = new List<int> {
          i - j + 1
        };
        
        if (j != 1) {
          baseCombination.AddRange(Enumerable.Repeat(1, j - 1));
        }

        if (!isSubmit) Console.WriteLine($"\n{j} element: " + string.Join(",", baseCombination));

        distinctCombination.Add(string.Join("", baseCombination.OrderByDescending(x => x)));
        if (!isSubmit) Console.WriteLine("combination: " + string.Join(",", distinctCombination));
        currentCount += Count(baseCombination, dict);
        if (!isSubmit) Console.WriteLine("currentCount: " + currentCount);

        if (j != 1) {
          var baseSwitchingIndex = 0;
          while (true) {
            if (!isSubmit) Console.WriteLine("base index: " + baseSwitchingIndex);
            baseCombination[baseSwitchingIndex]--;
            baseCombination[baseSwitchingIndex + 1]++;
            if (!isSubmit) Console.WriteLine("switching combination: " + string.Join(",", baseCombination));
            
            if (baseCombination[baseSwitchingIndex] < baseCombination[baseSwitchingIndex + 1]){
              if (baseCombination.Count - 1  == baseSwitchingIndex + 1) {
                if (!isSubmit) Console.WriteLine("break");
                break;
              }
              else {
                baseSwitchingIndex++;
                continue;
              }
            }

            if (distinctCombination.Contains(string.Join("", baseCombination.OrderByDescending(x => x)))){
                if (!isSubmit) Console.WriteLine("continue");
                baseSwitchingIndex++;
                break;
            }

            if (!isSubmit) Console.WriteLine($"{j} element: " + string.Join(",", baseCombination));
            distinctCombination.Add(string.Join("", baseCombination.OrderByDescending(x => x)));
            
            if (!isSubmit) Console.WriteLine("combination: " + string.Join(",", distinctCombination));

            currentCount += Count(baseCombination, dict);
            if (!isSubmit) Console.WriteLine("currentCount: " + currentCount);
          }
        }
      }

      dict.Add(i + 1, currentCount);
    }
    
    if (!isSubmit) Console.WriteLine("dict: \n" + string.Join("\n", dict.Select(s => $"{s.Key - 1} {s.Value}")));

    return dict[num + 1];

  }

  public static int Factorial(int num) {
    if (num == 1) return 1;
    else return num * (Factorial(num - 1));
  }

  public static int Count(List<int> baseCombination,  Dictionary<int, int> dict){
    var groupBaseCombination = baseCombination.GroupBy(x => x)
        .ToDictionary(d => d.Key, d => d.Count());

    var divider = 1;
    foreach (var div in groupBaseCombination.Where(x => x.Value > 1)) {
      // Console.WriteLine("divider: " + div.Value);
      divider *= Factorial(div.Value);
    }
    
    var totalDictToMultiply = dict.Where(x => groupBaseCombination.ContainsKey(x.Key));
    
    var multiplier = 1;
    foreach (var mult in totalDictToMultiply) {
      // Console.WriteLine("multiplier: " + mult.Value);
      multiplier *= mult.Value * groupBaseCombination[mult.Key];
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
