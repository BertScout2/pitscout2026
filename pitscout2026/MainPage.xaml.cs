using pitscout2026.Database;
using pitscout2026.Models;

namespace pitscout2026
{
    public partial class MainPage : ContentPage
    {
        private readonly PitScout pitscout = new();
        private readonly pitDataBase db = new();

        public MainPage()
        {
            InitializeComponent();
        }

        private void Team_Num_TextChanged(object? sender, TextChangedEventArgs e)
        {
            if (int.TryParse(Team_Num.Text, out int result))
            {
                if (pitscout.Team_Num != result)
                {
                    pitscout.Team_Num = result;
                    Team_Num.Text = pitscout.Team_Num.ToString();
                }
            }
            else
            {
                Team_Num.Text = pitscout.Team_Num.ToString();
            }
        }
        private void Load_But_Clicked(object? sender, EventArgs e)
        {

        }

        private void Save_But_Clicked(object? sender, EventArgs e)
        {

        }
        private void Init_Data_Clicked(object? sender, EventArgs e)
        {
            var taskInit = Task.Run(()=>db.Init());
            taskInit.Wait();
        }
        private void Drive_Train_Swerve_Clicked(object? sender, EventArgs e)
        {
            Set_Drive_Train(1);
        }


        private void Drive_Train_Tank_Clicked(object? sender, EventArgs e)
        {
            Set_Drive_Train(2);
        }
        private void Drive_Train_Write_TextChanged(object? sender, TextChangedEventArgs e)
        {
            Set_Drive_Train(0);
        }

        private void Preferred_Placement_Left_Clicked(object? sender, EventArgs e)
        {
            pitscout.Preferred_Placement_Left = !pitscout.Preferred_Placement_Left;
            Set_Preferred_Placement_Left(pitscout.Preferred_Placement_Left);
        }

        private void Preferred_Placement_Middle_Clicked(object? sender, EventArgs e)
        {
            pitscout.Preferred_Placement_Middle = !pitscout.Preferred_Placement_Middle;
            Set_Preferred_Placement_Middle(pitscout.Preferred_Placement_Middle);
        }

        private void Preferred_Placement_Right_Clicked(object? sender, EventArgs e)
        {
            pitscout.Preferred_Placement_Right = !pitscout.Preferred_Placement_Right;
            Set_Preferred_Placement_Right(pitscout.Preferred_Placement_Right);
        }

        private void Auto_Climb_Yes_Clicked(object? sender, EventArgs e)
        {
            Set_Auto_Climb(true);
        }

        private void Auto_Climb_No_Clicked(object? sender, EventArgs e)
        {
            Set_Auto_Climb(false);
        }

        private void Auto_Shoot_Yes_Clicked(object? sender, EventArgs e)
        {
            Set_Auto_Shoot(true);
        }

        private void Auto_Shoot_No_Clicked(object? sender, EventArgs e)
        {
            Set_Auto_Shoot(false);
        }

        private void Can_Climb_Yes_Clicked(object? sender, EventArgs e)
        {
            Set_Can_Climb(true);
        }

        private void Can_Climb_No_Clicked(object? sender, EventArgs e)
        {
            Set_Can_Climb(false);
        }

        private void Travel_Route_Over_Clicked(object? sender, EventArgs e)
        {
            Set_Travel_Route(1);
        }

        private void Travel_Route_Under_Clicked(object? sender, EventArgs e)
        {
            Set_Travel_Route(2);
        }

