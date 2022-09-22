// See https://aka.ms/new-console-template for more information
// 需要输入一个前置0

foreach (var ints in GetRes(new int[] { 0, 2, 5, 6, 10,15,15 }, 17))
{
    Console.WriteLine(string.Join(',', ints));
}

// L 线材长度, need 
IEnumerable<List<int>> GetRes(int[] need, int L)
{
    while (need.Length > 1)
    {
        List<int> res = new List<int>();
        List<int> temp = new List<int>{0};
        // L大小的空间
        int[][] bag = new int[need.Length][];
        bag[0] = new int[L + 1];
        for (int i = 1; i < need.Length; i++)
        {
            bag[i] = new int[L + 1];
            for (int j = 0; j <= L; j++)
            {
                // 状态转移
                bag[i][j] = bag[i - 1][j];
                if (j >= need[i])
                bag[i][j] = Math.Max(bag[i][j], bag[i - 1][j - need[i]] + need[i]);
            }
        }

        int d = bag[0].Length - 1;
        for (var i = bag.Length - 1; i > 0; i--)
        {
            // 回溯寻找最优选择
            if (bag[i][d] == bag[i - 1][d])
            {
                temp.Add(need[i]);
            }
            else
            {

                d -= need[i];
                res.Add(need[i]);
                 // Console.WriteLine(need[i]);
            }
        }

        need = temp.ToArray();
        // Console.WriteLine(string.Join(',', temp));
        yield return res;

    }
    
}
