using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA220111
{
    internal class Program
    {
        static Dictionary<string, Dictionary<DateTime, int>> sportagak = 
            new Dictionary<string, Dictionary<DateTime,int>>();
        static void Main()
        {
            F01();
            F02();
            F03();
            F04();
            F05();
            Console.ReadKey();
        }

        private static void F05()
        {

            int dsz = sportagak.Values.Sum(x => x.Values.Sum());
            Console.WriteLine($"5. feladat: \n\t{dsz} db aranyérmet osztottak ki az olimpián");

            #region algoval
            //int sum = 0;
            //foreach (var napokon in sportagak.Values)
            //{
            //    foreach(var donto in napokon.Values)
            //    {
            //        sum += donto;
            //    }
            //}
            //Console.WriteLine($"output {sum}");
            #endregion
        }

        private static void F04()
        {
            var m = new Dictionary<DateTime, int>();
            foreach (var napok in sportagak.Values)
            {
                foreach (var nap in napok)
                {
                    if(!m.ContainsKey(nap.Key))
                        m.Add(nap.Key, nap.Value);
                    else
                        m[nap.Key] += nap.Value;
                }
            }

            var ld = m.OrderBy(x => x.Value).Last();
            Console.WriteLine($"4. feladat:\n\tA legtöbb döntő ({ld.Value} db) {ld.Key.ToString("dd.")}-án/én volt.");
        }

        private static void F03()
        {
            var aszu = sportagak["Úszás"].Sum(x => x.Value);
            Console.WriteLine($"3. feladat:\n\tAranyérmek száma úszás sportágban: {aszu} db");
        }

        private static void F02()
        {
            var adsz = sportagak["Atlétika"].Count(x => x.Value != 0);
            Console.WriteLine($"2. feladat:\n\tDöntős napok száma atlétika sportágban {adsz} db");
        }

        private static void F01()
        {
            using (var sr = new StreamReader(@"..\..\res\London2012.txt", Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    var v = sr.ReadLine().Split(';');
                    sportagak.Add(v[0], new Dictionary<DateTime, int>());

                    var datum = new DateTime(2012, 07, 28);

                    for (int i = 1; i <= 16; i++)
                    {
                        sportagak[v[0]].Add(datum, int.Parse(v[i]));
                        datum = datum.AddDays(1);
                    }

                    #region tisztázás előtt
                    //int vIndex = 1;
                    //for (var d = new DateTime(2012, 07, 28);
                    //    d <= new DateTime(2012, 08, 12);
                    //    d = d.AddDays(1))
                    //{
                    //    sportagak[v[0]].Add(d, int.Parse(v[vIndex]));
                    //    vIndex++;
                    //}
                    #endregion
                }
            }
        }
    }
}
