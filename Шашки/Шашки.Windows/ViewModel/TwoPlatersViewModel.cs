using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Шашки.View;
using Windows.UI.Popups;

namespace Шашки.ViewModel
{
    class TwoPlayersViewModel
    {
        //Коды фигур:
        //1 - чёрная обычная
        //2 - чёрная в дамках
        //3 - белая обычная
        //4 - белая в дамках
        //Properties:
        public INotifyCollectionChanged Chekers { get { return checkers; } }
        //Fields:
        private ObservableCollection<CheckerControl> checkers;
        public void Start()
        {
            checkers = new ObservableCollection<CheckerControl>();
            for (int i = 1; i < 8; i += 2)
                checkers.Add(new CheckerControl(1, i, 0, true));
            for (int i = 1; i < 8; i += 2)
                checkers.Add(new CheckerControl(1, i, 2, true));
            for (int i = 0; i < 8; i += 2)
                checkers.Add(new CheckerControl(1, i, 1, true));
            for (int i = 1; i < 8; i += 2)
                checkers.Add(new CheckerControl(3, i, 6, true));
            for (int i = 0; i < 8; i += 2)
                checkers.Add(new CheckerControl(3, i, 5, true));
            for (int i = 0; i < 8; i += 2)
                checkers.Add(new CheckerControl(3, i, 7, true));
        }
    }
}
