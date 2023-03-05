using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            battle();
        }
        static void battle()
        {
            Console.WriteLine("행동을 결정해주세요");
            Console.WriteLine("[1]공격한다.");
            Console.WriteLine("[2]아이템을 사용한다.");
            Console.WriteLine("[3]도주한다");
            string select = Console.ReadLine();
            switch (select)
            {
                case "1": //회피 확률 적용할것.
                    Console.WriteLine($"당신은(는) 좀비을(를) 공격했다.");
                    Console.WriteLine("");
                    int ATK1 = 10 * 2;
                    int DEF1 = 5;
                    int Damage1 = ATK1 - DEF1;
                    int MonsterHP = 100;
                    Console.WriteLine($"좀비에게 {Damage1}의 피해를 입혔다");
                    Console.WriteLine("");
                    MonsterHP -= Damage1;
                    if (MonsterHP <= 0)
                    {
                        Console.WriteLine($"좀비에게 승리!");
                        Console.WriteLine("");
                    }
                    Console.WriteLine($"당신은(는) 당신을(를) 공격했다.");
                    Console.WriteLine("");
                    int ATK2 = 15 * 2;
                    int DEF2 = 10;
                    int Damage2 = ATK2 - DEF2;
                    int PlayerHP = 200;
                    Console.WriteLine($"당신은(는) {Damage2}의 피해를 입었다");
                    Console.WriteLine("");
                    if (PlayerHP <= 0)
                    {
                        Console.WriteLine($"당신은(는) 사망하였습니다!");
                        Console.WriteLine("");
                    }
                    battle();
                    break;
                case "2":
                    Console.WriteLine($"아이템 사용!");

                    break;
                case "3":
                    Console.WriteLine($"무사히 도망쳤습니다!");
                    break;
            }
            return;
        }
    }
}
