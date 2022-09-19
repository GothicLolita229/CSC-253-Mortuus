using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortuusClassLibrary
{
    public abstract class LivingCreature
    {
        private string _idNumber;
        private string _name;
        private string _race;
        private string _lcclass;
        private string _description;
        private int _hp;
        private int _ac;

        public LivingCreature(string idNumber, string name, string race, string lcclass, string description, int hp, int ac)
        {
            _idNumber = idNumber;
            _name = name;
            _race = race;
            _lcclass = lcclass;
            _description = description;
            _hp = hp;
            _ac = ac;
        }

        public string IDNumber
        {
            get { return _idNumber; }
            set { }
        }
        public string Name
        {
            get { return _name; }
            set { }
        }
        public string Race
        {
            get { return _race; }
            set { }
        }
        public string LcClass
        {
            get { return _lcclass; }
            set { }
        }
        public string Description
        {
            get { return _description; }
            set { }
        }
        public int HP
        {
            get { return _hp; }
            set { }
        }
        public int AC
        {
            get { return _ac; }
            set { }
        }
    }
}
