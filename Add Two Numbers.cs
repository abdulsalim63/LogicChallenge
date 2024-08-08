/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var valueList = new List<int>();
        var k = 0;

        while (true){
            var value = l1.val + l2.val + k;
            
            if (value >= 10){
                k = 1;
                value -= 10;
            }
            else k = 0;
            
            valueList.Add(value);

            if (l1.next == null && l2.next == null && k == 0) break;

            l1 = l1.next ?? new ListNode(0);
            l2 = l2.next ?? new ListNode(0);
        }

        return CreateNode(valueList);
    }

    private ListNode CreateNode(List<int> valueList){
        if (valueList.Count == 0){
            return null;
        }
        else return new ListNode(valueList[0], CreateNode(valueList.Skip(1).ToList()));
    }
}
