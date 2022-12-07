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
using MortuusClassLibrary;

namespace WpfMUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Game();
        }

        private string charName; //= player.Name;
        private int damage;
        private int mobHp;
        private bool hasEscaped = false;
        private int hp; //= player.HP;
        private char userChoice;
        private int currentLocation = 301;
        //added something to the WPF to check for git upload. And by something, I mean this comment

        private Room thisRoom; // = SqliteDataAccess.LoadRoom(currentLocation);
        private Mob thisMob = Mob.MobSpawner();
        private Player player;

        public void ChangeLabel(string words)
        {
            GamePlaceLabel.Content = words;
        }

        public void Message(string words)
        {
            InfoDisplay.Text = words;
        }

        delegate int AttackPoints(int hp);
        delegate int HealthPoints(int hp, int damage);
        delegate void EnemyDialog();
        public void Game()
        {
            AttackPoints Attack = CombatSystem.AttackPoints;
            AttackPoints Attack2 = CombatSystem.AttackPoints;
            HealthPoints HP = CombatSystem.CalcHealth;
            EnemyDialog DisplayDialog = delegate ()
            {
                Message("That serves you right! It'll teach you not to challenge us again. You hear the enemies shout as your vision fades.");
            };
            // MAKE THIS WORK CIARA
            player = LoadPlayer.PlayerInfo(this);

            thisRoom = Room.rooms.FindIndex(locus => locus.ID == currentLocation);//SqliteDataAccess.LoadRoom(currentLocation);
            charName = player.Name;
            hp = player.HP;
            
        }

        public static List<object> ShowStuffs(int thisRoom)
        {
            List<object> roomInv = SqliteDataAccess.LoadRoomInv(thisRoom);
            
            if (!roomInv[2].Equals(-1))
            {
                Item item = SqliteDataAccess.LoadItem(roomInv[2]);
                roomInv[2] = item; //QuestItem
            }
            if (!roomInv[3].Equals(-1))
            {
                Weapon weapon = SqliteDataAccess.LoadWeapon(roomInv[3]);
                roomInv[3] = weapon; //Weapon
            }
            if (!roomInv[4].Equals(-1))
            {
                Potion potion = SqliteDataAccess.LoadPotion(roomInv[4]);
                roomInv[4] = potion; //Potion
            }
            if (!roomInv[5].Equals(-1))
            {
                Treasure treasure = SqliteDataAccess.LoadTreasure(roomInv[5]);
                roomInv[5] = treasure; //Treasure
            }
            if (!roomInv[6].Equals(-1))
            {
                Mob mob = SqliteDataAccess.LoadMob(roomInv[6]);
                roomInv[6] = mob; //Mob
            }

            return roomInv;
        }

        private string RoomInfo()
        {
            thisRoom = Room.rooms.FindIndex(locus => locus.ID == currentLocation);//SqliteDataAccess.LoadRoom(currentLocation); // FIXME Update to new SQLite method 
            thisMob = Mob.MobSpawner();
            mobHp = thisMob.HP;
            string exits = "";
            string description = "";
            if (thisRoom.NorthExit != -1) { exits += " N "; }
            if (thisRoom.SouthExit != -1) { exits += " S "; }
            if (thisRoom.WestExit != -1) { exits += " W "; }
            if (thisRoom.EastExit != -1) { exits += " E "; }
            description += $"You are in {thisRoom.Name} ( {thisRoom.ID} ) \n There is a {thisMob.Name} in the room with you!\n" +
                $"{thisRoom.Description} \n Your exit(s) are : {exits} \n";
            return description;
        }
        

        private void NorthB_Click(object sender, RoutedEventArgs e)
        {
            if (thisRoom.NorthExit != -1)
            {
                InfoDisplay.Text = "";
                InfoDisplay.Text = RoomInfo();
                currentLocation = thisRoom.NorthExit;
            }
            else 
            {
                InfoDisplay.Text += "There is nothing for you here.\n"; 
            }
        }

        private void SouthB_Click(object sender, RoutedEventArgs e)
        {
            if (thisRoom.SouthExit != -1)
            {
                InfoDisplay.Text = "";
                InfoDisplay.Text = RoomInfo();
                currentLocation = thisRoom.SouthExit; 
            }
            else 
            {
                InfoDisplay.Text += "Why would you walk into a wall?\n"; 
            }
        }

        private void EastB_Click(object sender, RoutedEventArgs e)
        {
            if (thisRoom.SouthExit != -1)
            {
                InfoDisplay.Text = "";
                InfoDisplay.Text = RoomInfo();
                currentLocation = thisRoom.SouthExit;
            }
            else
            {
                InfoDisplay.Text += "Sorry, you can't walk through walls.... yet\n";
            }
        }

        private void WestB_Click(object sender, RoutedEventArgs e)
        {
            if (thisRoom.SouthExit != -1)
            {
                InfoDisplay.Text = "";
                InfoDisplay.Text = RoomInfo();
                currentLocation = thisRoom.SouthExit;
            }
            else
            {
                InfoDisplay.Text += "The definition of insanity is doing the same thing over and over... I'm sure you've heard this before\n";
            }
        }

        private void AttackB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitB_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
