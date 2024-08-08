public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        var totalCount = nums1.Count() + nums2.Count();
        int index1 = 0;
        int index2 = 0;
        bool submit = true;

        if (totalCount % 2 == 0){
            index1 = (totalCount / 2) - 1;
            index2 = totalCount / 2;
        }
        else {
            index1 = (int)Math.Floor((decimal)totalCount / 2);
            index2 = (int)Math.Floor((decimal)totalCount / 2);
        }
		if (!submit) Console.WriteLine("index1: " + index1);
		if (!submit) Console.WriteLine("index2: " + index2);

        if (nums1.Count() > nums2.Count() || (nums1.Count() == 3 && nums1.Last() > nums2.Last())) {
            while (nums2.Any() && nums1.Last() > nums2.First()){ // 3 >= 2 // 3 > 4
                var nums2First = nums2.First(); // 2
				if (!submit) Console.WriteLine(nums2First);
                var splittedNums1 = new List<List<int>>(); // [[1], [2, 3]]

                while(true) {
                    if (nums1.Count() == 1){ 
                        if (nums1[0] >= nums2First){
							if (!submit) Console.WriteLine("break 1");
                            splittedNums1.Add(new List<int> {
                                nums2First, nums1[0] // [2, 3]
                            });
                        }
                        else {
							if (!submit) Console.WriteLine("break 2");
                            splittedNums1.Add(new List<int> {
                                nums1[0], nums2First
                            });
                        }
						
						if (!submit) Console.WriteLine("splitted number break: " + string.Join(", ", splittedNums1.OrderBy(x => x.Last()).Select(s => string.Join(", ", s))));
                        break;
                    }
					
                    var index = (int)Math.Ceiling((decimal)nums1.Count() / 2) - 1; // 0

                    if (nums1[index] > nums2First){ // 1 > 2
						if (!submit) Console.WriteLine("here 1");
                        splittedNums1.Add(nums1.Skip(index + 1).ToList());
                        nums1 = nums1.Take(index + 1).ToArray();
                    }
                    else {
						if (!submit) Console.WriteLine("here 2");
                        splittedNums1.Add(nums1.Take(index + 1).ToList()); // {1}
                        nums1 = nums1.Skip(index + 1).ToArray(); // {3}
                    }
					
					if (!submit) Console.WriteLine("splitted number: " + string.Join(", ", splittedNums1.Select(s => string.Join(", ", s))));
                }

                nums1 = splittedNums1.OrderBy(x => x.Last()).ThenBy(x => x.First()).SelectMany(s => s).ToArray(); //[1, 2, 3]
				nums2 = nums2.Skip(1).ToArray(); // 4
            }
            
			nums1 = nums1.Concat(nums2).ToArray();
            return ((double)nums1[index1] + (double)nums1[index2]) / 2.0;
        }
        else {
			while (nums1.Any() && nums2.Last() > nums1.First()){ // 3 >= 2 // 3 > 4
                var nums1First = nums1.First(); // 2
				if (!submit) Console.WriteLine(nums1First);
                var splittedNums2 = new List<List<int>>(); // [[1], [2, 3]]

                while(true) {
                    if (nums2.Count() == 1){ 
                        if (nums2[0] >= nums1First){
							if (!submit) Console.WriteLine("break 1");
                            splittedNums2.Add(new List<int> {
                                nums1First, nums2[0] // [2, 3]
                            });
                        }
                        else {
							if (!submit) Console.WriteLine("break 2");
                            splittedNums2.Add(new List<int> {
                                nums2[0], nums1First
                            });
                        }
						
						if (!submit) Console.WriteLine("splitted number break: " + string.Join(", ", splittedNums2.OrderBy(x => x.Last()).Select(s => string.Join(", ", s))));
                        break;
                    }
					
                    var index = (int)Math.Ceiling((decimal)nums2.Count() / 2) - 1; // 0

                    if (nums2[index] > nums1First){ // 1 > 2
						if (!submit) Console.WriteLine("here 1");
                        splittedNums2.Add(nums2.Skip(index + 1).ToList());
                        nums2 = nums2.Take(index + 1).ToArray();
                    }
                    else {
						if (!submit) Console.WriteLine("here 2");
                        splittedNums2.Add(nums2.Take(index + 1).ToList()); // {1}
                        nums2 = nums2.Skip(index + 1).ToArray(); // {3}
                    }
					
					if (!submit) Console.WriteLine("splitted number: " + string.Join(", ", splittedNums2.Select(s => string.Join(", ", s))));
                }

                nums2 = splittedNums2.OrderBy(x => x.Last()).ThenBy(x => x.First()).SelectMany(s => s).ToArray(); //[1, 2, 3]
				nums1 = nums1.Skip(1).ToArray(); // 4
            }
            
			nums2 = nums2.Concat(nums1).ToArray();
            return ((double)nums2[index1] + (double)nums2[index2]) / 2.0;
        }
    }
}
