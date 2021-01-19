using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleSim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Pepe leftPepe;
        private Pepe rightPepe;

        private readonly Random random;

        public MainWindow()
        {
            InitializeComponent();
            random = new Random();

            StartOrReboot();
        }

        private void btnLeftAttack_Click(object sender, RoutedEventArgs e)
        {
            int dmgDealt = leftPepe.DealDamage(rightPepe);

            ShowDamageMessage(leftPepe, dmgDealt);
            btnLeftAttack.IsEnabled = false;
            btnRightAttack.IsEnabled = true;
            UpdatePepes();
        }

        private void btnRightAttack_Click(object sender, RoutedEventArgs e)
        {
            int dmgDealt = rightPepe.DealDamage(leftPepe);
            ShowDamageMessage(rightPepe, dmgDealt);

            btnLeftAttack.IsEnabled = true;
            btnRightAttack.IsEnabled = false;
            UpdatePepes();
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            StartOrReboot();
        }

        private void UpdatePepes()
        {
            pbHpLeft.Value = leftPepe.Healthpoints;
            lblHealthLeft.Content = leftPepe.Healthpoints;

            pbHpRight.Value = rightPepe.Healthpoints;
            lblHealthRight.Content = rightPepe.Healthpoints;

            if (leftPepe.IsDead())
            {
                imgPepeLeft.Opacity = 0.25;

                GameOver(leftPepe);
            }


            if (rightPepe.IsDead())
            {
                imgPepeRight.Opacity = 0.25;

                GameOver(rightPepe);
            }
        }

        private void StartOrReboot()
        {
            btnRestart.IsEnabled = false;
            leftPepe = new Pepe("Pepe Left");
            rightPepe = new Pepe("Pepe Right");

            imgPepeLeft.Opacity = 1;
            imgPepeRight.Opacity = 1;
            pbHpRight.Maximum = rightPepe.Healthpoints;
            pbHpLeft.Maximum = leftPepe.Healthpoints;

            UpdatePepes();

            if(random.Next(0, 50) > 25)
            {
                btnLeftAttack.IsEnabled = false;
                btnRightAttack.IsEnabled = true;
            } else
            {
                btnLeftAttack.IsEnabled = true;
                btnRightAttack.IsEnabled = false;
            }
        }

        private void GameOver(Pepe lostPepe)
        {
            MessageBox.Show("Pepe " + lostPepe.Name + " Lost the game!");

            btnRestart.IsEnabled = true;

            btnLeftAttack.IsEnabled = false;
            btnRightAttack.IsEnabled = false;
        }


        private void ShowDamageMessage(Pepe dmgDealer, int amountOfDamage)
        {
            if (amountOfDamage > 20)
            {
                MessageBox.Show(dmgDealer.Name + " DEALT A CRITICAL HIT OF " + amountOfDamage + "!!!");
            } else if(amountOfDamage == 0)
            {
                MessageBox.Show(dmgDealer.Name + " MISSED!!!");
            }
        }
    }
}
