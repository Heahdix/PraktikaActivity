using EasyCaptcha.Wpf;
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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        string answer = "";

        public Authorization()
        {
            InitializeComponent();
            RemadeCaptcha();
        }

        private void RemadeCaptcha()
        {
            AuthCaptcha.CreateCaptcha(Captcha.LetterOption.Alphanumeric, 4);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (ActivityEntities db = new ActivityEntities())
            {
                if (answer != AuthCaptcha.CaptchaText)
                {
                    MessageBox.Show("Неверная CAPTCHA");
                }
                else
                {
                    var result = db.Users.Where(x => x.Id == Convert.ToInt32(IdNumberText.Text) && x.Password == PasswordText.Password).FirstOrDefault();
                    if (result != null)
                    {
                        CurrentUser.currentUserId = result.Id;

                        if (result.RoleId == 1)
                        {
                            Participant participant = new Participant();
                            participant.Show();
                            this.Close();
                        }
                        else if (result.RoleId == 2)
                        {
                            Moderator moderator = new Moderator();
                            moderator.Show();
                            this.Close();
                        }
                        else if (result.RoleId == 3)
                        {
                            Jury jury = new Jury();
                            jury.Show();
                            this.Close();
                        }
                        else if (result.RoleId == 4)
                        {
                            Organaizer organaizer = new Organaizer();
                            organaizer.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неправильный email или пароль");
                    }
                }
            }
            
        }
    }
}
