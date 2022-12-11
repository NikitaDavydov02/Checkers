using Шашки.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
using Шашки.ViewModel;
// Документацию по шаблону элемента "Основная страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=234237

namespace Шашки.View
{
    /// <summary>
    /// Основная страница, которая обеспечивает характеристики, являющимися общими для большинства приложений.
    /// </summary>
    public sealed partial class TwoPlayers : Page
    {
        TwoPlayersSettings settings;
        private TwoPlayersViewModel viewModel;
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// Эту настройку можно изменить на модель строго типизированных представлений.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper используется на каждой странице для облегчения навигации и 
        /// управление жизненным циклом процесса
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public TwoPlayers()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
            viewModel = new TwoPlayersViewModel();
            DataContext = viewModel;
            viewModel.Start();
            c = new CheckerControl(3, 3, 3, true);
        }

        /// <summary>
        /// Заполняет страницу содержимым, передаваемым в процессе навигации. Любое сохраненное состояние также является
        /// при повторном создании страницы из предыдущего сеанса.
        /// </summary>
        /// <param name="sender">
        /// Источник события; обычно <see cref="Common.NavigationHelper"/>
        /// </param>
        /// <param name="e">Данные события, предоставляющие параметр навигации, который передается
        /// <see cref="Frame.Navigate(Type, Object)"/> при первоначальном запросе этой страницы, и
        /// словарь состояния, сохраненного этой страницей в ходе предыдущего
        /// сеансом. Состояние будет равно значению NULL при первом посещении страницы.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Сохраняет состояние, связанное с данной страницей, в случае приостановки приложения или
        /// удаления страницы из кэша навигации.  Значения должны соответствовать требованиям сериализации
        /// требования <see cref="Common.SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">Источник события; обычно <see cref="Common.NavigationHelper"/></param>
        /// <param name="e">Данные события, которые предоставляют пустой словарь для заполнения
        /// сериализуемым состоянием.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region Регистрация NavigationHelper

        /// Методы, предоставленные в этом разделе, используются исключительно для того, чтобы
        /// NavigationHelper для отклика на методы навигации страницы.
        /// 
        /// Логика страницы должна быть размещена в обработчиках событий для 
        /// <see cref="Common.NavigationHelper.LoadState"/>
        /// и <see cref="Common.NavigationHelper.SaveState"/>.
        /// Параметр навигации доступен в методе LoadState 
        /// в дополнение к состоянию страницы, сохраненному в ходе предыдущего сеанса.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            settings = (TwoPlayersSettings)e.Parameter;
            if (!String.IsNullOrEmpty(settings.NameOfFirstPlayer))
                firstPlayerName.Text = settings.NameOfFirstPlayer;
            else
                firstPlayerName.Text = "No Name";
            if (!String.IsNullOrEmpty(settings.AgeOfFirstPlayer))
                firstPlayerAge.Text = settings.AgeOfFirstPlayer;
            else
                firstPlayerAge.Text = "No Age";
            firstPlayerImage.Source = settings.ImageOfFirstPlayer;
            if (settings.ImageOfFirstPlayer == null)
                firstPlayerImage.Source = CreateBitmapNoImageFromAssets();
            CreateFlagByCountry(settings.CountryOfFirstPlayer, 1);

            if (!String.IsNullOrEmpty(settings.NameOfSecondPlayer))
                secondPlayerName.Text = settings.NameOfSecondPlayer;
            else
                secondPlayerName.Text = "No Name";
            if (!String.IsNullOrEmpty(settings.AgeOfSecondPlayer))
                secondPlayerAge.Text = settings.AgeOfSecondPlayer;
            else
                secondPlayerAge.Text = "No Age";
            secondPlayerImage.Source = settings.ImageOfSecondPlayer;
            if (settings.ImageOfSecondPlayer == null)
                secondPlayerImage.Source = CreateBitmapNoImageFromAssets();
            CreateFlagByCountry(settings.CountryOfSecondPlayer, 2);
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void CreateFlagByCountry(Country country, int indexOfPlayer)
        {
            if (indexOfPlayer == 1)
            {
                flagOfFirstPlayer.Source = CreateBitmapImageFromAssets(country);
            }
            else
            {
                flagOfSecondPlayer.Source = CreateBitmapImageFromAssets(country);
            }
        }
        private BitmapImage CreateBitmapNoImageFromAssets()
        {
            return new BitmapImage(new Uri("ms-appx:///Assets/NoImage.png"));
        }
        private BitmapImage CreateBitmapImageFromAssets(Country country)
        {
            BitmapImage bi = new BitmapImage();
            if (country == Country.Россия)
                bi = new BitmapImage(new Uri("ms-appx:///Assets/Flags/Россия.png"));
            if (country == Country.USA)
                bi = new BitmapImage(new Uri("ms-appx:///Assets/Flags/США.png"));
            return bi;
        }
    }
}
