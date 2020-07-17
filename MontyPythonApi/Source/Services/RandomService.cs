using System;

namespace Codenation.Challenge.Services
{
    public class RandomService: IRandomService
    {
        public int RandomInteger(int max)
        {
            Random rnd = new Random();

            return rnd.Next(max);
        }
    }
}