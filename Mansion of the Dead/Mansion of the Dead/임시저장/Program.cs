using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Title(); // Title 화면 띄우기
        }
        struct Player
        {
            public string Name;
            public string Chap;
            public string Place;
            public int HP;
            public int ATK;
            public int DEF;
            public int SPD;
            public int AGI;
            public int HIT;
        }
        enum Monstertype
        {
            None = 0,
            Zombie = 1,
            HellHound = 2,
            Slasher = 3,
            SlingWorm = 4,
            Binder = 5,
            GigantHammer = 6,
            Shocker = 7,
            Slasher2 = 8,
            CrazyBee = 9,
            Queen = 10,
            GiantHammer2 = 11,
            Reaper = 12,
            Dimenter = 13
        }
        struct Monster
        {
            public string Name;
            public int HP;
            public int ATK;
            public int DEF;
            public int SPD;
            public int AGI;
            public int HIT;
        }
        static Player CreatePlayer()
        {
            Console.WriteLine("당신의 이름을 입력하세요.");
            string Name = Console.ReadLine();
            Player player = new Player();
            player.Name = Name;
            player.Place = "활주로";
            player.Chap = "0";
            player.HP = 200;
            player.ATK = 10;
            player.DEF = 10;
            player.SPD = 5;
            player.AGI = 10;
            player.HIT = 80;

            return player;
        }
        static void Title()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                  Endress Of Despair                                                 |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                     [1]게임시작                                                     |");
            Console.WriteLine("|                                                     [2]게임종료                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.Write("Key를 입력하세요. : ");
            string select0 = Console.ReadLine();

            Player player = new Player();
            if (select0 == "1")
            {
                player = CreatePlayer();
                int Chapter = 0;
                Console.WriteLine("게임시작"); //게임 시작

                switch (Chapter)
                {
                    case 0:
                        Console.WriteLine("Chapter.0 스토리"); //스토리 이벤트
                        MainMenu0(player); // 메인메뉴 접속
                        MainSelect0(player); // 선택지
                        break;
                    case 1:
                        Console.WriteLine("Chapter.1 스토리"); //스토리 이벤트
                        //MainMenu1(player);
                        break;
                    case 2:
                        Console.WriteLine("Chapter.2 스토리"); //스토리 이벤트
                        //MainMenu2(player);
                        break;
                    case 3:
                        Console.WriteLine("Chapter.3 스토리"); //스토리 이벤트
                        //MainMenu3(player);
                        break;
                }
            }
            else if (select0 == "2")
            {
                Console.WriteLine("게임을 종료합니다.");
            }
            else
            {
                Title();
            }
        }
        static void MainMenu0(Player player)
        {
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine($"Chapter : {player.Chap}");
            Console.WriteLine($"현재위치 : {player.Place}");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine($"이름 [{player.Name}]                장비");
            Console.WriteLine($"체력 [{player.HP}/200]            무기 : []");
            Console.WriteLine("                          머리 : []");
            Console.WriteLine("                          몸통 : []");
            Console.WriteLine("                          신발 : []");
            Console.WriteLine("");
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("");
        }
        static void MainSelect0(Player player)
        {
            Console.WriteLine("행동을 결정해 주세요.");
            Console.WriteLine("[1] 현재 지역을 탐색한다."); //전투 or 아이템 획득
            Console.WriteLine("[2] 다른 장소로 이동한다."); //맵 이동
            Console.WriteLine("[3] 아이템을 사용한다."); //아이템 사용
            Console.WriteLine("[4] 휴식을 취한다."); //체력 일부 회복
            string select0 = Console.ReadLine();
            switch (select0)
            {
                case "1":
                    Console.WriteLine("탐색을 진행합니다.");
                    Random rand = new Random();
                    int Randomout = rand.Next(1, 101);
                    if (Randomout <= 60)
                    {
                        Monster monster = new Monster();
                        RandomMonster0(monster);

                        Console.WriteLine("행동을 결정해주세요");
                        Console.WriteLine("[1]공격한다.");
                        Console.WriteLine("[2]아이템을 사용한다.");
                        Console.WriteLine("[3]도주한다");
                        string select1 = Console.ReadLine();

                        if (select1 == "1")
                        {
                            Console.WriteLine("공격");
                            BattleStart(ref player, ref monster);
                        }
                        else if (select1 == "2")
                        {
                            Console.WriteLine("아이템사용");
                        }
                        else
                        {
                            Console.WriteLine("도주");
                            MainMenu0(player);
                            MainSelect0(player);
                        }
                    }
                    else if (Randomout <= 80)
                    {
                        Console.WriteLine("아이템 획득");
                        MainMenu0(player);
                        MainSelect0(player);
                    }
                    else
                    {
                        Console.WriteLine("아무것도 찾지 못했습니다.");
                        MainMenu0(player);
                        MainSelect0(player);
                    }
                    break;
                case "2":
                    Console.WriteLine("어디로 이동합니까?");
                    Console.WriteLine("[1]터미널 3층");
                    Console.WriteLine("[2]터미널 2층");
                    Console.WriteLine("[3]터미널 1층");
                    Console.WriteLine("[4]공용주차장");
                    Console.WriteLine("[5]이동하지 않는다.");
                    string select2 = Console.ReadLine();
                    if (select2 == "1")
                    {
                        Console.WriteLine("이동");
                    }
                    if (select2 == "2")
                    {
                        Console.WriteLine("행동메뉴로");
                        MainMenu0(player);
                        MainSelect0(player);
                    }

                    break;
                case "3":
                    Console.WriteLine("어떤 아이템을 사용합니까?");
                    //이곳에 아이템 사용 추가
                    MainMenu0(player);
                    MainSelect0(player);
                    break;
                case "4":
                    Console.WriteLine("잠시 휴식을 취하여 체력을 회복합니다.");
                    player.HP += 20;
                    if (player.HP >= 200)
                    {
                        player.HP = 200;
                    }
                    MainMenu0(player);
                    MainSelect0(player);
                    break;
                default:
                    MainMenu0(player);
                    MainSelect0(player);
                    break;
            }
        }

        static void RandomMonster0(Monster monster)
        {
            Random rand = new Random();
            int RandomMonster = rand.Next(1, 3); //1~2 중 랜덤

            switch (RandomMonster)
            {
                case (int)Monstertype.Zombie:
                    Console.WriteLine("좀비가 나타났다.");
                    monster.Name = "좀비";
                    monster.HP = 50;
                    monster.ATK = 25;
                    monster.DEF = 10;
                    monster.SPD = 5;
                    monster.AGI = 10;
                    monster.HIT = 60;
                    break;
                case (int)Monstertype.HellHound:
                    Console.WriteLine("헬하운드가 나타났다.");
                    monster.Name = "헬하운드";
                    monster.HP = 50;
                    monster.ATK = 30;
                    monster.DEF = 15;
                    monster.SPD = 5;
                    monster.AGI = 10;
                    monster.HIT = 100;
                    break;
                default:
                    monster.HP = 0;
                    monster.ATK = 0;
                    monster.DEF = 0;
                    monster.SPD = 0;
                    monster.AGI = 0;
                    monster.HIT = 0;
                    break;
            }
        }
        static void BattleStart(ref Player player, ref Monster monster)
        {
            Console.WriteLine($"{player.Name}은(는) {monster.Name}을(를) 공격했다.");
            int ATK1 = player.ATK * 2;
            int DEF1 = monster.DEF;
            int Damage1 = ATK1 - DEF1;
            Console.WriteLine($"{monster.Name}에게 {Damage1}의 피해를 입혔다");
            monster.HP -= Damage1;
            if (monster.HP <= 0)
            {
                Console.WriteLine($"{monster.Name}에게 승리!");
            }
            Console.WriteLine($"{monster.Name}은(는) {player.Name}을(를) 공격했다.");
            int ATK2 = player.ATK * 2;
            int DEF2 = monster.DEF;
            int Damage2 = ATK2 - DEF2;
            Console.WriteLine($"{player.Name}은(는) {Damage2}의 피해를 입었다");
            if (player.HP <= 0)
            {
                Console.WriteLine($"{player.Name}은(는) 사망하였습니다!");
            }
        }
        static void ItemUse(Player player, Monster monster)
        {

        }
        static void Run()
        {

        }
        static void Getitem()
        {

        }
    }
}
