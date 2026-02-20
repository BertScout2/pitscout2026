using pitscout2026.Models;

namespace pitscout2026
{
    public partial class MainPage : ContentPage
    {
        private readonly PitScout pitscout = new();

        public MainPage()
        {
            InitializeComponent();
        }

        private void Drive_Train_Swerve_Clicked(object? sender, EventArgs e)
        {
            Set_Drive_Train(1);
        }
        

        private void Drive_Train_Tank_Clicked(object? sender, EventArgs e)
        {
            Set_Drive_Train(2);
        }

        private void Drive_Train_Other_Clicked(object? sender, EventArgs e)
        {
            Set_Drive_Train(3);
        }

        private void Preferred_Placement_Left_Clicked(object? sender, EventArgs e)
        {
            pitscout.Preferred_Placement = 1;
        }

        private void Preferred_Placement_Middle_Clicked(object? sender, EventArgs e)
        {
            pitscout.Preferred_Placement = 2;
        }

        private void Preferred_Placement_Right_Clicked(object? sender, EventArgs e)
        {
            pitscout.Preferred_Placement = 3;
        }

        private void Preferred_Placement_None_Clicked(object? sender, EventArgs e)
        {
            pitscout.Preferred_Placement = 0;
        }

        private void Auto_Climb_Yes_Clicked(object? sender, EventArgs e)
        {
            pitscout.Auto_Climb = true;
        }

        private void Auto_Climb_No_Clicked(object? sender, EventArgs e)
        {
            pitscout.Auto_Climb = false;
        }

        private void Auto_Shoot_Yes_Clicked(object? sender, EventArgs e)
        {
            pitscout.Auto_Shoot = true;
        }

        private void Auto_Shoot_No_Clicked(object? sender, EventArgs e)
        {
            pitscout.Auto_Shoot = false;
        }

        private void Can_Climb_Yes_Clicked(object? sender, EventArgs e)
        {
            pitscout.Can_Climb = true;
        }

        private void Can_Climb_No_Clicked(object? sender, EventArgs e)
        {
            pitscout.Can_Climb = false;
        }

        private void Travel_Route_Over_Clicked(object? sender, EventArgs e)
        {
            pitscout.Travel_Route = 1;
        }

        private void Travel_Route_Under_Clicked(object? sender, EventArgs e)
        {
            pitscout.Travel_Route = 2;
        }

        private void Travel_Route_Both_Clicked(object? sender, EventArgs e)
        {
            pitscout.Travel_Route = 3;
        }

        private void Best_Auto_TextChanged(object? sender, TextChangedEventArgs e)
        {
            pitscout.Auto_Best = Best_Auto.Text;
        }

        private void Max_Fuel_TextChanged(object? sender, TextChangedEventArgs e)
        {
            // pitscout.Max_Fuel = int.Parse(Max_Fuel.Text);
            if (int.TryParse(Max_Fuel.Text, out int result))
            {
                if (pitscout.Max_Fuel != result)
                {
                    pitscout.Max_Fuel = result;
                    Max_Fuel.Text = pitscout.Max_Fuel.ToString();
                }
            }
            else
            {
                Max_Fuel.Text = pitscout.Max_Fuel.ToString();
            }
        }

        private void Fps_TextChanged(object? sender, TextChangedEventArgs e)
        {
            // pitscout.Fps = int.Parse(Fps.Text);
            if (int.TryParse(Fps.Text, out int result))
            {
                if (pitscout.Fps != result)
                {
                    pitscout.Fps = result;
                    Fps.Text = pitscout.Fps.ToString();
                }
            }
            else
            {
                Fps.Text = pitscout.Fps.ToString();
            }
        }

        #region setRoutines
        private void Set_Drive_Train(int value)
        {
            pitscout.Drive_Train = value;
            Drive_Train_Swerve.BackgroundColor = value == 1 ? Colors.Green : Colors.Gray;
            Drive_Train_Tank.BackgroundColor = value == 2 ? Colors.Green : Colors.Gray;
            Drive_Train_Other.BackgroundColor = value == 3 ? Colors.Green : Colors.Gray;
        }
        #endregion
    }
}
