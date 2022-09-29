namespace HW1;

public class Tests
{
    
    static int[] Append(int[] array, int number)
    {
        int[] outp = {number};
        if (array == null)
        {
            return outp;
        }
        int size = array.Length;
        outp = new int[size + 1];
        for (int i = 0; i < size; i++)
        {
            outp[i] = array[i];
        }
        outp[size] = number;
        return outp;
    }
    static int[] GetIndexes(int[] array, int number)
    {
        if (array == null)
        {
            return null;
        }
        int[] outp = null;
        for (int i  = 0; i < array.Length; i++)
        {
            if (array[i] == number)
            {
                outp = Append(outp, i);
            }
        }
        return outp;
    }
    static int[] GetItemsAbove(int[] array, int number)
    {
        if (array == null)
        {
            return null;
        }
        int[] outp = null;
        foreach (int i in array)
        {
            if (i > number)
            {
                outp = Append(outp, i);
            }
        }
        return outp;
    }
    static int[] GetItemsExcept(int[] array, int number)
    {
        int[] outp = null;
        if (array == null)
        {
            return null;
        }
        foreach (int i in array)
        {
            if (i != number)
            {
                outp = Append(outp, i);
            }
        }
        return outp;
    }
    static int[] GetAllContains(int[] array, int number)
    {
        if (array == null)
        {
            return null;
        }
        int[] outp = null;
        bool candidate;
        string num = number.ToString();
        foreach (int i in array)
        {
            string ph = i.ToString();
            for (int j=0; j<ph.Length; j++)
            {
                candidate = true;
                if (ph[j] == num[0])
                {
                    if (j + num.Length > ph.Length)
                    {
                        candidate = false;
                    }
                    else
                    {
                        for (int k = 1; k < num.Length; k++)
                        {
                            if (ph[j+k] != num[k])
                            {
                                candidate = false;
                                break;
                            }
                        }
                    }
                    if (candidate)
                    {
                        outp = Append(outp, i);
                        break;
                    }

                }
            }
        }
        return outp;
    }
    static int find_min(int[] og_array)
    {
        int min = og_array[0];
        int ind = 0;
        for (int i = 1; i < og_array.Length; i++)
        {
            if (og_array[i] < min)
            {
                min = og_array[i];
                ind = i;
            }
        }
        return ind;
    }
    static int[] GetSorted(int[] og_array)
    {
        int[] outp = {};
        if (og_array == null || og_array == new int[] {})
        {
            return og_array;
        }
        int ind_min = 0;
        int[] temp_array = og_array;
        for (int i=0; i<og_array.Length; i++)
        {
            ind_min = find_min(temp_array);
            outp = Append(outp, temp_array[ind_min]);
            temp_array = DeleteIndex(temp_array, ind_min);
        }
        return outp;
    }
    static bool AreItemsSame(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            return true;
        }
        int item = array[0];
        for (int i=1; i<array.Length; i++)
        {
            if (array[i] != item)
            {
                return false;
            }
        }
        return true;
    }
    static int[] DeleteIndex(int[] array, int ind)
    {
        int size = array.Length;
        int[] outp = {};
        for (int i = 0; i < size; i++)
        {
            if (i != ind)    
            { 
                outp = Append(outp, array[i]);
            }
        }
        return outp;
    }

    [TestCase(new int[] {}, 7, ExpectedResult = new int[] {7})]
    [TestCase(null, -53, ExpectedResult = new int[] {-53})]
    [TestCase(new int[] {1}, 2, ExpectedResult = new int[] {1,2})]
    [TestCase(new int[] {1,242,3,1,6,3,2}, 6756, ExpectedResult = new int[] {1,242,3,1,6,3,2,6756})]
     public int[] Test_Append(int[] arr, int number)
    {
        return Append(arr, number);
    }
    

    [TestCase(null, -53, ExpectedResult = null)]
    [TestCase(new int[] {1,242,6756,3,1,6,3,2}, 1, ExpectedResult = new int[] {0,4})]
    [TestCase(new int[] {1,242,-3,1,3,-3,2}, -3, ExpectedResult = new int[] {2,5})]
    [TestCase(new int[] {124,5,76,32}, -634, ExpectedResult = null)]
    [TestCase(new int[] {1}, 1, ExpectedResult = new int[] {0})]
    public int[] Test_GetIndexes(int[] arr, int number)
    {
        return GetIndexes(arr, number);
    }
    
    [TestCase(null, 74, ExpectedResult = null)]
    [TestCase(new int[] {1,242,6756,3,6,-3,-2}, 7, ExpectedResult = new int[] {242,6756})]
    [TestCase(new int[] {-15,-242,-3,11,33,-36,-2}, -8, ExpectedResult = new int[] {-3,11,33,-2})]
    [TestCase(new int[] {124,5,76,32}, 634, ExpectedResult = null)]
    [TestCase(new int[] {-1,-53,-6}, 1, ExpectedResult = null)]
    public int[] Test_GetItemsAbove(int[] arr, int number)
    {
        return GetItemsAbove(arr, number);
    }

    
    [TestCase(null, -2, ExpectedResult = null)]
    [TestCase(new int[] {1,242,6756,3,-6,3,-2}, 7, ExpectedResult = new int[] {1,242,6756,3,-6,3,-2})]
    [TestCase(new int[] {-15,-242,-3,11,33,-3,-2}, -3, ExpectedResult = new int[] {-15,-242,11,33,-2})]
    [TestCase(new int[] {63}, 63, ExpectedResult = null)]
    [TestCase(new int[] {-1,-53,-6}, 1, ExpectedResult = new int[] {-1,-53,-6})]
    public int[] Test_GetItemsExcept(int[] arr, int number)
    {
        return GetItemsExcept(arr, number);
    }
    

    [TestCase(null, -53, ExpectedResult = null)]
    [TestCase(new int[] {1,242,6,3,-6,3,-2}, -6, ExpectedResult = new int[] {-6})]
    [TestCase(new int[] {1,242,6756,3,-6,3,-2}, 6, ExpectedResult = new int[] {6756,-6})]
    [TestCase(new int[] {-15,-84,-48,11,33,-36,-848}, -8, ExpectedResult = new int[] {-84,-848})]
    [TestCase(new int[] {124,5,76,32}, 63, ExpectedResult = null)]
    [TestCase(new int[] {1,242,6756,3,-6,3,-2}, 6, ExpectedResult = new int[] {6756,-6})]
    [TestCase(new int[] {-1,56346,-3464,35323,3534}, 346, ExpectedResult = new int[] {56346,-3464})]
    public int[] Test_GetAllContains(int[] arr, int number)
    {
        return GetAllContains(arr, number);
    }


    [TestCase(null, ExpectedResult = null)]
    [TestCase(new int[] {1,242,6756,3,-6,3,-2}, ExpectedResult = new int[] {-6,-2,1,3,3,242,6756})]
    [TestCase(new int[] {-15,-242,-3,-11,-33,-36,-2}, ExpectedResult = new int[] {-242,-36,-33,-15,-11,-3,-2})]
    [TestCase(new int[] {124,5,76,32}, ExpectedResult = new int[] {5,32,76,124})]
    [TestCase(new int[] {}, ExpectedResult = new int[] {})]
    [TestCase(new int[] {0,0,0}, ExpectedResult = new int[] {0,0,0})]
    public int[] Test_GetSorted(int[] arr)
    {
        return GetSorted(arr);
    }


    [TestCase(null, ExpectedResult = true)]
    [TestCase(new int[] {1,242,6756,3,-6,3,-2}, ExpectedResult = false)]
    [TestCase(new int[] {-33,-33,-33,-33,-33,-33,-33}, ExpectedResult = true)]
    [TestCase(new int[] {124,5,76,32}, ExpectedResult = false)]
    [TestCase(new int[] {-23,-535,-6,-2232,-42}, ExpectedResult = false)]
    [TestCase(new int[] {}, ExpectedResult = true)]
    [TestCase(new int[] {0,0,0}, ExpectedResult = true)]
    public bool Test_AreItemsSame(int[] arr)
    {
        return AreItemsSame(arr);
    }
}