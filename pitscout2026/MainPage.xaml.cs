using pitscout2026.Models;

namespace pitscout2026
{
    public partial class MainPage : ContentPage
    {
        private readonly PitScout pitscout= new();

        public MainPage()
        {
            InitializeComponent();
        }

        private void Drive_Train_Swerve_Clicked(object sender, EventArgs e)
        {
            pitscout.Drive_Train = 1;
        }

        private void Drive_Train_Tank_Clicked(object sender, EventArgs e)
        {
            pitscout.Drive_Train = 2;
        }

        private void Drive_Train_Other_Clicked(object sender, EventArgs e)
        {
            pitscout.Drive_Train = 3;
        }

        private void Preferred_Placement_Left_Clicked(object sender, EventArgs e)
        {
            pitscout.Preferred_Placement = 1;
        }

        private void Preferred_Placement_Middle_Clicked(object sender, EventArgs e)
        {
            pitscout.Preferred_Placement = 2;
        }

        private void Preferred_Placement_Right_Clicked(object sender, EventArgs e)
        {
            pitscout.Preferred_Placement = 3;
        }

        private void Preferred_Placement_None_Clicked(object sender, EventArgs e)
        {
            pitscout.Preferred_Placement = 0;
        }

        private void Auto_Climb_Yes_Clicked(object sender, EventArgs e)
        {
            pitscout.Auto_Climb = true;
        }

        private void Auto_Climb_No_Clicked(object sender, EventArgs e)
        {
            pitscout.Auto_Climb = false;
        }

        private void Auto_Shoot_Yes_Clicked(object sender, EventArgs e)
        {
            pitscout.Auto_Shoot = true;
        }

        private void Auto_Shoot_No_Clicked(object sender, EventArgs e)
        {
            pitscout.Auto_Shoot = false;
        }

        private void Can_Climb_Yes_Clicked(object sender, EventArgs e)
        {
            pitscout.Can_Climb = true;
        }

        private void Can_Climb_No_Clicked(object sender, EventArgs e)
        {
            pitscout.Can_Climb = false;
        }

        private void Travel_Route_Over_Clicked(object sender, EventArgs e)
        {
            pitscout.Travel_Route = 1;
        }

        private void Travel_Route_Under_Clicked(object sender, EventArgs e)
        {
            pitscout.Travel_Route = 2;
        }

        private void Travel_Route_Both_Clicked(object sender, EventArgs e)
        {
            pitscout.Travel_Route = 3;
        }
    }
}
