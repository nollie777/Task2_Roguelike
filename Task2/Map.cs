using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Map
{
    //variables

    Hero Player;

    private Enemy[] enemies;

    private int width = new int();

    private int height = new int();

    private Random rando = new Random();

    private Tile[,] mapArray;

    private Item[] goldArray;

    private Item[] itemArray;

    public int getWidth
    {
        get { return width; }
        set { width = value; }
    }

    public int getHeight
    {
        get { return height; }
        set { height = value; }
    }

    public Enemy[] getEnemies
    {
        get { return enemies; }
        set { enemies = value; }
    }

    public Hero getPlayer
    {
        get { return Player; }
        set { Player = value; }
    }

    public Tile[,] getTiles
    {
        get { return mapArray; }
        set { mapArray = value; }
    }

    public Item[] getGold
    {
        get { return goldArray; }
        set { goldArray = value; }
    }

    public Item[] getItem
    {
        get { return itemArray; }
        set { itemArray = value; }
    }

    public enum TileType
    {
        Hero,
        Enemy,
        Weapon,
        Gold
    }

    public Map(int minWidth, int maxWidth, int minHeight, int maxHeight, int numEnemies, int numGold) //methods
    {

        // random width and height calculations

        width = rando.Next(minWidth, maxWidth+1);

        height = rando.Next(minHeight, maxHeight+1);

        //declaring array sizes

        enemies = new Enemy[numEnemies];

        mapArray = new Tile[width, height];

        goldArray = new Item[numGold];

        itemArray = new Item[numGold];


        //for loops for filling arrays

       for (int i = 0; i < mapArray.GetLength(1); i++)  //i is used for width
        {
            for (int j = 0; j < mapArray.GetLength(0); j++) //j is used for length
            {

                mapArray[i, j] =  new EmptyTile(j,i);

            }
        }

        for (int i = 0; i < mapArray.GetLength(1); i++)  //i is used for width
        {
            for (int j = 0; j < mapArray.GetLength(0); j++) //j is used for length
            {

                mapArray[i, 0] = new Obstacle(j,i); // [i,0] top row
                mapArray[0, j] = new Obstacle(j, i); // [0,j] left column

                mapArray[i, (mapArray.GetLength(1) - 1)] = new Obstacle(j, i); //bottom row
                mapArray[(mapArray.GetLength(0) - 1), j] = new Obstacle(j, i); //right column

            }
        }

        Player = (Hero)Create(TileType.Hero);

        for (int i = 0; i < numEnemies; i++)  //loop for each enemy
        {

            enemies[i] = (Enemy)Create(TileType.Enemy); //creates enemy object

            mapArray[enemies[i].x, enemies[i].y] = enemies[i];

        }

        for (int i = 0; i < numGold; i++)
        {

            goldArray[i] = (Gold)Create(TileType.Gold);

            mapArray[goldArray[i].x, goldArray[i].y] = goldArray[i];

        }

        mapArray[Player.x, Player.y] = Player;

        UpdateVision();

    }

    private Tile Create(TileType type)
    {

        switch (type)
        {
            case (TileType.Hero):
                {

                    int heroX = rando.Next(0, width);    //get random width

                    int heroY = rando.Next(0, height); //get random height

                    while ((mapArray[heroX,heroY] is  EmptyTile)== false) //while the tile is already taken, create a random X and Y position
                    {
                         heroX = rando.Next(0, width);    //get random width

                         heroY = rando.Next(0, height); //get random height
                    }

                    Hero tempHero = new Hero(heroX,heroY,20,20);

                    return tempHero;
                    
                }
            case (TileType.Enemy):
                {

                    int gobX = rando.Next(0, width);    //get random width

                    int gobY = rando.Next(0, height); //get random height

                    while ((mapArray[gobX, gobY] is EmptyTile)== false)//while the tile is already taken, create a random X and Y position
                    {
                        gobX = rando.Next(0, width);    //get random width

                        gobY = rando.Next(0, height); //get random height
                    }

                    Random randEnemy = new Random(Guid.NewGuid().GetHashCode());

                    for (int i = 0; i<2; ++i)
                    {

                        int getRandEnemy = randEnemy.Next(0, 2);

                        if (getRandEnemy == 1)
                        {
                            Goblin tempGob = new Goblin(gobX, gobY, 10, 1);

                            return tempGob;

                        }
                        else
                        {
                            Mage tempMage = new Mage(gobX, gobY, 5, 5);

                            return tempMage;
                        }

                    }

                    return null;

                }
            case (TileType.Gold):
                {
                    int goldX = rando.Next(0, width);    //get random width

                    int goldY = rando.Next(0, height); //get random height

                    while ((mapArray[goldX, goldY] is EmptyTile) == false)//while the tile is already taken, create a random X and Y position
                    {
                        goldX = rando.Next(0, width);    //get random width

                        goldY = rando.Next(0, height); //get random height
                    }

                    Gold tempGold = new Gold(goldX, goldY);

                    return tempGold;
                }

            default:
                break; 

        }
        return null;
    }

    public void UpdateVision()  //updates a characters Tile array at X and Y positions.
    {

        //Console.WriteLine(Player.x + " " + Player.y+ " "+ width + " " + height);

        Player.getVision[0] = mapArray[Player.x,Player.y -1]; //north = 0
        Player.getVision[1] = mapArray[Player.x, Player.y +1]; //south = 1
        Player.getVision[2] = mapArray[Player.x -1, Player.y]; //west = 2
        Player.getVision[3] = mapArray[Player.x +1, Player.y]; //east = 3

        for(int i = 0; i < enemies.Length; i++)
        {           

            enemies[i].getVision[0] = mapArray[enemies[i].x, enemies[i].y--]; //north = 0
            enemies[i].getVision[1] = mapArray[ enemies[i].x,  enemies[i].y++]; //south = 1
            enemies[i].getVision[2] = mapArray[enemies[i].x--, enemies[i].y]; //west = 2
            enemies[i].getVision[3] = mapArray[enemies[i].x++,  enemies[i].y]; //east = 3

        }

    }

    public Item GetItemAtPosition(int x, int y)
    {
    
        for (int i = 0; i < itemArray.Length; i++)
        {

            if (mapArray[x, y] == itemArray[i])
            {
                return itemArray[i];
            }          

        }

        return null;

    }

    public override string ToString() //creating map
    {

        string tempString = "";

        for (int i = 0; i < mapArray.GetLength(1); i++)  //i is used for length
        {
            for (int j = 0; j < mapArray.GetLength(0); j++) //j is used for width
            {

               if (mapArray[j,i] is Hero)
                {
                    tempString += "H";
                }

                if (mapArray[j, i] is EmptyTile)
                {
                    tempString += "-";
                }

                if (mapArray[j, i] is Goblin)
                {
                    tempString += "G"; 
                }

                if (mapArray[j, i] is Mage)
                {
                    tempString += "M";
                }

                if (mapArray[j, i] is Gold)
                {
                    tempString += "*";
                }

                if (mapArray[j, i] is Obstacle)
                {
                    tempString += "X";
                }


            }

            tempString += "\n";
        }

        return tempString;
    }

}
