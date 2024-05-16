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
using System.Windows.Shapes;

namespace PraktikaActivity
{
    /// <summary>
    /// Логика взаимодействия для Organaizer.xaml
    /// </summary>
    public partial class Organaizer : Window
    {
        public Organaizer()
        {
            InitializeComponent();

            Users user = new Users();

            using(ActivityEntities activityEntities = new ActivityEntities())
            {
                user = activityEntities.Users.Where(x => x.Id == CurrentUser.currentUserId).FirstOrDefault();
            }

            DataContext = user;

            DateTime currentTime = DateTime.Now;
            int currentHour = currentTime.Hour;

            string welcomeMessage;
            if (currentHour >= 9 && currentHour < 11)
            {
                welcomeMessage = "Доброе утро";
            }
            else if (currentHour >= 11 && currentHour < 18)
            {
                welcomeMessage = "Добрый день";
            }
            else
            {
                welcomeMessage = "Добрый вечер";
            }
            WelcomeText.Text = welcomeMessage;
            FIO.Text = user.FullName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RgistrationOfJuryModerator rgistrationOfJuryModerator = new RgistrationOfJuryModerator();
            rgistrationOfJuryModerator.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }
    }
}
