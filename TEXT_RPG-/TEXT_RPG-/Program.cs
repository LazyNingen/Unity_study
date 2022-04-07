using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXT_RPG
{
    class GAME
    {

        static void Main(string[] args)
        {
            string get_key;


            Player player = new Player();
            Monster_1 monster = new Monster_1();

            //player.information();
            //Console.WriteLine();
            //monster.information();
            while (true)
            {
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("==================== 마을 ====================\n");
                Console.WriteLine("  1. 탐험을 떠난다. 2. 내정보를 확인한다. 3. 인벤토리를 오픈한다.");
                player.get_item(new Item("구리검", "공격력 3"));

                get_key = Console.ReadLine();
                switch (get_key)
                {
                    case "1":
                        player.fight(monster);
                        break;

                    case "2":
                        player.information();
                        break;
                    case "3":
                        player.open_inven();
                        break;
                    default:
                        break;
                }
            }
            Console.ReadLine();
            player.fight(monster);
            Console.ReadLine();
        }
    }
}
