using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameEngine
{

    private Map map;  //instane of Map

    public Map getMap
    {
        get { return map; }
        set { map = value; }
    }

    public GameEngine(int minWidth, int maxWidth, int minHeight, int maxHeight, int numEnemies, int numGold)
    {

        map = new Map(minWidth,maxWidth,minHeight,maxHeight,numEnemies,numGold);

    }

    public enum Movement
    {
        none,
        up,
        down,
        left,
        right
    }

    public void MovePlayer(Movement direction)
    {

        switch (direction)
        {

            case Movement.up:
                {
                    
                    if (map.getPlayer.getVision[0] is Gold)
                    {                    

                        for (int i = 0; i < map.getGold.Length; i++)
                        {

                            if (map.getGold[i] == map.getTiles[map.getPlayer.getVision[0].x, map.getPlayer.getVision[0].y])
                            {
                                map.getPlayer.Pickup(map.getGold[i]);

                                Console.WriteLine(map.getPlayer.getGoldPurse);

                            }

                        }
                       
                    }
                        map.getPlayer.y--;
                        map.getTiles[map.getPlayer.x, map.getPlayer.y] = map.getPlayer;
                        map.getTiles[map.getPlayer.x, map.getPlayer.y + 1] = new EmptyTile(map.getPlayer.x, map.getPlayer.y + 1);
                        map.UpdateVision();
                                      
                    break;
                    
                }
            case Movement.down:
                {


                    if (map.getPlayer.getVision[1] is Gold)
                    {

                        for (int i = 0; i < map.getGold.Length; i++)
                        {

                            if (map.getGold[i] == map.getTiles[map.getPlayer.getVision[1].x, map.getPlayer.getVision[1].y])
                            {
                                 map.getPlayer.Pickup(map.getGold[i]);

                                 Console.WriteLine(map.getPlayer.getGoldPurse);

                            }

                        }

                    }

                    map.getPlayer.y++;
                    map.getTiles[map.getPlayer.x, map.getPlayer.y] = map.getPlayer;
                    map.getTiles[map.getPlayer.x, map.getPlayer.y -1] = new EmptyTile(map.getPlayer.x, map.getPlayer.y -1);
                    map.UpdateVision();
                    break;

                }
            case Movement.right:
                {


                    if (map.getPlayer.getVision[3] is Gold)
                    {

                        for (int i = 0; i < map.getGold.Length; i++)
                        {

                            if (map.getGold[i] == map.getTiles[map.getPlayer.getVision[3].x, map.getPlayer.getVision[3].y])
                            {
                                map.getPlayer.Pickup(map.getGold[i]);

                                 Console.WriteLine(map.getPlayer.getGoldPurse);

                            }

                        }

                    }
                    map.getPlayer.x++;                   
                    map.getTiles[map.getPlayer.x, map.getPlayer.y] = map.getPlayer;
                    map.getTiles[map.getPlayer.x -1, map.getPlayer.y] = new EmptyTile(map.getPlayer.x -1, map.getPlayer.y);
                    map.UpdateVision();
                    break;

                }
            case Movement.left:
                {


                    if (map.getPlayer.getVision[2] is Gold)
                    {

                        for (int i = 0; i < map.getGold.Length; i++)
                        {

                            if (map.getGold[i] == map.getTiles[map.getPlayer.getVision[2].x, map.getPlayer.getVision[2].y])
                            {
                                map.getPlayer.Pickup(map.getGold[i]);

                                 Console.WriteLine(map.getPlayer.getGoldPurse);

                            }

                        }

                    }

                    map.getPlayer.x--;
                    map.getTiles[map.getPlayer.x, map.getPlayer.y] = map.getPlayer;
                    map.getTiles[map.getPlayer.x + 1, map.getPlayer.y] = new EmptyTile(map.getPlayer.x + 1, map.getPlayer.y);
                    map.UpdateVision();
                    break;

                }

            default:
                break;
        }

        
    }

    public void moveGoblin(Movement direction, int enemyIndex)
    {

        int i = enemyIndex;

            switch (direction)
            {

                case Movement.up:
                    {

                            map.getEnemies[i].y--;
                            map.getTiles[map.getEnemies[i].x, map.getEnemies[i].y] = map.getEnemies[i];
                            map.getTiles[map.getEnemies[i].x, map.getEnemies[i].y++] = new EmptyTile(map.getEnemies[i].x, map.getEnemies[i].y++);
                            map.UpdateVision();


                        break;
                    }
                case Movement.down:
                    {
                            map.getEnemies[i].y++;
                            map.getTiles[map.getEnemies[i].x, map.getEnemies[i].y] = map.getEnemies[i];
                            map.getTiles[map.getEnemies[i].x, map.getEnemies[i].y--] = new EmptyTile(map.getEnemies[i].x, map.getEnemies[i].y--);
                            map.UpdateVision();

                        break;
                    }
                case Movement.right:
                    {
                       
                            map.getEnemies[i].x++;
                            map.getTiles[map.getEnemies[i].x, map.getEnemies[i].y] = map.getEnemies[i];
                            map.getTiles[map.getEnemies[i].x--, map.getEnemies[i].y] = new EmptyTile(map.getEnemies[i].x--, map.getEnemies[i].y);
                            map.UpdateVision();

                        break;
                    }
                case Movement.left:
                    {
                       
                            map.getEnemies[i].x--;
                            map.getTiles[map.getEnemies[i].x, map.getEnemies[i].y] = map.getEnemies[i];
                            map.getTiles[map.getEnemies[i].x++, map.getEnemies[i].y] = new EmptyTile(map.getEnemies[i].x++, map.getEnemies[i].y);
                            map.UpdateVision();


                        break;
                    }
                    

                default:
                    break;
            }

        

    }

    public void mageAttack()
    {

        for (int i = 0; i < map.getEnemies.Length; i ++)
        {

            if (map.getEnemies[i] is Mage)
            {

                Console.WriteLine(map.getEnemies[i]);

                for (int j =0; j< map.getEnemies.Length; j++)
                {

                    if (map.getEnemies[i].CheckRange(map.getPlayer) == true)
                    {

                        map.getEnemies[i].Attack(map.getPlayer);

                    }

                    if (map.getEnemies[i].CheckRange(map.getEnemies[j]) == true)
                    {

                        map.getEnemies[i].Attack(map.getEnemies[j]);

                    }

                }

            }

        }

    }

    public override string ToString()
    {
        return map.ToString();
    }

}