using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Mage : Enemy
{

    public int tempRange = 1;

    public Mage(int X, int Y, int HP = 5, int damage = 5) : base(X, Y, HP, damage) //constructor
    {

    }

    public override Movement ReturnMove(Movement move = Movement.none)
    {
        return Movement.none;
    }

  /*  private int DistanceTo(Character target)
    {
       
    }  */

    public override bool CheckRange(Character target)
    {

        if ((this.x == target.y))
        {
           
            return true;
        }

        else
            return false;

    }

}
