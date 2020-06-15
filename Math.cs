using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
  public class Math
  {
    public List<int> Fibonacci()
    {
      List<int> fibList = new List<int> { 0, 1 };

      for (int i = 1; fibList[i - 1] + fibList[i] <= 350; i++)
        fibList.Add(fibList[i - 1] + fibList[i]);

      return fibList;
    }

    public bool IsFibonacci(int numberToTest)
    {
      return Fibonacci().Contains(numberToTest);
    }
  }
}
