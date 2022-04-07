using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    public class Player
    {
        public string name = "이창호";
        public int str = 5;
        public int luk = 1;
        public int dex = 1;
        public int def = 1;
        public int _int = 1;
        public int level = 1;
        public int max_hp = 10;
        public int current_hp = 10;
        public int max_mp = 100;
        public int current_mp = 100;
        public int gold = 0;
        public int max_exp = 10;
        public int current_exp = 0;
        public int stats = 0;

        List<Item> inventory = new List<Item>();

        public void get_item(Item _itme)
        {
            inventory.Add(_itme);
        }

        public void open_inven()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("인벤토리가 비어있습니다.");
                Console.ReadLine();
                Console.Clear();
            }
            for(int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine("아이템의 이름 : " + inventory[i].name + "능력치 : " + inventory[i].status); ;

            }
        }

        public void information()
        {
            Console.WriteLine("==============================================");
            
            Console.Write("『" + name+ "』    ");
            Console.Write("Gold : " + gold + "G  ");
            Console.Write("EXP : " + current_exp + "/" + max_exp);
            Console.WriteLine("  Lv : " + level);

            Console.WriteLine("----------------------------------------------");

            Console.Write(" STR : " + str);
            Console.Write("    LUK : " + luk);
            Console.Write("    DEX : " + dex);
            Console.Write("    INT : " + _int +"\n");

            Console.WriteLine("----------------------------------------------");

            Console.Write(" 방어력 : " + def + "   ");
            Console.Write(" 체력 : " + current_hp + "/" + max_hp + "   ");
            Console.WriteLine(" 마나 : " + current_mp + "/" + max_mp);
            Console.WriteLine("==============================================");
        }
    
        public void fight(Monster_1 monster)
        {
            while (true)
            {
                Console.ReadLine();

                Console.Clear();

                Console.WriteLine("============== 플레이어공격 ====================");
                if (monster.def >= str)
                {
                    monster.current_hp -= 1;
                    Console.WriteLine(name + "이 몬스터 " + monster.name + "에게 " + 1 + "만큼의 데미지를 입혔습니다.");
                }
                else
                {
                    monster.current_hp -= (str - monster.def);
                    Console.WriteLine(name + "이 몬스터 " + monster.name + "에게 " + (str - monster.def) + "만큼의 데미지를 입혔습니다.");
                }

                information();
                monster.information();

                if (current_hp <= 0) //만약 플레이어의 현재체력이 0보다작다면 사망
                {
                    Console.WriteLine("사망하셨습니다.");
                    Console.ReadLine();
                    return;
                }
                else if (monster.current_hp <= 0) //만약 몬스터의 현재체력이 0보다작다면 승리
                {
                    Console.WriteLine("몬스터" + monster.name + "을 " + "물리쳤습니다.");
                    monster.itemdrop(this);
                    Console.ReadLine();
                    return;
                }

                Console.ReadLine();

                Console.Clear();

                Console.WriteLine("============== 몬스터공격 ====================");
                if (def >= monster.atk_dmg)
                {
                    current_hp -= 1;
                    Console.WriteLine(monster.name + "몬스터가 " + name + "에게 " + 1 + "만큼의 데미지를 입혔습니다.");
                }
                else
                {
                    current_hp -= (monster.atk_dmg - def);
                    Console.WriteLine(monster.name + "몬스터가 " + name + "에게 " + (monster.atk_dmg - def) + "만큼의 데미지를 입혔습니다.");
                }
                information();
                monster.information();

                if (current_hp <= 0) //만약 플레이어의 현재체력이 0보다작다면 사망
                {
                    Console.WriteLine("사망하셨습니다.");
                    Console.ReadLine();
                    return;
                }
                else if (monster.current_hp <= 0) //만약 몬스터의 현재체력이 0보다작다면 승리
                {
                    Console.WriteLine("몬스터" + monster.name + "을 " + "물리쳤습니다.");
                    monster.itemdrop(this);
                    Console.ReadLine();
                    return;
                }
            }
        }
       }
    }
