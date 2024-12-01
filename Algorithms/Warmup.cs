namespace Algorithms;

public static class Warmup
{
    // https://www.hackerrank.com/challenges/sock-merchant/problem
    public static int SockMerchant(int n, List<int> ar)
    {
        var pairs = 0;
        var set = new HashSet<int>();

        for (var i = 0; i < n; i++)
        {
            if (set.Add(ar[i])) continue;
            set.Remove(ar[i]);
            pairs++;
        }

        return pairs;
    }

    // https://www.hackerrank.com/challenges/counting-valleys/problem
    public static int CountingValleys(int steps, string path)
    {
        var valleys = 0;
        var level = 0;

        for (var i = 0; i < steps; i++)
        {
            if (path[i] == 'U')
            {
                level++;

                if (level == 0)
                {
                    valleys++;
                }
            }
            else
            {
                level--;
            }
        }

        return valleys;
    }

    // https://www.hackerrank.com/challenges/jumping-on-the-clouds/problem
    public static int JumpingOnClouds(List<int> c)
    {
        var jumps = 0;
        var index = 0;

        while (index < c.Count - 1)
        {
            if (index + 2 < c.Count && c[index + 2] == 0)
            {
                index += 2;
            }
            else
            {
                index++;
            }

            jumps++;
        }

        return jumps;
    }

    // https://www.hackerrank.com/challenges/repeated-string/problem
    public static long RepeatedString(string s, long n)
    {
        var wordFrequency = s.Count(c => c == 'a');

        var times = n / s.Length;

        var rest = n % s.Length;

        return wordFrequency * times + s[..(int)rest].Count(c => c == 'a');
    }
}