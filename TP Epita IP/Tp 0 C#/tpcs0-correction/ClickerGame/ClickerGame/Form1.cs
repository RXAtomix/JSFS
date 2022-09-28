using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickerGame
{
    public partial class Form1 : Form
    {
        int nbClicks;
        int money;
        int upgrade;
        int upgradeCost;
        int rng;
        int rngCost;
        int rngCountdown;
        Random random;

        public Form1()
        {
            InitializeComponent();
            upgrade = 1;
            upgradeCost = 10;
            rngCost = 100;
            random = new Random();
        }

        private void b_clicker_Click(object sender, EventArgs e)
        {
            nbClicks = nbClicks + 1;
            money = money + upgrade;
            l_clicks.Text = "Clicks  :  " + nbClicks;
            l_money.Text = "Money :  " + money + " $";
            if (rngCountdown > 0)
            {
                rngCountdown = rngCountdown - 1;
                if (rngCountdown == 0)
                {
                    b_rng.Enabled = true;
                    b_rng.Text = "Roll the Dice !";
                }
                else
                {
                    b_rng.Text = rngCountdown + " clicks left.";
                }
            }
            if (money >= upgradeCost)
                b_upgrade.Enabled = true;
            if (money >= rngCost)
                b_rng_upgrade.Enabled = true;
        }

        private void b_upgrade_Click(object sender, EventArgs e)
        {
            money = money - upgradeCost;
            upgrade = upgrade + 1;
            upgradeCost = upgradeCost * 2;
            b_upgrade.Text = "Upgrade Click  |  Level :  " + upgrade + "  |  Cost :  " + upgradeCost;
            l_money.Text = "Money :  " + money + " $";
            if (money < upgradeCost)
                b_upgrade.Enabled = false;
            if (money < rngCost)
                b_rng_upgrade.Enabled = false;
        }

        private void b_rng_upgrade_Click(object sender, EventArgs e)
        {
            money = money - rngCost;
            if (rng == 0)
            {
                rngCountdown = 100;
                b_rng.Text = rngCountdown + " clicks left.";
            }
            rng = rng + 1;
            rngCost = rngCost + 100;
            b_rng_upgrade.Text = "Upgrade Roll the Dice  |  Level :  " + rng + "  |  Cost :  " + rngCost;
            l_money.Text = "Money :  " + money + " $";
            if (money < upgradeCost)
                b_upgrade.Enabled = false;
            if (money < rngCost)
                b_rng_upgrade.Enabled = false;
        }

        private void b_rng_Click(object sender, EventArgs e)
        {
            money = money + random.Next(-100, rngCost);
            if (money < 0)
                money = 0;
            l_money.Text = "Money :  " + money + " $";
            if (money < upgradeCost)
                b_upgrade.Enabled = false;
            else
                b_upgrade.Enabled = true;
            if (money < rngCost)
                b_rng_upgrade.Enabled = false;
            else
                b_rng_upgrade.Enabled = true;
            rngCountdown = 100;
            b_rng.Text = rngCountdown + " clicks left.";
            b_rng.Enabled = false;
        }
    }
}
