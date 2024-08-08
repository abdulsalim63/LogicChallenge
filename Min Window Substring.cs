using System;
using System.Collections.Generic;
using System.Linq;

class MainClass {

  public static string MinWindowSubstring(string[] strArr) {
    // code goes here  
    var uniqChar = strArr[1].ToCharArray().ToList();
    // Console.WriteLine(string.Join(", ", uniqChar));

    var groupChar = uniqChar.GroupBy(x => x);

    var result = "";

    for (int i=uniqChar.Count; i<=strArr[0].Length; i++){
      for (int j=0; j<=strArr[0].Length - i; j++){
        var subString = strArr[0].Substring(j, i);
        // Console.WriteLine("substring " + subString);

        var groupSubStr = subString.ToCharArray().ToList().GroupBy(x => x)
          .ToDictionary(d => d.Key, d => d.Count());

        var containsAll = true;

        foreach (var chr in groupChar){
          containsAll = containsAll && groupSubStr.ContainsKey(chr.Key) && (groupSubStr[chr.Key] >= chr.Count());
        }

        if (containsAll){
          // Console.WriteLine("result: " + subString);
          result = subString;
          break;
        }
      }

      if (!string.IsNullOrEmpty(result)){
        break;
      }
    }

    return result;

  }

  static void Main() {  

    // keep this function call here
    Console.WriteLine(MinWindowSubstring(Console.ReadLine()));
    
  } 

}
