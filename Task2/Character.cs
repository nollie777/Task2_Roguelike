﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Character : Tile
{
    protected int HP;             //Variables 

    protected int maxHP;

    protected int Damage;

    protected Tile[] visionArray = new Tile[4];

    protected int goldPurse;

    public int hp //getters n setters
    {
        get { return HP; }
        set { HP = value; }
    }

    public int _maxHP
    {
        get { return maxHP; }
        set { maxHP = value; }
    }
    
    public int damage
    {
        get { return Damage; }
        set { Damage = value; }
    }

    public enum Movement
    {
        none,
        up,
        down,
        left,
        right
    }

    public Tile[] getVision
    {
        get { return visionArray; }
        set { visionArray = value; }
    }

    public int getGoldPurse
    {
        get { return goldPurse; }
        set { goldPurse = value; }
    }

    public int tempRange = 1;


    public Character(int X, int Y) : base(X, Y)  //constructor
    {
        Damage = 10;
    }

    public virtual bool CheckRange(Character target)  //methods
    {

        if (DistanceTo(target) <= tempRange)
        {
            return true;
        }
        else
            return false;

    }

    public bool IsDead()
    {
        if (this.HP <= 0)
        {
            return true;
        }
        else
            return false;
    }

    public virtual void Attack(Character target)
    {
        target.HP = target.HP - this.Damage;
    }

    private int DistanceTo(Character target)
    {

        return (Math.Abs(X - target.X) + Math.Abs(Y - target.Y));

    }

    public void Move(Movement move)
    {
        switch (move)
        {
            case Movement.none:

                break;

            case Movement.up:
                Y--;
                break;

            case Movement.down:
                Y++;
                break;

            case Movement.left:
                X--;
                break;

            case Movement.right:
                X++;
                break;

        }

    }

    public void Pickup(Item i)
    {

        Gold tempGold = new Gold(i.x, i.y);

        if (i is Gold)
        {

            this.goldPurse += tempGold.getGoldAmount;         

        }

    }    

    public abstract Movement ReturnMove(Movement move = 0); //abstracts


    public abstract override string ToString();
}
