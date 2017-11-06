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
                for (int i = 0; i < result.Count; i++)
                {
                    Console.Write(result[i]);
                    Console.Write("->");
                }
            }
        }

        public static void HeroVsGhost(Hero h,Ghost g,Status s)
        {
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
            if (h.farmers <= 0)
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
        }

        public static void MoveB(Hero h, Ghost g, Status s)  // archer attack
        {
            if (h.archers <= 0)
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
            CalculateArcherAttack(s);

            result.Add("archer");
            
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
        }

        public static void MoveC(Hero h, Ghost g, Status s)  // hero attack
        {
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
        }

        public static void CalculateGhostAttack(Ghost g, Status s)
        { }

        private static void CalculateArcherAttack(Status s)
        {
            throw new NotImplementedException();
        }
    }
}
