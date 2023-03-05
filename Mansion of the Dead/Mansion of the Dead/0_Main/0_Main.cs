using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Main
{
    class Program
    {
        struct Player
        {
            public string Name;
            public int Chap;
            public int Stage;
            public string Place;
            public int HP;
            public int ATK;
            public int DEF;
            public int SPD;
            public int AGI;
            public int HIT;
            public int Potion1;
            public int Potion2;
            public int Potion3;
            public int bomb;
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
        static void Main(string[] args)
        {
            MainMenu();
        }
        static void MainMenu()
        {
            Title(); // Title 화면 띄우기
            Console.Write("Key를 입력하세요. : ");
            string select0 = Console.ReadLine();
            if (select0 == "1")
            {
                Player player = new Player();
                player = CreatePlayer();
                Console.Clear();
                Chapter0(ref player);
                SubMenu0(ref player);

            }
            else if (select0 == "2")
            {
                Console.WriteLine("게임 종료");
            }
            else
            {
                MainMenu();
            }
        }
        static void Title()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                                                                                     |");
            Console.WriteLine("|                                                 Mansion of the Dead                                                 |");
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
        }
        static Player CreatePlayer()
        {
            Player player = new Player();
            Console.WriteLine("당신의 이름을 입력하세요.");
            player.Name = Console.ReadLine();
            player.HP = 200;
            player.ATK = 20;
            player.DEF = 10;
            player.SPD = 5;
            player.AGI = 10;
            player.HIT = 100;
            player.Potion1 = 2;
            player.Potion2 = 0;
            player.Potion3 = 0;
            player.bomb = 0;
            player.Chap = 1;
            player.Stage = 1;
            player.Place = "1층 복도";
            return player;
        }
        //스테이지 관련
        static void SubMenu0(ref Player player)
        {
            switch (player.Chap)
            {
                case 1:
                    if(player.Stage <= 5)
                    {
                        Console.Clear();
                        SubMenu1(ref player);
                    }
                    else if(player.Stage == 6)
                    {
                        Console.Clear();
                        player.Stage++;
                        Chapter1_1(ref player);
                    }
                    else if(player.Stage == 7)
                    {
                        Console.Clear();
                        SubMenu1(ref player);
                    }
                    else if(player.Stage == 8)
                    {
                        Chapter1_2(ref player);
                        Monster monster;
                        Bossmonster1(out monster);
                        BossBattle1F(ref player, ref monster);
                    }
                    else if(player.Stage == 9)
                    {
                        Chapter1_3(ref player);
                    }
                    break;
                case 2:
                    //SubMenu2(ref player);
                    break;
                case 3:
                    //SubMenu3(ref player);
                    break;
            }
                
        }
        static void SubMenu1(ref Player player)
        {
            Map01();
            Console.WriteLine($"현재 위치는 {player.Place}입니다.");
            Console.WriteLine("행동을 결정하세요");
            Console.WriteLine("[1] 이동한다."); // 맵 이동
            Console.WriteLine("[2] 조사한다."); // 전투 or 아이템 획득
            Console.WriteLine("[3] 아이템을 사용한다."); // 
            Console.WriteLine("[4] 능력치를 본다.");
            string Subselect = Console.ReadLine();
            switch (Subselect)
            {
                case "1":
                    Move1F Move = new Move1F();
                    Move.input(ref player);
                    break;
                case "2":
                    Console.WriteLine($"{player.Name}은(는) 주변을 조사했다.");
                    Console.WriteLine("");
                    Console.ReadLine();
                    Random rand = new Random();
                    int randout = rand.Next(1, 100);
                    if (randout <= 60)
                    {
                        Monster monster;
                        Randommonster1(out monster);  // 랜덤 몬스터 등장
                        Battle(ref player, ref monster);  // 전투
                    }
                    else if (randout <= 80)
                    {
                        GetItem(ref player); // 아이템 획득
                    }
                    else
                    {
                        Console.WriteLine($"{player.Name}은(는) 아무것도 발견하지 못했다.");
                        Console.WriteLine("");
                        Console.ReadLine();
                        Console.Clear();
                        SubMenu0(ref player);
                    }
                    break;
                case "3":
                    Inventory(ref player);
                    break;
                case "4":
                    Status(ref player);
                    break;
                default:
                    Console.Clear();
                    SubMenu0(ref player);
                    break;
            }
        }
        //맵 생성
        static void Map01()
        {
            
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■"); //1
            Console.WriteLine("■      ■                ■            ■                    ■"); //2
            Console.WriteLine("■ 계단 ■      ???       ■   관리실   ■        창고        ■"); //3
            Console.WriteLine("■      ■                ■            ■                    ■"); //4
            Console.WriteLine("■      ■■■■■■■■■■■■    ■■■■    ■■■■■■■■"); //5
            Console.WriteLine("■                                                            ■"); //6
            Console.WriteLine("■                                                            ■"); //7
            Console.WriteLine("■■■■■■■■■■■■                ■■■■■■■■■■■■"); //8
            Console.WriteLine("■                    ■                ■                    ■"); //9
            Console.WriteLine("■                    ■                         객실 1       ■"); //10
            Console.WriteLine("■                    ■                                      ■"); //11
            Console.WriteLine("■        주방                          ■                    ■"); //12
            Console.WriteLine("■                    ■                ■■■■■■■■■■■■"); //13
            Console.WriteLine("■                    ■      1층       ■                    ■"); //14
            Console.WriteLine("■                    ■      복도               객실 2       ■"); //15
            Console.WriteLine("■■■■■    ■■■■■                                      ■"); //16
            Console.WriteLine("■                    ■                ■                    ■"); //17
            Console.WriteLine("■                    ■                ■■■■■■■■■■■■"); //18
            Console.WriteLine("■                    ■                ■  여자  ■■  남자  ■"); //19
            Console.WriteLine("■        식당                          ■ 화장실 ■■ 화장실 ■"); //20
            Console.WriteLine("■                                      ■        ■■        ■"); //21
            Console.WriteLine("■                    ■                ■■    ■■■■    ■■"); //22
            Console.WriteLine("■                    ■                                      ■"); //23
            Console.WriteLine("■                    ■                                      ■"); //24
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■"); //25
        }
        static void Map02()
        {
            
        }
        //스토리 관련
        static void Chapter0(ref Player player)
        {
            Console.Clear();
            Console.WriteLine("이 게임은 픽션이며 등장하는 인물과 단체, 지명 등은 실존하는 것과 일체 관계가 없습니다. ");
            Console.ReadLine();
            Console.WriteLine("게임 플레이에 참고해주시기 바랍니다.");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("2080년 8월");
            Console.ReadLine();
            Console.WriteLine("어느 저택으로부터 초대를 받은 사람들이 언제부터인가 연락이 되지 않는다는 신고가 들어와 우리 경찰서는 조사에 나섰다.");
            Console.ReadLine();
            Console.WriteLine("실종자는 주로 과학자들이었으며, 일부는 정치인, 연예인, 군인 등도 포함되어 있는 듯 했다.");
            Console.ReadLine();
            Console.WriteLine("[닉]그나저나 음침한 곳이로군. 누가 이런 곳에 저택따위를 지은거야?");
            Console.ReadLine();
            Console.WriteLine("왼손으로 운전대를 잡고 운전 중인 있는 닉은 오른손으로는 엉덩이를 붙잡고 칭얼거렸다.");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]그러게 말이야");
            Console.ReadLine();
            Console.WriteLine("거친 산길을 달리는 차는 잠시도 얌전할 틈도 없었다. 도대체 어떻게 찾아오라는 건지 길은 제대로된 정비가 되어있지 않았다.");
            Console.ReadLine();
            Console.WriteLine("[닉]슬슬 보이는거 같은데?");
            Console.ReadLine();
            Console.WriteLine("닉은 턱으로 앞을 가르키며 말했다. 닉이 가르킨 곳에는 30명은 거뜬히 살만한 거대한 저택이 자리잡고 있었다.");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]그래도 과속은 하지 말라고.");
            Console.ReadLine();
            Console.WriteLine("[닉]분부대로 하죠.");
            Console.ReadLine();
            Console.WriteLine("닉은 가볍게 웃어넘기며 있는 힘껏 엑셀을 밟았다.");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("10여분 뒤......");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]고맙군 닉. 덕분에 엉덩이가 남아나질 않겠어.");
            Console.ReadLine();
            Console.WriteLine("[닉]이런 곳에 보낼거면 시트라도 바꿔줬으면 좋았을텐데 말이야.");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]잘도 그렇게 해주겠다.");
            Console.ReadLine();
            Console.WriteLine("[닉]해본 소리야. 일단 가자고.");
            Console.ReadLine();
            Console.WriteLine("차에서 내린 우리는 거대한 저택의 입구에 섰다.");
            Console.ReadLine();
            Console.WriteLine("[닉]장관이군 그래.");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]아직 불이 켜져 있는 곳들이 있는 걸 보니 사람은 있는거 같은데?");
            Console.ReadLine();
            Console.WriteLine("[닉]그런것 치고는 굉장히 조용하지만 말이야.");
            Console.ReadLine();
            Console.WriteLine("나는 현관에 다가서서 초인종을 눌렀다.");
            Console.ReadLine();
            Console.WriteLine("딩~동!");
            Console.ReadLine();
            Console.WriteLine("초인종 소리 외에는 아무런 반응이 없다.");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]아무도 없을리....는 없을테고 역시 저택이 넓으니 나오는데 시간이 오래 걸리나?");
            Console.ReadLine();
            Console.WriteLine("아무리 기다려도 누구도 나타나지 않았다.");
            Console.ReadLine();
            Console.WriteLine("[닉]좀 빨리 나오지. 빨리 처리하고 가족들이랑 여행갈 준비해야한단 말이야.");
            Console.ReadLine();
            Console.WriteLine("닉은 짜증을 부리며 문 손잡이를 마구잡이로 돌렸다.");
            Console.ReadLine();
            Console.WriteLine("철컥!");
            Console.ReadLine();
            Console.WriteLine("[닉]어?");
            Console.ReadLine();
            Console.WriteLine("잠겨있는줄 알았던 문은 그냥 열려있었다.");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]뭔가 이상한데?");
            Console.ReadLine();
            Console.WriteLine("[닉]열렸으면 된거지. 뭐 어때?");
            Console.ReadLine();
            Console.WriteLine("현관 홀에 들어서자 분위기가 굉장히 이상했다.");
            Console.ReadLine();
            Console.WriteLine("아무것도 보이지 않을 정도로 어둡지는 않았지만 높은 샹들리에에서 나오는 불빛은 그다지 환하지 않았다.");
            Console.ReadLine();
            Console.WriteLine("[닉]늦은 저녁이라 불을 약하게 해둔건가?");
            Console.ReadLine();
            Console.WriteLine("[닉]일단 무슨일이 일어날지 모르니까 조심하고 우선 나눠서 사람을 찾아보자.");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]그럼 이따가 여기 '1층복도'에서 다시 모이는 걸로 하지.");
            Console.ReadLine();
            Console.Clear();
        }
        static void Chapter1_1(ref Player player)
        {
            Console.Clear();
            player.Place = "1층 복도";
            Console.WriteLine("닉과 약속한 시간이 되어 나는 1층 복도로 이동했다.");
            Console.ReadLine();
            Console.WriteLine("닉은 아직 도착하지 않은 듯 했다.");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]금방 오겠지......");
            Console.ReadLine();
            Console.WriteLine("탕! 탕!");
            Console.ReadLine();
            Console.WriteLine("라고 생각한 순간 계단 쪽 복도로부터 총성과 함께 닉이 급하게 뛰쳐나왔다.");
            Console.ReadLine();
            Console.WriteLine("[닉]X발! 저건 또 뭐야?");
            Console.ReadLine();
            Console.WriteLine("닉은 뒤쫒아오는 개의 형체를 한 괴물에게 쫒기고 있었다.");
            Console.ReadLine();
            Console.WriteLine("이윽고 괴물이 닉을 공격하기 위해 높이 뛴 순간 나는 괴물의 머리를 향해 내가 지닌 권총을 발포했다.");
            Console.ReadLine();
            Console.WriteLine("탕!");
            Console.ReadLine();
            Console.WriteLine("탄환은 정확하게 괴물의 인중에 명중하였고 괴물은 그대로 복도에 떨어졌다.");
            Console.ReadLine();
            Console.WriteLine("[닉]죽은 거야?");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]모르겠으니 확인해봐야지.");
            Console.ReadLine();
            Console.WriteLine("우리는 바닥에 널부러져있는 괴물에게 조심스레 다가갔다.");
            Console.ReadLine();
            Console.WriteLine("만약을 위해 닉이 주변을 경계하고 나도 총구를 괴물에게 향한채 다가갔다.");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]죽은 거 같은데?");
            Console.ReadLine();
            Console.WriteLine("[닉]왜 이런 곳에 이런 괴물이 있는 건데!");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]일단 서에 연락하자. 우리 둘만으로는 힘들 지도 몰라.");
            Console.ReadLine();
            Console.WriteLine("[닉]그래");
            Console.ReadLine();
            Console.WriteLine("닉은 기겁한 채로 현관문으로 향했다.");
            Console.ReadLine();
            Console.WriteLine("철컹!");
            Console.ReadLine();
            Console.WriteLine("[닉]어라?");
            Console.ReadLine();
            Console.WriteLine("문을 열고 나가려던 닉에게 이상함을 보았다.");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]무슨 일이야, 닉?");
            Console.ReadLine();
            Console.WriteLine("[닉]문이 안열리는데?");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]그럴리가? 우리가 들어올 때는 열려있었잖아? 들어오면서 잠궜어?");
            Console.ReadLine();
            Console.WriteLine("[닉]그럴리가? 난 잠그지 않았어!");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]젠장. 다른 곳으로 나갈 곳이 없나 찾아보자.");
            Console.ReadLine();
            Console.WriteLine("[닉]알겠어.");
            Console.ReadLine();
            Console.WriteLine("우리는 주변을 다시 조사해보았지만 창문조차도 특수하게 제작되었는지 가구로 때려보아도 긁힘자국 하나 나지 않았다.");
            Console.ReadLine();
            Console.WriteLine("[닉]1층은 한 군데 빼고는 다 뒤져본것 같군. 저기 방 하나만 열쇠로 잠겨져 있어서 들어갈 수가 없어. 2층으로 가봐야 할 것 같아.");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]2층으로 가는 계단도 철창으로 막혀져 있던데? 아예 열쇠를 찾아봐야 할 것 같네.");
            Console.ReadLine();
            Console.WriteLine("[닉]그럼 다시 나눠져서 찾자. 그게 빠를거야.");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]그래. 대신 조심해. 또 녀석들이 나오면 머리를 쏴버려.");
            Console.ReadLine();
            Console.WriteLine("[닉]O.K.");
            Console.ReadLine();
            SubMenu0(ref player);
        }
        static void Chapter1_2(ref Player player)
        {
            Console.Clear();
            Console.WriteLine($"[{player.Name}]닉! 뭔가 열쇠를 찾았어! 이쪽으로 와봐!.");
            Console.ReadLine();
            Console.WriteLine("열쇠를 찾은 나는 어딘가에 있을 닉을 찾았다.");
            Console.ReadLine();
            Console.WriteLine("식당도 주방도 다른곳도 뒤져보았지만 닉의 모습은 보이지 않았다.");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]이 놈 도대체 어디로 간거야?");
            Console.ReadLine();
            Console.WriteLine("혹시나 2층으로 가는 계단 쪽에 있지 않을까 싶어 그쪽으로 방향을 돌렸다.");
            Console.ReadLine();
            Console.WriteLine("넓은 저택이라 그런지 1층만 돌아다니는 데에도 꽤나 시간이 걸린다.");
            Console.ReadLine();
            Console.WriteLine("이윽고 계단으로 올라가는 철창에 다다른 나는 믿을 수 없는 광경을 보았다.");
            Console.ReadLine();
            Console.WriteLine("양 팔이 거대한 칼날과 같이 날카롭게 변해버린 닉의 모습이었다.");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]닉! 그 모습은 대체?");
            Console.ReadLine();
            Console.WriteLine($"[닉]이봐 {player.Name}... 내 몸... 도대체 어떻게 된거야?");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]내가 하고 싶은 말이라고! 대체 왜 니가!");
            Console.ReadLine();
            Console.WriteLine("[닉]무서워... 도와줘... 제발.......");
            Console.ReadLine();
            Console.WriteLine("두려움에 떨고 있는 닉의 눈동자는 조금씩 희미해지며 충혈된 듯 점점 붉게 물들어갔다.");
            Console.ReadLine();
            Console.WriteLine("그리고 결국 남은 이성마저 사라진 닉은 날카로운 손을 내게 들이댄다.");
            Console.ReadLine();
        }
        static void Chapter1_3(ref Player player)
        {
            Console.WriteLine("괴물로 변한 닉은 결국 쓰러졌다.");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]닉......");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]임무가 끝나면 오랜만에 가족들과 함께 여행간다는 녀석이 가족을 내팽겨치고 혼자 떠나버리다니......");
            Console.ReadLine();
            Console.WriteLine("동료를 잃었다. 파트너가 되어 함께 일한지 고작 2년 밖에 되지 않은 시간이었지만, 동료애가 생기기에는 충분한 기간이었다.");
            Console.ReadLine();
            Console.WriteLine("이런 정체모를 저택에서 적어도 인간다운 모습으로도 죽지 못한 닉의 명복을 빌며 반드시 이 사건을 해결해보이겠다는 다짐을 한 나는");
            Console.ReadLine();
            Console.WriteLine("2층으로 향하는 계단 앞에 섰다.");
            Console.ReadLine();
            Console.WriteLine($"[{player.Name}]가자고 파트너. 지금도 난 너와 함께다.");
            Console.ReadLine();
            Console.WriteLine("나는 철창문에 열쇠를 꽃아 굳게 닫혀 있던 철창을 개방했다.");
            Console.ReadLine();
            Console.WriteLine("Chapter.1 Clear!!!");
            Console.Clear();
        }
        //전투
        static void Randommonster1(out Monster monster)
        {
            Random rand = new Random();
            int randmon = rand.Next(1,3);

            switch(randmon)
            {
                case (int)Monstertype.Zombie:
                    Console.WriteLine("좀비가 나타났다.");
                    Console.WriteLine("");
                    Console.ReadLine();
                    monster.Name = "좀비";
                    monster.HP = 50;
                    monster.ATK = 20;
                    monster.DEF = 10;
                    monster.SPD = 5;
                    monster.AGI = 10;
                    monster.HIT = 70;
                    break;
                case (int)Monstertype.HellHound:
                    Console.WriteLine("헬하운드가 나타났다.");
                    Console.WriteLine("");
                    Console.ReadLine();
                    monster.Name = "헬하운드";
                    monster.HP = 50;
                    monster.ATK = 15;
                    monster.DEF = 10;
                    monster.SPD = 5;
                    monster.AGI = 25;
                    monster.HIT = 80;
                    break;
                default:
                    monster.Name = "";
                    monster.HP = 0;
                    monster.ATK = 0;
                    monster.DEF = 0;
                    monster.SPD = 0;
                    monster.AGI = 0;
                    monster.HIT = 0;
                    break;
            }
        }
        static void Bossmonster1(out Monster monster)
        {
            Console.WriteLine("슬래셔(닉)가 나타났다.");
            Console.WriteLine("");
            Console.ReadLine();
            monster.Name = "슬래셔(닉)";
            monster.HP = 120;
            monster.ATK = 25;
            monster.DEF = 15;
            monster.SPD = 15;
            monster.AGI = 15;
            monster.HIT = 80;
        }
        static void Battle(ref Player player, ref Monster monster)
        {
            while (true)
            {
                Console.WriteLine("행동을 결정해 주세요");
                Console.WriteLine("[1] 공격한다");
                Console.WriteLine("[2] 아이템을 사용한다");
                Console.WriteLine("[3] 도주한다");
                string SelectBattle = Console.ReadLine();
                switch (SelectBattle)
                {
                    case "1":
                        if (player.SPD >= monster.SPD)
                        {
                            AttackPM(ref player, ref monster);
                            if(monster.HP > 0)
                            {
                                Console.WriteLine($"남은 체력 {monster.HP}");
                                Console.WriteLine("");
                                Console.ReadLine();
                                AttackMP(ref player, ref monster);
                                Console.WriteLine($"남은 체력 {player.HP}");
                                Console.WriteLine("");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine($"{player.Name}은(는) {monster.Name}을(를) 쓰러뜨렸다.");
                                Console.WriteLine("");
                                Console.ReadLine();
                                if (player.Stage <= 5)
                                {
                                    player.Stage++;
                                }
                                SubMenu0(ref player);
                            }
                        }
                        else
                        {
                            AttackMP(ref player, ref monster);
                            if(player.HP > 0)
                            {
                                Console.WriteLine($"남은 체력 {player.HP}");
                                Console.WriteLine("");
                                Console.ReadLine();
                                AttackPM(ref player, ref monster);
                                Console.WriteLine($"남은 체력 {monster.HP}");
                                Console.WriteLine("");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine($"{player.Name}은(는) 쓰러졌다.");
                                Console.WriteLine("");
                                Console.ReadLine();
                                player.HP = 200;
                                SubMenu0(ref player);
                            }
                        }
                        break;
                    case "2":
                        //아이템사용
                        UsedItem(ref player, ref monster);
                        break;
                    case "3":
                        Random rand = new Random();
                        int randrun = rand.Next(1, 101);
                        if (randrun <= 80)
                        {
                            Console.WriteLine("도주에 성공했다.");
                            SubMenu0(ref player);
                        }
                        else
                        {
                            Console.WriteLine("도주에 실패했다.");
                            AttackMP(ref player, ref monster);
                        }
                        break;
                }
            }
        }
        static void BossBattle1F(ref Player player, ref Monster monster)
        {
            while (true)
            {
                Console.WriteLine("행동을 결정해 주세요");
                Console.WriteLine("[1] 공격한다");
                Console.WriteLine("[2] 아이템을 사용한다");
                string SelectBattle = Console.ReadLine();
                switch (SelectBattle)
                {
                    case "1":
                        if (player.SPD >= monster.SPD)
                        {
                            AttackPM(ref player, ref monster);
                            if (monster.HP > 0)
                            {
                                Console.WriteLine($"남은 체력 {monster.HP}");
                                Console.WriteLine("");
                                Console.ReadLine();
                                AttackMP(ref player, ref monster);
                                Console.WriteLine($"남은 체력 {player.HP}");
                                Console.WriteLine("");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine($"{player.Name}은(는) {monster.Name}을(를) 쓰러뜨렸다.");
                                Console.WriteLine("");
                                Console.ReadLine();
                                player.Stage++;
                                SubMenu0(ref player);
                            }
                        }
                        else
                        {
                            AttackMP(ref player, ref monster);
                            if (player.HP > 0)
                            {
                                Console.WriteLine($"남은 체력 {player.HP}");
                                Console.WriteLine("");
                                Console.ReadLine();
                                AttackPM(ref player, ref monster);
                                Console.WriteLine($"남은 체력 {monster.HP}");
                                Console.WriteLine("");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine($"{player.Name}은(는) 쓰러졌다.");
                                Console.WriteLine("");
                                Console.ReadLine();
                                player.HP = 200;
                                GameOver();
                            }
                        }
                        break;
                    case "2":
                        //아이템사용
                        UsedItem(ref player, ref monster);
                        break;
                }
            }
        }
        static void AttackPM(ref Player player, ref Monster monster)
        {
            Console.WriteLine($"{player.Name}은(는) {monster.Name}을(를) 공격했다.");
            Console.WriteLine("");
            Console.ReadLine();
            int miss = player.HIT - monster.AGI;
            Random missrand0 = new Random();
            int missrand1 = missrand0.Next(1, 101);
            if (missrand1 <= miss)
            {
                int DamagePM = player.ATK * 2 - monster.DEF;
                monster.HP -= DamagePM;
                Console.WriteLine($"{monster.Name}은(는) {DamagePM}의 피해를 입었다.");
                Console.WriteLine("");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"{monster.Name}은(는) {player.Name}의 공격을 피했다.");
                Console.WriteLine("");
                Console.ReadLine();
            }
        }
        static void AttackMP(ref Player player, ref Monster monster)
        {

            Console.WriteLine($"{monster.Name}은(는) {player.Name}을(를) 공격했다.");
            Console.WriteLine("");
            Console.ReadLine();
            int miss = monster.HIT - player.AGI;
            Random missrand0 = new Random();
            int missrand1 = missrand0.Next(1, 101);
            if (missrand1 <= miss)
            {
                int DamageMP = monster.ATK * 2 - player.DEF;
                player.HP -= DamageMP;
                Console.WriteLine($"{player.Name}은(는) {DamageMP}의 피해를 입었다.");
                Console.WriteLine("");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"{player.Name}은(는) {monster.Name}의 공격을 피했다.");
                Console.WriteLine("");
                Console.ReadLine();
            }
            if(player.HP <= 0)
            {
                
            }
        }
        static void Status(ref Player player)
        {
            Console.Clear();
            Console.WriteLine($"이름 : {player.Name}");
            Console.WriteLine($"체력 : {player.HP} / 200");
            Console.WriteLine($"공격 : {player.ATK}");
            Console.WriteLine($"방어 : {player.DEF}");
            Console.WriteLine($"민첩 : {player.SPD}");
            Console.WriteLine($"회피 : {player.AGI}");
            Console.WriteLine($"적중 : {player.HIT}");
            Console.ReadLine();
            Console.Clear();
            SubMenu0(ref player);
        }
        //맵 이동
        class Move1F
        {
            public string[] theMove1F;
            public void input(ref Player player)
            {
                theMove1F = new string[12];
                theMove1F[0] = "1층 복도";
                theMove1F[1] = "식당";
                theMove1F[2] = "주방";
                theMove1F[3] = "객실1";
                theMove1F[4] = "객실2";
                theMove1F[5] = "관리실";
                theMove1F[6] = "남자 화장실";
                theMove1F[7] = "여자 화장실";
                theMove1F[8] = "창고";
                theMove1F[9] = "???";
                theMove1F[10] = "계단";
                theMove1F[11] = "메인화면으로";

                for(int indexnumber = 0; indexnumber < 11; indexnumber++)
                {
                    if(theMove1F[indexnumber] == player.Place)
                    {
                        theMove1F[indexnumber] = "현재위치";
                        break;
                    }
                }
                Console.WriteLine("어디로 이동하시겠습니까?");
                Console.WriteLine($"[1]{theMove1F[0]}");
                Console.WriteLine($"[2]{theMove1F[1]}");
                Console.WriteLine($"[3]{theMove1F[2]}");
                Console.WriteLine($"[4]{theMove1F[3]}");
                Console.WriteLine($"[5]{theMove1F[4]}");
                Console.WriteLine($"[6]{theMove1F[5]}");
                Console.WriteLine($"[7]{theMove1F[6]}");
                Console.WriteLine($"[8]{theMove1F[7]}");
                Console.WriteLine($"[9]{theMove1F[8]}");
                Console.WriteLine($"[10]{theMove1F[9]}");
                Console.WriteLine($"[11]{theMove1F[10]}");
                Console.WriteLine($"[12]{theMove1F[11]}");
                string PlaceSelect = Console.ReadLine();
                int PlaceSelct1 = Convert.ToInt32(PlaceSelect);
                if(PlaceSelct1 <= 12)
                {
                    player.Place = theMove1F[PlaceSelct1 - 1];
                    Console.WriteLine($"{player.Place}로 이동하였습니다.");
                    Console.ReadLine();
                    Console.Clear();
                    SubMenu0(ref player);
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadLine();
                    Console.Clear();
                    SubMenu0(ref player);
                }
                
            }
        }
        //아이템 관련
        static void GetItem(ref Player player)
        {
            if(player.Chap == 1)
            {
                Random randitem = new Random();
                int randitem1f = randitem.Next(1,101);
                if(randitem1f < 90)
                {
                    int Haveitemqt = player.Potion1;
                    int Getitemqt = 1;
                    player.Potion1 = Haveitemqt + Getitemqt;
                    Console.WriteLine("회복약(소)를 획득했다.");
                    Console.ReadLine();
                    if (player.Stage == 7)
                    {
                        if (player.Place == "관리실")
                        {
                            Console.WriteLine("어딘가의 열쇠를 획득했다.");
                            player.Stage++;
                            Console.ReadLine();
                        }
                    }
                    Console.Clear();
                }
                else
                {
                    int Haveitemqt = player.bomb;
                    int Getitemqt = 1;
                    player.bomb = Haveitemqt + Getitemqt;
                    Console.WriteLine("수류탄을 획득했다.");
                    Console.ReadLine();
                    Console.Clear();
                }
                //아이템 획득
                SubMenu0(ref player);
            }
        }
        static void Inventory(ref Player player)
        {
            Console.Clear();
            Console.WriteLine("현재 가지고 있는 아이템을 보여줍니다.");
            Console.WriteLine($"[1]회복약(소) : {player.Potion1}     [2]회복약(중) : {player.Potion2}     [3]회복약(대) : {player.Potion3}");
            Console.WriteLine($"[4]수류탄 : {player.bomb}     [5]메인화면으로");
            Console.WriteLine("");
            Console.WriteLine("어느 아이템을 사용하시겠습니까?");
            string itemselect = Console.ReadLine();
            switch (itemselect)
            {
                case "1":
                    if (player.Potion1 > 0)
                    {
                        Console.WriteLine($"{player.Name}의 체력이 50 회복되었다.");
                        Console.WriteLine("");
                        Console.ReadLine();
                        if (player.HP <= 150)
                        {
                            int HP = player.HP;
                            player.HP = HP + 50;
                        }
                        else
                        {
                            player.HP = 200;
                        }
                        int haveitem = player.Potion1;
                        player.Potion1 = haveitem - 1;
                        Inventory(ref player);
                    }
                    else
                    {
                        Console.WriteLine("현재 가지고 있지 않습니다..");
                        Console.WriteLine("");
                        Console.ReadLine();
                        Inventory(ref player);
                    }
                    break;
                case "2":
                    if (player.Potion2 > 0)
                    {
                        Console.WriteLine($"{player.Name}의 체력이 80 회복되었다.");
                        Console.WriteLine("");
                        Console.ReadLine();
                        if (player.HP <= 120)
                        {
                            int HP = player.HP;
                            player.HP = HP + 80;
                        }
                        else
                        {
                            player.HP = 200;
                        }
                        int haveitem = player.Potion2;
                        player.Potion2 = haveitem - 1;
                        Inventory(ref player);
                    }
                    else
                    {
                        Console.WriteLine("현재 가지고 있지 않습니다..");
                        Console.WriteLine("");
                        Console.ReadLine();
                        Inventory(ref player);
                    }
                    break;
                case "3":
                    if (player.Potion3 > 0)
                    {
                        Console.WriteLine($"{player.Name}의 체력이 120 회복되었다.");
                        Console.WriteLine("");
                        Console.ReadLine();
                        if (player.HP <= 80)
                        {
                            int HP = player.HP;
                            player.HP = HP + 120;
                        }
                        else
                        {
                            player.HP = 200;
                        }
                        int haveitem = player.Potion3;
                        player.Potion3 = haveitem - 1;
                        Inventory(ref player);
                    }
                    else
                    {
                        Console.WriteLine("현재 가지고 있지 않습니다..");
                        Console.WriteLine("");
                        Console.ReadLine();
                        Inventory(ref player);
                    }
                    break;
                case "4":
                    Console.WriteLine("여기서는 사용이 불가합니다.");
                    Console.WriteLine("");
                    Console.ReadLine();
                    Inventory(ref player);
                    break;
                default:
                    SubMenu0(ref player);
                    break;
            }
            SubMenu0(ref player);

        }
        static void UsedItem(ref Player player, ref Monster monster)
        {
            Console.Clear();
            Console.WriteLine("현재 가지고 있는 아이템을 보여줍니다.");
            Console.WriteLine($"[1]회복약(소) : {player.Potion1}     [2]회복약(중) : {player.Potion2}     [3]회복약(대) : {player.Potion3}");
            Console.WriteLine($"[4]수류탄 : {player.bomb}     [5]메인화면으로");
            Console.WriteLine("");
            Console.WriteLine("어느 아이템을 사용하시겠습니까?");
            string itemselect = Console.ReadLine();
            switch (itemselect)
            {
                case "1":
                    if (player.Potion1 > 0)
                    {
                        Console.WriteLine($"{player.Name}의 체력이 50 회복되었다.");
                        Console.WriteLine("");
                        Console.ReadLine();
                        if (player.HP <= 150)
                        {
                            int HP = player.HP;
                            player.HP = HP + 50;
                        }
                        else
                        {
                            player.HP = 200;
                        }
                        int haveitem = player.Potion1;
                        player.Potion1 = haveitem - 1;
                        AttackMP(ref player, ref monster);
                        Battle(ref player, ref monster);
                    }
                    else
                    {
                        Console.WriteLine("현재 가지고 있지 않습니다..");
                        Console.WriteLine("");
                        Console.ReadLine();
                        UsedItem(ref player, ref monster);
                    }
                    break;
                case "2":
                    if (player.Potion2 > 0)
                    {
                        Console.WriteLine($"{player.Name}의 체력이 80 회복되었다.");
                        Console.WriteLine("");
                        Console.ReadLine();
                        if (player.HP <= 120)
                        {
                            int HP = player.HP;
                            player.HP = HP + 80;
                        }
                        else
                        {
                            player.HP = 200;
                        }
                        int haveitem = player.Potion2;
                        player.Potion2 = haveitem - 1;
                        AttackMP(ref player, ref monster);
                        Battle(ref player, ref monster);
                    }
                    else
                    {
                        Console.WriteLine("현재 가지고 있지 않습니다..");
                        Console.WriteLine("");
                        Console.ReadLine();
                        UsedItem(ref player, ref monster);
                    }
                    break;
                case "3":
                    if (player.Potion3 > 0)
                    {
                        Console.WriteLine($"{player.Name}의 체력이 120 회복되었다.");
                        Console.WriteLine("");
                        Console.ReadLine();
                        if (player.HP <= 80)
                        {
                            int HP = player.HP;
                            player.HP = HP + 120;
                        }
                        else
                        {
                            player.HP = 200;
                        }
                        int haveitem = player.Potion3;
                        player.Potion3 = haveitem - 1;
                        AttackMP(ref player, ref monster);
                        Battle(ref player, ref monster);
                    }
                    else
                    {
                        Console.WriteLine("현재 가지고 있지 않습니다..");
                        Console.WriteLine("");
                        Console.ReadLine();
                        UsedItem(ref player, ref monster);
                    }
                    break;
                case "4":
                    if(player.bomb > 0)
                    {
                        Console.WriteLine($"{player.Name}은(는) {monster.Name}에게 수류탄을 던졌다.");
                        Console.WriteLine("");
                        Console.ReadLine();

                        int HP = monster.HP;
                        monster.HP = HP - 100;
                        int haveitem = player.bomb - 1;
                        player.bomb = haveitem;

                        Console.WriteLine($"{monster.Name}은(는) 100의 피해를 입었다.");
                        Console.WriteLine("");
                        Console.ReadLine();

                        if (monster.HP <= 0)
                        {
                            Console.WriteLine($"{player.Name}은(는) {monster.Name}을(를) 쓰러뜨렸다.");
                            Console.WriteLine("");
                            Console.ReadLine();
                            if (player.Stage < 5)
                            {
                                player.Stage++;
                            }
                            SubMenu0(ref player);
                        }
                        else
                        {
                            Console.WriteLine($"남은 체력 {monster.HP}");
                            Console.WriteLine("");
                            Console.ReadLine();
                            Battle(ref player, ref monster);
                        }
                    }
                    else
                    {
                        Console.WriteLine("현재 가지고 있지 않습니다..");
                        Console.ReadLine();
                        UsedItem(ref player, ref monster);
                    }
                    Battle(ref player, ref monster);
                    break;
                default:
                    Battle(ref player, ref monster);
                    break;
            }
            AttackMP(ref player, ref monster);
            SubMenu1(ref player);
        }
        //시스템 관련
        static void GameOver()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Game Over....");
            Console.ReadLine();
        }
        //참조
        static void Reference() // 사용X
        {
            Console.ForegroundColor = ConsoleColor.Red; // Text 색상지정
            Console.WriteLine("색상 : 빨강"); // 지정된 색으로 출력
            Console.ResetColor(); // 색상 리셋
            //goto문은 에러가 발생될 확률이 높으므로 사용하지 말것.

        }
    }
}
