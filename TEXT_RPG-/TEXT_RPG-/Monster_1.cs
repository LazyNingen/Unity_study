using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    public class Monster_1
    {
        public string name = "신성준";
        public int level = 1;
        public int atk_dmg = 5;
        public int def = 1;
        public int max_hp = 10;
        public int current_hp = 10;

        string get_key;

        public int drop_gold = 10;
        public int drop_exp = 10;

        public void information()
        {
            Console.WriteLine("==============================================");
            Console.Write(" 몬스터 : 『" + name + "』                  ");
            Console.WriteLine("Lv : " + level);
            Console.Write(" 공격력 : " + atk_dmg + "   ");
            Console.Write(" 방어력 : " + def + "   ");
            Console.WriteLine(" 체력 : " + current_hp + "/" + max_hp + "   ");
            Console.WriteLine("==============================================");
        }
        
        public void itemdrop(Player player)
        {
            player.gold += drop_gold;
            player.current_exp += drop_exp;
            if(player.current_exp >= player.max_exp)
            {
                player.level += 1;
                player.stats += 1;

                Console.Read();
                Console.Clear();

                //get_key = Console.ReadLine();

                //Console.WriteLine("올리고 싶은 스텟을 고르세요.");
                //Console.WriteLine("1. STR       2. LUK      3. DEX      4. INT");
                //Console.WriteLine("5. 방어력       6. 체력       7. 마나");

                //switch (get_key)
                //{
                //    case "1":
                //        player.str += 1;
                //        break;
                //    case "2":
                //        player.luk += 1;
                //        break;
                //    case "3":
                //        player.dex += 1;
                //        break;
                //    case "4":
                //        player._int += 1;
                //        break;
                //    case "5":
                //        player.def += 1;
                //        break;
                //    case "6":
                //        player.max_hp += 1;
                //        player.current_hp = max_hp;
                //        break;
                //    case "7":
                //        player.max_mp += 1;
                //        player.current_mp = max_hp;
                //        break;
                //    default:
                //        break;
                //}
            }

            Console.ReadLine();
            Console.Clear();
        }
    }

  
}
