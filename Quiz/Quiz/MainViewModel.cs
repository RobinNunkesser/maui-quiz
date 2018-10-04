using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Quiz
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly List<(string, bool)> questions =
            new List<(string, bool)> { 
            ("Das Videospiel Donkey Kong sollte ursprünglich Popeye als Hauptfigur haben.", true),
            ("Die Farbe Orange wurde nach der Frucht benannt.", true),
            ("In der griechischen Mythologie ist Hera die Göttin der Ernte.", false),
            ("Liechtenstein hat keinen eigenen Flughafen.", true),
            ("Die meisten Subarus werden in China hergestellt.", false)};

        public string Question => questions[index].Item1;
        public ICommand AnswerCommand { get; private set; }
        public ICommand SkipCommand { get; private set; }

        private string answer;
        public string Answer
        {
            get => answer;
            private set
            {
                if (value!=answer) {
                    answer = value;
                    OnPropertyChanged("Answer");
                }
            }
        }

        private int index;
        public int Index
        {
            get => index;
            set
            {
                if (value != index)
                {
                    index = value;
                    OnPropertyChanged("Question");
                }
            }
        }


        public MainViewModel()
        {
            Index = 0;
            AnswerCommand = new Command<bool>(EvaluateAnswer);
            SkipCommand = new Command(Skip);
        }

        void EvaluateAnswer(bool value) {
            if (questions[index].Item2 == value) {
                StatisticsSingleton.Instance.CorrectAnswers++;
                Answer = "Richtig!";
            } else {
                StatisticsSingleton.Instance.FalseAnswers++;
                Answer = "Falsch!";
            }
            IncreaseIndex(); 
        }

        void Skip()
        {
            StatisticsSingleton.Instance.SkippedAnswers++;
            IncreaseIndex();
        }

        void IncreaseIndex() {
            Index = ++Index % questions.Count;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }
    }
}
