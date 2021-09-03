using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ArrayAssignment : MonoBehaviour
{
    ///
    ///  assign array with another array;
    ///  debug the old one;
    ///

    public int[] array1 = new int[] { };
    public int[] array2 = new int[] { };

    public string[] names = { "Bill", "Steve", "James", "Mohan" };


    private void Start()
    {
        // Data source

        // LINQ Query 
        var myLinqQuery = from name in names
                          where name.Contains('a')
                          select name;

        // Query execution
        foreach (var name in myLinqQuery)
           // Debug.Log(name + " ");

        array1 = array2;
        foreach (var item in array1)
        {
           // Debug.Log(item);
        }
        
    }
    // Data source
   
}
