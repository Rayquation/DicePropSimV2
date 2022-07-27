using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicePropSimV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program x = new Program();
            Console.Write("Indtast mængde af terninger => ");
            int dice = Convert.ToInt32(Console.ReadLine());
            string amount = x.Posibillity(dice);
            List<int> Dies = new List<int>();
            for (int i = 0; i < dice; i++)
            {
                Dies.Add(x.Random());
                Console.WriteLine(Dies[i]);
            }
            //double pos = (double)Outcome(Dies.Sum(), listOfLists,dice)/amount*100.00;
            Console.WriteLine($"Forskellige muligheder af slag => {amount}");
            x.dicesSum(dice, Dies.Sum());
            Console.ReadKey();
        }
        public string Posibillity(int Amount)
        {
            string pos = Convert.ToString(Math.Pow(6, Amount));
            return pos;
        }
        public int Random()
        {
            Random rand = new Random();
            return rand.Next(1, 7);
        }
        void dicesSum(int num, int desire)
        {
            double[,] dp = new double[num + 1, 6 * num + 1];
            //Checker for alle mulighederne for 1 terning
            for (int i = 1; i <= 6; i++)
            {
                dp[1, i] = 1 / 6.0;
            }
            //For loop som er for 2 terninger
            for (int i = 2; i <= num; i++)
                //For loop som er for terninger og derop
                for (int j = i - 1; j <= 6 * (i - 1); j++)
                    for (int k = 1; k <= 6; k++)
                    {
                        dp[i, j + k] += (dp[i - 1, j] * dp[1, k]);
                    }

            for (int i = num; i <= 6 * num; i++)
            {
                if (desire == i)
                {
                    double value = (dp[num, i] * 100.00);
                    Console.WriteLine($"Samlede sum af {num} terninger er {i}. Muligheden for dette er {value:N3} %");
                }
            }
        }
    }
}
