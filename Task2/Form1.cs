using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        GameEngine game = new GameEngine(10,10,10,10,5,3);

        private void Form1_Load(object sender, EventArgs e)
        {

            lblmap.Text = game.ToString();

            for (int i = 0; i < game.getMap.getPlayer.getVision.Length +1; i++)
            {
                actionlist.Items.Add(game.getMap.getEnemies[i].x + " " + game.getMap.getEnemies[i].y);
            }

        }  

        private void btn_left_Click(object sender, EventArgs e)
        {
          
            if (game.getMap.getPlayer.ReturnMove(Character.Movement.left) == Character.Movement.left)
            {

                game.MovePlayer(GameEngine.Movement.left);
            }

            lblPlayer.Text = game.getMap.getPlayer.ToString();

            moveGoblins();

            mageAttack();

            lblmap.Text = game.ToString();

        }

        private void btn_up_Click(object sender, EventArgs e)
        {

            if (game.getMap.getPlayer.ReturnMove(Character.Movement.up) == Character.Movement.up)
            {

                game.MovePlayer(GameEngine.Movement.up);

            }

            lblPlayer.Text = game.getMap.getPlayer.ToString();

            moveGoblins();

            mageAttack();

            lblmap.Text = game.ToString();

        }

        private void btn_down_Click(object sender, EventArgs e)
        {

            if (game.getMap.getPlayer.ReturnMove(Character.Movement.down) == Character.Movement.down)
            {

                game.MovePlayer(GameEngine.Movement.down);

            }

            lblPlayer.Text = game.getMap.getPlayer.ToString();

            moveGoblins();

            mageAttack();

            lblmap.Text = game.ToString();

        }

        private void btn_right_Click(object sender, EventArgs e)
        {

            if (game.getMap.getPlayer.ReturnMove(Character.Movement.right) == Character.Movement.right)
            {

                game.MovePlayer(GameEngine.Movement.right);
                
            }

            lblPlayer.Text = game.getMap.getPlayer.ToString();

            moveGoblins();

            mageAttack();

            lblmap.Text = game.ToString();

        }

        private void btn_attack_Click(object sender, EventArgs e)
        {

            int i = actionlist.SelectedIndex;

            bool checkRannge;

            checkRannge = false;

            for (int check = 0; check < 4; check++)
            {

                if (game.getMap.getPlayer.getVision[check] == game.getMap.getEnemies[i])
                {

                    checkRannge = true;

                    lblPlayer.Text += game.getMap.getEnemies[i];

                }

            }

            if (checkRannge == true)
            {

                if (actionlist.SelectedItem.ToString() == (game.getMap.getEnemies[i].x + " " + game.getMap.getEnemies[i].y))
                {

                    actionlist.Items.Add(game.getMap.getEnemies[i]);

                    game.getMap.getPlayer.Attack(game.getMap.getEnemies[i]);

                    actionlist.Items.Add(game.getMap.getEnemies[i].hp);

                    bool checkDead = game.getMap.getEnemies[i].IsDead();

                    if (checkDead == true)
                    {

                        game.getMap.getTiles[game.getMap.getEnemies[i].x, game.getMap.getEnemies[i].y] = new EmptyTile(game.getMap.getEnemies[i].x, game.getMap.getEnemies[i].y);

                        game.getMap.UpdateVision();

                        lblmap.Text = game.ToString();

                    }
                }


            }

            mageAttack();

        }

        public void moveGoblins()
        {

            for (int i = 0; i < game.getMap.getEnemies.Length; i++)
            {

                if (game.getMap.getEnemies[i] is Goblin)
                {

                    //Console.WriteLine(game.getMap.getEnemies[i].ReturnMove(Goblin.Movement.up));

                    if (game.getMap.getEnemies[i].ReturnMove(Goblin.Movement.up) == Goblin.Movement.up)
                    {

                        game.moveGoblin(GameEngine.Movement.up, i);

                    }
                   
                    lblmap.Text = game.ToString();

                }

            }          

        }

        public void mageAttack()
        {

            game.mageAttack();

        }
    }

}
