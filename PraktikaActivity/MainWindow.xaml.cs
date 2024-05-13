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

namespace PraktikaActivity
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Events> events = new List<Events>();

        public MainWindow()
        {
            InitializeComponent();


            using (ActivityEntities activityEntities = new ActivityEntities())
            {
                events = activityEntities.Events.ToList();

                EventsListView.ItemsSource = events;

                List<Directions> directions = new List<Directions>();
                directions.Add(new Directions() { DirectionName = "Любое" });
                directions.AddRange(activityEntities.Directions.OrderBy(x=>x.DirectionName).ToList());

                DirectionComboBox.ItemsSource = directions;

                DirectionComboBox.SelectedIndex = 0;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
        }

        private void DirectionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (ActivityEntities activityEntities = new ActivityEntities())
            {
                if (DirectionComboBox.SelectedIndex != 0)
                {

                    events = activityEntities.Events.Where(x => x.DirectionId == ((Directions)DirectionComboBox.SelectedItem).Id).ToList();

                    EventsListView.ItemsSource = events;
                }
                else
                {
                    events = activityEntities.Events.ToList();

                    EventsListView.ItemsSource = events;
                }
            }
        }
    }
}
