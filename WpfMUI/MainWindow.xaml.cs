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

        //static Label GamePlaceLabel = new Label();


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

            //Action<string> ChangeLabel = words => Console.WriteLine(words);


            /*string charName = player.Name;
            int damage;
            int mobHp;
            bool hasEscaped = false;
            int hp = player.HP;
            char userChoice;
            int currentLocation = 301;*/
            thisRoom = SqliteDataAccess.LoadRoom(currentLocation);
            charName = player.Name;
            hp = player.HP;
            /*ChangeLabel("MAIN MENU: \n");
            
            OptionsMenu.HelpMenu();
            ChangeLabel($"{charName}, enter numeric value from menu to select an option: ");
            do
            {
                *//*Room thisRoom = SqliteDataAccess.LoadRoom(currentLocation);
                Mob thisMob = Mob.MobSpawner();*//*
                mobHp = thisMob.HP;
                ChangeLabel("\n");
                ChangeLabel($"You are in {thisRoom.Name} ( {thisRoom.ID} )");
                ChangeLabel("There is a " + thisMob.Name + " in the room with you!");
                ChangeLabel(thisRoom.Description);
                ChangeLabel("Your exit(s) are ");
                if (thisRoom.NorthExit != -1) { ChangeLabel(" N "); }
                if (thisRoom.SouthExit != -1) { ChangeLabel(" S "); }
                if (thisRoom.WestExit != -1) { ChangeLabel(" W "); }
                if (thisRoom.EastExit != -1) { ChangeLabel(" E "); }
                ChangeLabel("");
                userChoice //= Console.ReadLine()[0]; //Change this

                switch (userChoice)
                {
                    case '1':
                        if (thisRoom.NorthExit != -1)
                        { currentLocation = thisRoom.NorthExit; }
                        else { ChangeLabel("There is nothing for you here."); }
                        break;
                    case '2':
                        if (thisRoom.SouthExit != -1)
                        { currentLocation = thisRoom.SouthExit; }
                        else { ChangeLabel("Why would you walk into a wall?"); }
                        break;
                    case '3':
                        if (thisRoom.WestExit != -1)
                        { currentLocation = thisRoom.WestExit; }
                        else { ChangeLabel("The definition of insanity is doing the same thing over and over... I'm sure you've heard this before"); }
                        break;
                    case '4':
                        if (thisRoom.EastExit != -1)
                        { currentLocation = thisRoom.EastExit; }
                        else { ChangeLabel("Sorry, you can't walk through walls.... yet"); }
                        break;
                    case '5':
                        // TODO Move entire to combat Class method and then just call method here
                        while (mobHp >= 1 && hasEscaped != true && hp >= 1)
                        {
                            if (hp >= 1)
                            {
                                ChangeLabel("You are in a fight with " + thisMob.Name + " who currently has " + mobHp + "!");
                                ChangeLabel("1. Attack");
                                ChangeLabel("2. Run away");
                                char combatChoice = Console.ReadLine()[0];
                                if (combatChoice == '1')
                                {
                                    int damage2 = Attack2(thisMob.HP);
                                    ChangeLabel("You've hit the " + thisMob.Name + " for " + damage2 + "!");
                                    mobHp = HP(mobHp, damage2);
                                    damage = Attack(player.HP);
                                    ChangeLabel($"You've taken {damage} points of damage");
                                    hp = HP(hp, damage);
                                    ChangeLabel($"Your hp is at {hp}\n");
                                }
                                else if (combatChoice == '2')
                                {
                                    hasEscaped = CombatSystem.Escape(hasEscaped);
                                    if (hasEscaped == true)
                                    {
                                        ChangeLabel("You've escaped successfully!");

                                    }
                                    else
                                    {
                                        ChangeLabel("You've failed to escape!");
                                        damage = Attack(player.HP);
                                        ChangeLabel($"You've taken {damage} points of damage");
                                        hp = HP(hp, damage);
                                        ChangeLabel($"Your hp is at {hp}\n");
                                    }
                                }
                                else
                                {
                                    ChangeLabel("Not a valid choice!");
                                }
                            }
                        }
                        if (mobHp < 1)
                        {
                            ChangeLabel("You've killed the enemy!");
                        }
                        else if (hp < 1)
                        {
                            ChangeLabel("You are dead.");
                        }
                        break;
                    case '6':
                        OptionsMenu.Exit();
                        break;
                    case '7':
                        OptionsMenu.WriteExploreMenu();
                        //ChangeLabel("Menu");
                        char menuOption = Console.ReadLine()[0];
                        OptionsMenu.ExploreMenu(menuOption);
                        break;
                    default:
                        ChangeLabel("Not a valid option. Maybe check your case and spelling?");
                        break;
                }
            }
            while (userChoice != '6');
            ChangeLabel("Press enter to exit...");
            // Program ends
            Console.ReadLine(); */
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

        private void HandleMovement()
        {
            thisRoom = SqliteDataAccess.LoadRoom(currentLocation);
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
                
                
            if (thisRoom.NorthExit != -1)
            { currentLocation = thisRoom.NorthExit; }
            else { description += "There is nothing for you here.\n"; }

            if (thisRoom.SouthExit != -1)
            { currentLocation = thisRoom.SouthExit; }
            else { description += "Why would you walk into a wall?\n"; }

            if (thisRoom.WestExit != -1)
            { currentLocation = thisRoom.WestExit; }
            else { description += "The definition of insanity is doing the same thing over and over... I'm sure you've heard this before\n"; }

            if (thisRoom.EastExit != -1)
            { currentLocation = thisRoom.EastExit; }
            else { description += "Sorry, you can't walk through walls.... yet\n"; }

            Message(description);
        }

        private void NorthB_Click(object sender, RoutedEventArgs e)
        {
            HandleMovement();
        }

        private void SouthB_Click(object sender, RoutedEventArgs e)
        {
            HandleMovement();
        }

        private void EastB_Click(object sender, RoutedEventArgs e)
        { 
            HandleMovement(); 
        }

        private void WestB_Click(object sender, RoutedEventArgs e)
        {
            HandleMovement();
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
