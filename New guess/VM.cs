using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace New_guess
{
    class VM:INotifyPropertyChanged
    {
        Random r = new Random();
        public string View
        {
            get { return _view; }
            set { _view = value; OnPropertyChanged(); }
        }
        private string _view;
        public int Random
        {
            get { return _random; }
            set { _random = value; OnPropertyChanged(); }
        }
        private int _random;
        public string LastGuess
        {
            get { return _lastGuess; }
            set { _lastGuess = value; OnPropertyChanged(); }
        }
        private string _lastGuess;
        public int Guess
        {
            get { return _guess; }
            set { _guess = value; OnPropertyChanged(); }
        }
        private int _guess;
        public string AllGuess
        {
            get { return _allGuess; }
            set { _allGuess = value; OnPropertyChanged(); }
        }
        private string _allGuess;
        public void Generate()
        {
            Random = r.Next(1, 101);
            View = "hidden";
        }
        public VM()
        {
            Generate();         
        }
        public void docalc()
        {
             LastGuess = Guess.ToString();
            if (Guess == Random)
            {
                View = "Visible";
                System.Windows.MessageBox.Show("Congrats. U are right!!!");
                Generate();
                LastGuess = "";
                AllGuess = "";
                Guess = 0;
            }
            else if (Guess > Random)
            {
                System.Windows.MessageBox.Show("Too high, try again");
                AllGuess = AllGuess + LastGuess + ", ";
            }
            else if (Guess < Random)
            {
                System.Windows.MessageBox.Show("Too low, try again");
                AllGuess = AllGuess + LastGuess + ", ";
            }
        }
        public void Check()
        {
            System.Windows.MessageBox.Show(Random.ToString());
            Generate();
            LastGuess = "";
            AllGuess = "";
            Guess = 0;

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