        private void Travel_Route_Both_Clicked(object? sender, EventArgs e)
        {
            Set_Travel_Route(3);
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

        private void Climb_Level_1_Clicked(object? sender, EventArgs e)
        {
            Set_Climb_Level(1);
        }

        private void Climb_Level_2_Clicked(object? sender, EventArgs e)
        {
            Set_Climb_Level(2);
        }

        private void Climb_Level_3_Clicked(object? sender, EventArgs e)
        {
            Set_Climb_Level(3);
        }

        private void Climb_Level_None_Clicked(object? sender, EventArgs e)
        {
            Set_Climb_Level(0);
        }

        private void Climb_Loc_Middle_Clicked(object? sender, EventArgs e)
        {
            pitscout.Climb_Loc_Middle = !
                pitscout.Climb_Loc_Middle;
            Set_Climb_Loc_Middle(pitscout.Climb_Loc_Middle);
        }

        private void Climb_Loc_Side_Clicked(object? sender, EventArgs e)
        {
            pitscout.Climb_Loc_Side = !
                pitscout.Climb_Loc_Side;
            Set_Climb_Loc_Side(pitscout.Climb_Loc_Side);
        }

        //private void Climb_Loc_Both_Clicked(object? sender, EventArgs e)
        //{
        //    Set_Climb_Loc(3);
        //}

        //private void Climb_Loc_None_Clicked(object? sender, EventArgs e)
        //{
        //    Set_Climb_Loc(0);
        //}

        #region setRoutines
        private void Set_Drive_Train(int value)
        {
            pitscout.Drive_Train = value;
            Drive_Train_Swerve.BackgroundColor = value == 1 ? Colors.Green : Colors.Gray;
            Drive_Train_Tank.BackgroundColor = value == 2 ? Colors.Green : Colors.Gray;
        }
        private void Set_Preferred_Placement_Left(bool value)
        {
            pitscout.Preferred_Placement_Left = value;
            Preferred_Placement_Left.BackgroundColor = value ? Colors.Green : Colors.Gray;
        }
        private void Set_Preferred_Placement_Middle(bool value)
        {
            pitscout.Preferred_Placement_Middle = value;
            Preferred_Placement_Middle.BackgroundColor = value ? Colors.Green : Colors.Gray;
        }
        private void Set_Preferred_Placement_Right(bool value)
        {
            pitscout.Preferred_Placement_Right = value;
            Preferred_Placement_Right.BackgroundColor = value ? Colors.Green : Colors.Gray;
        }
        private void Set_Auto_Climb(bool value)
        {
            pitscout.Auto_Climb = value;
            Auto_Climb_Yes.BackgroundColor = value ? Colors.Green : Colors.Gray;
            Auto_Climb_No.BackgroundColor = !value ? Colors.Green : Colors.Gray;
        }
        private void Set_Auto_Shoot(bool value)
        {
            pitscout.Auto_Shoot = value;
            Auto_Shoot_Yes.BackgroundColor = value ? Colors.Green : Colors.Gray;
            Auto_Shoot_No.BackgroundColor = !value ? Colors.Green : Colors.Gray;
        }
        private void Set_Travel_Route(int value)
        {
            pitscout.Travel_Route = value;
            Travel_Route_Over.BackgroundColor = value == 1 ? Colors.Green : Colors.Gray;
            Travel_Route_Under.BackgroundColor = value == 2 ? Colors.Green : Colors.Gray;
            Travel_Route_Both.BackgroundColor = value == 3 ? Colors.Green : Colors.Gray;
        }
        private void Set_Can_Climb(bool value)
        {
            pitscout.Can_Climb = value;
            Can_Climb_Yes.BackgroundColor = value ? Colors.Green : Colors.Gray;
            Can_Climb_No.BackgroundColor = !value ? Colors.Green : Colors.Gray;
        }
        private void Set_Climb_Level(int value)
        {
            pitscout.Climb_Level = value;
            Climb_Level_1.BackgroundColor = value == 1 ? Colors.Green : Colors.Gray;
            Climb_Level_2.BackgroundColor = value == 2 ? Colors.Green : Colors.Gray;
            Climb_Level_3.BackgroundColor = value == 3 ? Colors.Green : Colors.Gray;
            Climb_Level_None.BackgroundColor = value == 0 ? Colors.Green : Colors.Gray;
        }
        //private void Set_Climb_Loc(int value)
        //{
        //    pitscout.Climb_Loc = value;
        //    Climb_Loc_Middle.BackgroundColor = value == 1 ? Colors.Green : Colors.Gray;
        //    Climb_Loc_Side.BackgroundColor = value == 2 ? Colors.Green : Colors.Gray;
        //    Climb_Loc_Both.BackgroundColor = value == 3 ? Colors.Green : Colors.Gray;
        //    Climb_Loc_None.BackgroundColor = value == 0 ? Colors.Green : Colors.Gray;
        //}
        private void Set_Climb_Loc_Middle(bool value)
        {
            pitscout.Climb_Loc_Middle = value;
            Climb_Loc_Middle.BackgroundColor = value ? Colors.Green : Colors.Grey;
        }
        private void Set_Climb_Loc_Side(bool value)
        {
            pitscout.Climb_Loc_Side = value;
            Climb_Loc_Side.BackgroundColor = value ? Colors.Green : Colors.Grey;
        }

        #endregion

        private void Comments_TextChanged(object? sender, TextChangedEventArgs e)
        {
            pitscout.Comments = Comments.Text;
        }
    }
}
