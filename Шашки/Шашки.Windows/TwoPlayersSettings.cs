using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Шашки
{
    struct TwoPlayersSettings
    {
        public string NameOfFirstPlayer;
        public string NameOfSecondPlayer;
        public string AgeOfFirstPlayer;
        public string AgeOfSecondPlayer;
        public Country CountryOfFirstPlayer;
        public Country CountryOfSecondPlayer;
        public BitmapImage ImageOfFirstPlayer;
        public BitmapImage ImageOfSecondPlayer;
        public TimeSpan TimeOfGame;
        public TimeSpan TimeOfMove;
    }
}
