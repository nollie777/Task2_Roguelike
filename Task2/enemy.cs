using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Enemy : Character
{
    public Enemy(int X, int Y, int HP, int Damage) : base(X, Y) //constructor
    {

        hp = HP;

        damage = Damage;

        _maxHP = HP;

    }

    protected Random rando = new Random();

    public override string ToString()
    {
        return (String.Format("{0} at [{1}, {2}] (Damage: {3}) (HP: {4})", this.GetType().Name, X, Y, Damage,HP));  //tostring goblin
    }
}
class Goblin : Enemy
{
    public override Movement ReturnMove(Movement move = Movement.none)
    {
      
        int randmove = 0;

        randmove = rando.Next(0, 5);       

        switch (move)   //based on the random number generated, the goblin moves in one of 5 directions
        {
            case (Movement.none):

                return Movement.none;               

            case (Movement.up):

                if (this.getVision[0] is EmptyTile)
                {

                    Console.WriteLine("returnmove goblin: " + randmove + this.getVision[0]);

                    return Movement.up;

                }
                else
                {

                    Console.WriteLine("returnmove goblin: " + randmove + this.getVision[0]);


                    return Movement.none;

                }

            case (Movement.down):


                if (getVision[1] is EmptyTile)
                {
                    return Movement.down;
                }
                else
                {
                    return Movement.none;
                }


            case (Movement.left):
                
                if (getVision[2] is EmptyTile)
                {
                    return Movement.left;
                }
                else
                {
                    return Movement.none;
                }

            case (Movement.right):
                

                if (getVision[3] is EmptyTile)
                {
                    return Movement.right;
                }
                else
                {
                    return Movement.none;
                }

            default:
                break;

         
        }

        return Movement.none;
    }

    public Goblin(int X, int Y, int HP = 10, int damage = 1) : base(X, Y, HP, damage) //constructor
    {

    }

}