using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroVsGhost1
{
    class Program
    {
        private static List<string> result = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("begin!!!");
            Console.WriteLine("hero: 2 farmers 4 archers!");
            Console.WriteLine("ghost: not Attack!");
            Console.WriteLine("status: f1->0 f2->0 a1->0 a2->0 ga->1 go->0 wb->3");

            Hero h = new Hero();
            h.archers = 4;
            h.farmers = 2;
            h.heros = 1;

            Ghost g = new Ghost();
            g.isAttack = false;

            Status s = new Status();
            s.Archer1Num = 0;
            s.Archer2Num = 0;
            s.Farmer1Num = 0;
            s.Farmer2Num = 0;
            s.GhostAttack = 1;
            s.GhostNotAttack = 0;
            s.WallBlood = 3;

            HeroVsGhost(h, g, s);

            if (s.WallBlood >= 10)
            {
                Console.WriteLine("Result:");
                for (int i = 0; i < result.Count; i++)
                {                    
                    Console.Write(result[i]);
                    Console.Write("->");
                }
            }
            Console.ReadLine();
        }

        public static void HeroVsGhost(Hero h,Ghost g,Status s)
        {
            System.Threading.Thread.Sleep(2 * 1000);

            if (s.WallBlood < 10 && h.farmers > 0)
            {
                MoveA(h, g, s);
            }

            if (s.WallBlood < 10 && h.archers > 0)
            {
                MoveB(h, g, s);
            }

            MoveC(h, g, s);            
        }

        public static void MoveA(Hero h, Ghost g, Status s)  // farmer attack
        {
            if (h.farmers <= 0 || s.WallBlood >=10)
            {
                return;
            }

            Hero ch = new Hero();
            ch.archers = h.archers;
            ch.farmers = h.farmers;
            ch.heros = h.heros;

            Ghost cg = new Ghost();
            cg.isAttack = g.isAttack;

            Status cs = new Status();
            cs.Archer1Num = s.Archer1Num;
            cs.Archer2Num = s.Archer2Num;
            cs.Farmer1Num = s.Farmer1Num;
            cs.Farmer2Num = s.Farmer2Num;
            cs.GhostAttack = s.GhostAttack;
            cs.GhostNotAttack = s.GhostNotAttack;
            cs.WallBlood = s.WallBlood;

            h.farmers -= 1;
            s.Farmer2Num += 1;
            s.WallBlood += (s.Farmer2Num + s.Farmer1Num);

            Console.WriteLine("farmer attack!");
            Console.WriteLine("hero: " + h.farmers.ToString() + " farmers " + h.archers + " archers!");
            Console.WriteLine("status: f1->" + s.Farmer1Num + " f2->" + s.Farmer2Num + " a1->" + s.Archer1Num + " a2->" + s.Archer2Num + " ga->" + s.GhostAttack + " go->" + s.GhostNotAttack + " wb->" + s.WallBlood);

            result.Add("farmer");

            if (s.WallBlood >= 10)
            {
                return;
            }

            if (g.isAttack)
            {
                s.GhostAttack += 1;
            }
            else
            {
                s.GhostNotAttack += 1;
            }

            CalculateGhostAttack(g, s);
            g.isAttack = !g.isAttack;

            Console.WriteLine("ghost attack!");
            Console.WriteLine("hero: " + h.farmers.ToString() + " farmers " + h.archers + " archers!");
            Console.WriteLine("status: f1->" + s.Farmer1Num + " f2->" + s.Farmer2Num + " a1->" + s.Archer1Num + " a2->" + s.Archer2Num + " ga->" + s.GhostAttack + " go->" + s.GhostNotAttack + " wb->" + s.WallBlood);


            if (s.WallBlood <= 0)
            {
                h.archers = ch.archers;
                h.farmers = ch.farmers;
                h.heros = ch.heros;

                g.isAttack = cg.isAttack;

                s.Archer1Num = cs.Archer1Num;
                s.Archer2Num = cs.Archer2Num;
                s.Farmer1Num = cs.Farmer1Num;
                s.Farmer2Num = cs.Farmer2Num;
                s.GhostAttack = cs.GhostAttack;
                s.GhostNotAttack = cs.GhostNotAttack;
                s.WallBlood = cs.WallBlood;

                Console.WriteLine("failed!return to last step!");
                Console.WriteLine("hero: " + h.farmers.ToString() + " farmers " + h.archers + " archers!");
                Console.WriteLine("status: f1->" + s.Farmer1Num + " f2->" + s.Farmer2Num + " a1->" + s.Archer1Num + " a2->" + s.Archer2Num + " ga->" + s.GhostAttack + " go->" + s.GhostNotAttack + " wb->" + s.WallBlood);

                result.Remove(result[result.Count - 1]);

                return;
            }

            HeroVsGhost(h, g, s);

            h.archers = ch.archers;
            h.farmers = ch.farmers;
            h.heros = ch.heros;

            g.isAttack = cg.isAttack;

            s.Archer1Num = cs.Archer1Num;
            s.Archer2Num = cs.Archer2Num;
            s.Farmer1Num = cs.Farmer1Num;
            s.Farmer2Num = cs.Farmer2Num;
            s.GhostAttack = cs.GhostAttack;
            s.GhostNotAttack = cs.GhostNotAttack;
            s.WallBlood = cs.WallBlood;

            Console.WriteLine("failed!return to last step!");
            Console.WriteLine("hero: " + h.farmers.ToString() + " farmers " + h.archers + " archers!");
            Console.WriteLine("status: f1->" + s.Farmer1Num + " f2->" + s.Farmer2Num + " a1->" + s.Archer1Num + " a2->" + s.Archer2Num + " ga->" + s.GhostAttack + " go->" + s.GhostNotAttack + " wb->" + s.WallBlood);
            result.Remove(result[result.Count - 1]);
        }

        public static void MoveB(Hero h, Ghost g, Status s)  // archer attack
        {
            if (h.archers <= 0 || s.WallBlood >= 10)
            {
                return;
            }

            Hero ch = new Hero();
            ch.archers = h.archers;
            ch.farmers = h.farmers;
            ch.heros = h.heros;

            Ghost cg = new Ghost();
            cg.isAttack = g.isAttack;

            Status cs = new Status();
            cs.Archer1Num = s.Archer1Num;
            cs.Archer2Num = s.Archer2Num;
            cs.Farmer1Num = s.Farmer1Num;
            cs.Farmer2Num = s.Farmer2Num;
            cs.GhostAttack = s.GhostAttack;
            cs.GhostNotAttack = s.GhostNotAttack;
            cs.WallBlood = s.WallBlood;

            h.archers -= 1;
            s.Archer2Num += 1;
            CalculateArcherAttack(s, g);

            result.Add("archer");

            Console.WriteLine("archer attack!");
            Console.WriteLine("hero: " + h.farmers.ToString() + " farmers " + h.archers + " archers!");
            Console.WriteLine("status: f1->" + s.Farmer1Num + " f2->" + s.Farmer2Num + " a1->" + s.Archer1Num + " a2->" + s.Archer2Num + " ga->" + s.GhostAttack + " go->" + s.GhostNotAttack + " wb->" + s.WallBlood);


            if (g.isAttack)
            {
                s.GhostAttack += 1;
            }
            else
            {
                s.GhostNotAttack += 1;
            }

            CalculateGhostAttack(g, s);
            g.isAttack = !g.isAttack;

            Console.WriteLine("ghost attack!");
            Console.WriteLine("hero: " + h.farmers.ToString() + " farmers " + h.archers + " archers!");
            Console.WriteLine("status: f1->" + s.Farmer1Num + " f2->" + s.Farmer2Num + " a1->" + s.Archer1Num + " a2->" + s.Archer2Num + " ga->" + s.GhostAttack + " go->" + s.GhostNotAttack + " wb->" + s.WallBlood);


            if (s.WallBlood <= 0)
            {
                h.archers = ch.archers;
                h.farmers = ch.farmers;
                h.heros = ch.heros;

                g.isAttack = cg.isAttack;

                s.Archer1Num = cs.Archer1Num;
                s.Archer2Num = cs.Archer2Num;
                s.Farmer1Num = cs.Farmer1Num;
                s.Farmer2Num = cs.Farmer2Num;
                s.GhostAttack = cs.GhostAttack;
                s.GhostNotAttack = cs.GhostNotAttack;
                s.WallBlood = cs.WallBlood;

                Console.WriteLine("failed!return to last step!");
                Console.WriteLine("hero: " + h.farmers.ToString() + " farmers " + h.archers + " archers!");
                Console.WriteLine("status: f1->" + s.Farmer1Num + " f2->" + s.Farmer2Num + " a1->" + s.Archer1Num + " a2->" + s.Archer2Num + " ga->" + s.GhostAttack + " go->" + s.GhostNotAttack + " wb->" + s.WallBlood);
                result.Remove(result[result.Count - 1]);
                return;
            }

            HeroVsGhost(h, g, s);

            h.archers = ch.archers;
            h.farmers = ch.farmers;
            h.heros = ch.heros;

            g.isAttack = cg.isAttack;

            s.Archer1Num = cs.Archer1Num;
            s.Archer2Num = cs.Archer2Num;
            s.Farmer1Num = cs.Farmer1Num;
            s.Farmer2Num = cs.Farmer2Num;
            s.GhostAttack = cs.GhostAttack;
            s.GhostNotAttack = cs.GhostNotAttack;
            s.WallBlood = cs.WallBlood;

            Console.WriteLine("failed!return to last step!");
            Console.WriteLine("hero: " + h.farmers.ToString() + " farmers " + h.archers + " archers!");
            Console.WriteLine("status: f1->" + s.Farmer1Num + " f2->" + s.Farmer2Num + " a1->" + s.Archer1Num + " a2->" + s.Archer2Num + " ga->" + s.GhostAttack + " go->" + s.GhostNotAttack + " wb->" + s.WallBlood);
            result.Remove(result[result.Count - 1]);
        }

        public static void MoveC(Hero h, Ghost g, Status s)  // hero attack
        {
            if (s.WallBlood >= 10)
            {
                return;
            }

            Hero ch = new Hero();
            ch.archers = h.archers;
            ch.farmers = h.farmers;
            ch.heros = h.heros;

            Ghost cg = new Ghost();
            cg.isAttack = g.isAttack;

            Status cs = new Status();
            cs.Archer1Num = s.Archer1Num;
            cs.Archer2Num = s.Archer2Num;
            cs.Farmer1Num = s.Farmer1Num;
            cs.Farmer2Num = s.Farmer2Num;
            cs.GhostAttack = s.GhostAttack;
            cs.GhostNotAttack = s.GhostNotAttack;
            cs.WallBlood = s.WallBlood;

            h.farmers += (s.Archer1Num + s.Archer2Num);
            h.archers += (s.Farmer1Num + s.Farmer2Num);
            s.Farmer1Num = 0;
            s.Farmer2Num = 0;
            s.Archer1Num = 0;
            s.Archer2Num = 0;
            s.WallBlood += 1;

            result.Add("hero");

            Console.WriteLine("hero attack!");
            Console.WriteLine("hero: " + h.farmers.ToString() + " farmers " + h.archers + " archers!");
            Console.WriteLine("status: f1->" + s.Farmer1Num + " f2->" + s.Farmer2Num + " a1->" + s.Archer1Num + " a2->" + s.Archer2Num + " ga->" + s.GhostAttack + " go->" + s.GhostNotAttack + " wb->" + s.WallBlood);


            if (s.WallBlood >= 10)
            {
                return;
            }

            if (g.isAttack)
            {
                s.GhostAttack += 1;
            }
            else
            {
                s.GhostNotAttack += 1;
            }

            CalculateGhostAttack(g, s);
            g.isAttack = !g.isAttack;
            
            Console.WriteLine("ghost attack!");
            Console.WriteLine("hero: " + h.farmers.ToString() + " farmers " + h.archers + " archers!");
            Console.WriteLine("status: f1->" + s.Farmer1Num + " f2->" + s.Farmer2Num + " a1->" + s.Archer1Num + " a2->" + s.Archer2Num + " ga->" + s.GhostAttack + " go->" + s.GhostNotAttack + " wb->" + s.WallBlood);


            if (s.WallBlood <= 0)
            {
                h.archers = ch.archers;
                h.farmers = ch.farmers;
                h.heros = ch.heros;

                g.isAttack = cg.isAttack;

                s.Archer1Num = cs.Archer1Num;
                s.Archer2Num = cs.Archer2Num;
                s.Farmer1Num = cs.Farmer1Num;
                s.Farmer2Num = cs.Farmer2Num;
                s.GhostAttack = cs.GhostAttack;
                s.GhostNotAttack = cs.GhostNotAttack;
                s.WallBlood = cs.WallBlood;

                Console.WriteLine("failed!return to last step!");
                Console.WriteLine("hero: " + h.farmers.ToString() + " farmers " + h.archers + " archers!");
                Console.WriteLine("status: f1->" + s.Farmer1Num + " f2->" + s.Farmer2Num + " a1->" + s.Archer1Num + " a2->" + s.Archer2Num + " ga->" + s.GhostAttack + " go->" + s.GhostNotAttack + " wb->" + s.WallBlood);
                result.Remove(result[result.Count - 1]);
                return;
            }

            HeroVsGhost(h, g, s);

            h.archers = ch.archers;
            h.farmers = ch.farmers;
            h.heros = ch.heros;

            g.isAttack = cg.isAttack;

            s.Archer1Num = cs.Archer1Num;
            s.Archer2Num = cs.Archer2Num;
            s.Farmer1Num = cs.Farmer1Num;
            s.Farmer2Num = cs.Farmer2Num;
            s.GhostAttack = cs.GhostAttack;
            s.GhostNotAttack = cs.GhostNotAttack;
            s.WallBlood = cs.WallBlood;

            Console.WriteLine("failed!return to last step!");
            Console.WriteLine("hero: " + h.farmers.ToString() + " farmers " + h.archers + " archers!");
            Console.WriteLine("status: f1->" + s.Farmer1Num + " f2->" + s.Farmer2Num + " a1->" + s.Archer1Num + " a2->" + s.Archer2Num + " ga->" + s.GhostAttack + " go->" + s.GhostNotAttack + " wb->" + s.WallBlood);
            result.Remove(result[result.Count - 1]);
        }

        public static void CalculateGhostAttack(Ghost g, Status s)
        {
            if (s.GhostAttack >= 3 || s.GhostNotAttack >= 3)
            {
                s.WallBlood = 0;
                return;
            }

            if (g.isAttack)
            {
                if(s.Farmer1Num > 0)
                {
                    s.Farmer1Num -= 1;
                }
                else if(s.Archer1Num > 0)
                {
                    s.Archer1Num -= 1;
                }
                else if(s.Farmer2Num >= s.Archer2Num && s.Farmer2Num > 0)
                {
                    s.Farmer2Num -= 1;
                    s.Farmer1Num += 1;
                }
                else if(s.Archer2Num >= s.Farmer2Num && s.Archer2Num >0)
                {
                    s.Archer2Num -= 1;
                    s.Archer1Num += 1;
                }
            }
            else
            {
                s.WallBlood -= 1;
            }
        }

        private static void CalculateArcherAttack(Status s,Ghost g)
        {
            for (int i = 0; i < s.Archer1Num + s.Archer2Num; i++)
            {
                if (s.GhostAttack > s.GhostNotAttack && s.GhostAttack > 0)
                {
                    s.GhostAttack -= 1;
                }
                else if (s.GhostNotAttack > s.GhostAttack && s.GhostNotAttack > 0)
                {
                    s.GhostNotAttack -= 1;
                }
                else if (s.GhostNotAttack == s.GhostAttack)
                {
                    if (g.isAttack)
                    {
                        s.GhostAttack = s.GhostAttack > 1 ? s.GhostAttack - 1 : 0;
                    }
                    else
                    {
                        s.GhostNotAttack = s.GhostNotAttack > 1 ? s.GhostNotAttack - 1 : 0;
                    }
                }
            }
        }
    }
}
