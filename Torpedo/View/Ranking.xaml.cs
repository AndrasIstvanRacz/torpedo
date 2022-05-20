using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Torpedo.Model;

namespace Torpedo.View
{
    /// <summary>
    /// Interaction logic for Ranking.xaml
    /// </summary>
    public partial class Ranking : Window
    {
        private List<Rank> allTimeRank = new List<Rank>();
        private DataHandling dataHandling = new DataHandling();
        public Ranking()
        {
            InitializeComponent();
            allTimeRank = dataHandling.getRankList();

            listRank.ItemsSource = allTimeRank;

        }

        private void clickBackButton(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
