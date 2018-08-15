/* 
This website contains a ton of great info for C#:
http://www.csharp-examples.net

The list code examples are taken from there
http://www.csharp-examples.net/list/
*/ 


// Dictionary Map - System.Collections.Generic
    // this function takes in a string and returns the number of characters (case insensitive) in the string that have duplicates elsewhere in the string
    public static int DuplicateCount(string str)
    {
        Dictionary<char, int> count = new Dictionary<char, int>();
        int sum = 0;
        
        for (int i = 0; i < str.Length; i++){
        char c = Char.ToLower(str[i]);
            if (count.ContainsKey(c)){
                count[c]++;
            }else{
                count.Add(c, 1);
            }
        }
        
        foreach( KeyValuePair<char, int> kvp in count ){
            if (kvp.Value >= 2) sum++;	
        }
            
            return sum;
    }

    // create Dictionary with some values
     Dictionary<string, string> match = new Dictionary<string, string>()
    {
        {"NORTH", "SOUTH"},
        {"SOUTH", "NORTH"},
        {"EAST", "WEST"},
        {"WEST", "EAST"}
    };

// Array - fixed length - System.Collections.Generic
    arr.Length; 

    int[] test = new int[] { 97, 92, 81, 60 };
    int[] test2 = new int[4]; // { 0, 0, 0, 0 }
    test2[1] = 6; // { 0, 6, 0, 0 }

    foreach (int i in test2){
        System.Console.WriteLine(i); // prints 0, 6, 0, 0 (each on a new line)
    }

    // an array is a fixed length, so removing an index requires using a list as a translator if you will
    var temp = new List<int>(test); // { 97, 92, 81, 60 }
    temp.RemoveAt(1);
    test = temp.ToArray(); // { 97, 81, 60 }


// List - dynamic length - System.Collections.Generic
    list.Count; 

    // create
    var list1 = new List<int>();
    List<int> list2 = new List<int>(); // same
    List<int> list3 = new List<int>() {5, 13, 6, 8}; // same, but it puts some initial values in there
    
    // copy
    var list4 = new List<int>(list3); // copies list3 into the new variable list4. you can also copy an array into a list this way

    // update/edit
    list1.Add(18); // {18}
    list1.Add(33); // {18, 33}
    list4[2] = 10; // {5, 13, 10, 8}
    list4.AddRange(list1); // {5, 13, 10, 8, 18, 33} - concatenates the 2 lists together
    int index = list4.BinarySearch(8); // 3 (gets the zero based index)
    int index2 = list4.BinarySearch(99); // -4 (returns a neg num if item isn't found in list)
    list3.Clear(); // {} list3 is now empty
    bool contains8 = list4.Contains(8); // true
    bool contains99 = list4.Contains(99); // false

    // convert data type inside list
    var conv = new Converter<int, decimal>(x => (decimal)x);
    var list5 = list4.ConvertAll<decimal>(conv); // {5.0, 13.0, 10.0, 8.0, 18.0, 33.0} (now all type decimal)

    // returns a new list of all items in the list that match the function passed in
    var results = list4.FindAll(x => x > 15); // {18, 33}
    
    // sames as foreach(int x in list4){...}
    list4.ForEach( x => {
        Console.WriteLine(x); 
    })
    
    // equivalent to slicing an array in JS = .GetRange();
    // .GetRange(index, count);
    // list4 currently equals {5, 13, 10, 8, 18, 33}
    var jsSliceEquivalent = list4.GetRange(2, 3); // {10, 8, 18} slices starting at 'index' and gets 'count' number of indexes

    // insert item/list into middle of array (kind of like splicing into an array in JS)
        // listName.Insert(index, newItem)
        list4.Insert(3, 77); // {5, 13, 10, 77, 8, 18, 33}
        // listName.Insert(index, listToInsert)
        list4.InsertRange(1, list1); // {5, 18, 33, 13, 10, 77, 8, 18, 33}

    // removes first instance of item from list (like splicing out of array in JS)
    list4.Remove(33); // {5, 18, 13, 10, 77, 8, 18, 33}

    // removes ALL instances of item from list
    list4.RemoveAll(18); // {5, 13, 10, 77, 8, 33}

    // removes selected INDEX/INDEXES from array
        list4.RemoveAt(1); // {5, 10, 77, 8, 33}

        // .RemoveRange(index, count);
        list4.RemoveRange(0, 2); // {77, 8, 33} removes a count of 2, so removes indexes 0 & 1

    // reverse entire array or part of it
        var list6 = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9};
        
        // entire array
        list6.Reverse(); // {9, 8, 7, 6, 5, 4, 3, 2, 1}

        // part of the array
        // .Reverse(index, count)
        list6.Reverse(5, 3); // {9, 8, 7, 6, 5, 2, 3, 4, 1} - reversed just "2, 3, 4"

    // sort list -  only works if the data type implements IComparable<T> or IComparable interface. (only works if items are sortable, like ints, or if you build a custom compare class that implements the IComparable interface)
    list6.Sort(); // {1, 2, 3, 4, 5, 6, 7, 8, 9}

    // .Sort(index, count, custom comparer) - sorts just part of a list based on the custom comparer you build
        // example of custom comparer:
        public class MyComparer : IComparer<int>
        {
            public int Compare(int x, int y) { return y.CompareTo(x); } // y.CompartTo(x) will sort is descending order
        }
        list6.Sort(2, 3, new MyComparer()); // {1, 2, 5, 4, 3, 6, 7, 8, 9} just sorts indexes 2-4 (starts at index 2 for a count of 3)

    // check if all itesm in the list match a certian critera (returns true or false)
    bool allLessThanTen = list6.TrueForAll(x => x < 10); // True
    bool allEvenNumbers = list6.TrueForAll(x => x % 2 == 0); // False

// Math methods for collections - System.Linq **These work for both arrays AND lists (and possibly other things too) 
    var arr = new int[4] {1, 5, 9, 13};
    var list7 = new List<int>() {1, 5, 9, 13};

    arr.Sum(); // 28
    list7.Sum(); // 28

    int sum = (from x in list7 where x > 4 select x).Sum(); // 27 (sums numbers that meet the listed criteria)

    .Max(); // finds largest number in numeric collection
    .Min(); // finds smallest number in numeric collection
    .Count(); // gets the number of items in the collection (.Length)
    .Average(); // avergaes the numbers in a numeric collection
    .Aggregate( (result, item) => /*do something here*/ ); // applies the supplied callback function to each item in the array for example:
        list7.Aggregate( (result, item) => result * item); // 585 (multiplies all items in the array);

// String



// Char


