using pitscout2026.Database;
using pitscout2026.Models;

namespace pitscout2026;

public partial class MainPage : ContentPage
{
    private PitScout pitscout = new();
    private readonly PitDataBase db = new();

    public MainPage()
    {
        InitializeComponent();
        Team_Num_Entry.Focus();
    }

    private void Team_Num_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(Team_Num_Entry.Text)) return;
        if (int.TryParse(Team_Num_Entry.Text, out int result))
        {
            if (pitscout.Team_Num != result)
            {
                pitscout.Team_Num = result;
                Team_Num_Entry.Text = pitscout.Team_Num.ToString();
            }
        }
        else
        {
            Team_Num_Entry.Text = pitscout.Team_Num.ToString();
        }
    }

    private void Load_But_Clicked(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Team_Num_Entry.Text)) return;
        if (!int.TryParse(Team_Num_Entry.Text, out int team) || team <= 0)
        {
            return;
        }
        Load_But.IsEnabled = false;
        Load_But.IsVisible = false;
        Save_But.IsEnabled = true;
        Save_But.IsVisible = true;
        PitScoutLayout.IsVisible = true;
        var task = Task.Run(() => db.GetPitScoutAsync(team));
        var oldItem = task.Result;
        if (oldItem == null)
        {
            pitscout = new()
            {
                Team_Num = team
            };
        }
        else
        {
            var oldChanged = oldItem.Changed;
            pitscout = oldItem;
            FillFields();
            pitscout.Changed = oldChanged;
            SaveToDB();
        }
    }

    private void Save_But_Clicked(object? sender, EventArgs e)
    {
        SaveToDB();
        pitscout = new PitScout();
        ClearFields();
        Load_But.IsEnabled = true;
        Load_But.IsVisible = true;
        Save_But.IsEnabled = false;
        Save_But.IsVisible = false;
        PitScoutLayout.IsVisible = false;
        Team_Num_Entry.Focus();
    }

    private void Drive_Train_Swerve_Clicked(object? sender, EventArgs e)
    {
        Set_Drive_Train(1);
        SaveData();
        pitscout.Drive_Train_Other = "";
        Drive_Train_Other.Text = "";
    }

    private void Drive_Train_Tank_Clicked(object? sender, EventArgs e)
    {
        Set_Drive_Train(2);
        SaveData();
        pitscout.Drive_Train_Other = "";
        Drive_Train_Other.Text = "";
    }

    private void Drive_Train_Other_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if (Drive_Train_Other.Text == "") return;
        if (pitscout.Drive_Train_Other != Drive_Train_Other.Text)
        {
            Set_Drive_Train(0);
            SaveData();
            pitscout.Drive_Train_Other = Drive_Train_Other.Text;
        }
    }

    private void Start_Left_Clicked(object? sender, EventArgs e)
    {
        pitscout.Start_Left = !pitscout.Start_Left;
        Set_Preferred_Placement_Left(pitscout.Start_Left);
        SaveData();
    }

    private void Start_Middle_Clicked(object? sender, EventArgs e)
    {
        pitscout.Start_Middle = !pitscout.Start_Middle;
        Set_Preferred_Placement_Middle(pitscout.Start_Middle);
        SaveData();
    }

    private void Start_Right_Clicked(object? sender, EventArgs e)
    {
        pitscout.Start_Right = !pitscout.Start_Right;
        Set_Preferred_Placement_Right(pitscout.Start_Right);
        SaveData();
    }

    private void Auto_Climb_Yes_Clicked(object? sender, EventArgs e)
    {
        Set_Auto_Climb(true);
        SaveData();
    }

    private void Auto_Climb_No_Clicked(object? sender, EventArgs e)
    {
        Set_Auto_Climb(false);
        SaveData();
    }

    private void Auto_Shoot_Yes_Clicked(object? sender, EventArgs e)
    {
        Set_Auto_Shoot(true);
        SaveData();
    }

    private void Auto_Shoot_No_Clicked(object? sender, EventArgs e)
    {
        Set_Auto_Shoot(false);
        SaveData();
    }

    private void Can_Climb_Yes_Clicked(object? sender, EventArgs e)
    {
        Set_Can_Climb(true);
        SaveData();
    }

    private void Can_Climb_No_Clicked(object? sender, EventArgs e)
    {
        Set_Can_Climb(false);
        SaveData();
    }

    private void Travel_Route_Over_Clicked(object? sender, EventArgs e)
    {
        pitscout.Travel_Route_Over = !
            pitscout.Travel_Route_Over;
        Set_Travel_Route_Over(pitscout.Travel_Route_Over);
        SaveData();
    }

    private void Travel_Route_Under_Clicked(object? sender, EventArgs e)
    {
        pitscout.Travel_Route_Under = !pitscout.Travel_Route_Under;
        Set_Travel_Route_Under(pitscout.Travel_Route_Under);
        SaveData();
    }

    private void Best_Auto_TextChanged(object? sender, TextChangedEventArgs e)
    {
        pitscout.Auto_Best = Best_Auto.Text;
        SaveData();
    }

    private void Max_Fuel_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(Max_Fuel.Text)) return;
        if (int.TryParse(Max_Fuel.Text, out int result))
        {
            if (pitscout.Max_Fuel != result)
            {
                pitscout.Max_Fuel = result;
                SaveData();
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
        if (string.IsNullOrEmpty(Fps.Text)) return;
        if (int.TryParse(Fps.Text, out int result))
        {
            if (pitscout.Fps != result)
            {
                pitscout.Fps = result;
                SaveData();
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
        SaveData();
    }

    private void Climb_Level_2_Clicked(object? sender, EventArgs e)
    {
        Set_Climb_Level(2);
        SaveData();
    }

    private void Climb_Level_3_Clicked(object? sender, EventArgs e)
    {
        Set_Climb_Level(3);
        SaveData();
    }

    private void Climb_Level_None_Clicked(object? sender, EventArgs e)
    {
        Set_Climb_Level(0);
        SaveData();
    }

    private void Climb_Loc_Middle_Clicked(object? sender, EventArgs e)
    {
        pitscout.Climb_Loc_Middle = !pitscout.Climb_Loc_Middle;
        SaveData();
        Set_Climb_Loc_Middle(pitscout.Climb_Loc_Middle);
    }

    private void Climb_Loc_Side_Clicked(object? sender, EventArgs e)
    {
        pitscout.Climb_Loc_Side = !pitscout.Climb_Loc_Side;
        SaveData();
        Set_Climb_Loc_Side(pitscout.Climb_Loc_Side);
    }

    private void Strengths_TextChanged(object? sender, TextChangedEventArgs e)
    {
        pitscout.Strength = Strengths.Text;
        SaveData();
    }

    private void Human_Acc_Low_Clicked(object? sender, EventArgs e)
    {
        Set_Human_Acc(1);
        SaveData();
    }

    private void Human_Acc_Med_Clicked(object? sender, EventArgs e)
    {
        Set_Human_Acc(2);
        SaveData();
    }

    private void Human_Acc_High_Clicked(object? sender, EventArgs e)
    {
        Set_Human_Acc(3);
        SaveData();
    }

    #region setRoutines
    private void Set_Drive_Train(int value)
    {
        pitscout.Drive_Train = value;
        SaveData();
        Drive_Train_Swerve.BackgroundColor = value == 1 ? Colors.Green : Colors.Gray;
        Drive_Train_Tank.BackgroundColor = value == 2 ? Colors.Green : Colors.Gray;
    }
    private void Set_Preferred_Placement_Left(bool value)
    {
        pitscout.Start_Left = value;
        SaveData();
        Start_Left.BackgroundColor = value ? Colors.Green : Colors.Gray;
    }
    private void Set_Preferred_Placement_Middle(bool value)
    {
        pitscout.Start_Middle = value;
        SaveData();
        Start_Middle.BackgroundColor = value ? Colors.Green : Colors.Gray;
    }
    private void Set_Preferred_Placement_Right(bool value)
    {
        pitscout.Start_Right = value;
        SaveData();
        Start_Right.BackgroundColor = value ? Colors.Green : Colors.Gray;
    }
    private void Set_Auto_Climb(bool value)
    {
        pitscout.Auto_Climb = value;
        SaveData();
        Auto_Climb_Yes.BackgroundColor = value ? Colors.Green : Colors.Gray;
        Auto_Climb_No.BackgroundColor = !value ? Colors.Green : Colors.Gray;
    }
    private void Set_Auto_Shoot(bool value)
    {
        pitscout.Auto_Shoot = value;
        SaveData();
        Auto_Shoot_Yes.BackgroundColor = value ? Colors.Green : Colors.Gray;
        Auto_Shoot_No.BackgroundColor = !value ? Colors.Green : Colors.Gray;
    }

    private void Set_Travel_Route_Over(bool value)
    {
        pitscout.Travel_Route_Over = value;
        SaveData();
        Travel_Route_Over.BackgroundColor = value ? Colors.Green : Colors.Gray;
    }
    private void Set_Travel_Route_Under(bool value)
    {
        pitscout.Travel_Route_Under = value;
        SaveData();
        Travel_Route_Under.BackgroundColor = value ? Colors.Green : Colors.Gray;
    }
    private void Set_Can_Climb(bool value)
    {
        pitscout.Can_Climb = value;
        SaveData();
        Can_Climb_Yes.BackgroundColor = value ? Colors.Green : Colors.Gray;
        Can_Climb_No.BackgroundColor = !value ? Colors.Green : Colors.Gray;
    }
    private void Set_Climb_Level(int value)
    {
        pitscout.Climb_Level = value;
        SaveData();
        Climb_Level_1.BackgroundColor = value == 1 ? Colors.Green : Colors.Gray;
        Climb_Level_2.BackgroundColor = value == 2 ? Colors.Green : Colors.Gray;
        Climb_Level_3.BackgroundColor = value == 3 ? Colors.Green : Colors.Gray;
        Climb_Level_None.BackgroundColor = value == 0 ? Colors.Green : Colors.Gray;
    }

    private void Set_Climb_Loc_Middle(bool value)
    {
        pitscout.Climb_Loc_Middle = value;
        SaveData();
        Climb_Loc_Middle.BackgroundColor = value ? Colors.Green : Colors.Grey;
    }
    private void Set_Climb_Loc_Side(bool value)
    {
        pitscout.Climb_Loc_Side = value;
        SaveData();
        Climb_Loc_Side.BackgroundColor = value ? Colors.Green : Colors.Grey;
    }
    private void Set_Human_Acc(int value)
    {
        pitscout.Human_Acc = value;
        SaveData();
        Human_Acc_Low.BackgroundColor = value == 1 ? Colors.Green : Colors.Gray;
        Human_Acc_Med.BackgroundColor = value == 2 ? Colors.Green : Colors.Gray;
        Human_Acc_High.BackgroundColor = value == 3 ? Colors.Green : Colors.Gray;
    }

    #endregion

    private void Comments_TextChanged(object? sender, TextChangedEventArgs e)
    {
        pitscout.Comments = Comments.Text;
        SaveData();
    }

    private void FillFields()
    {
        Set_Drive_Train(pitscout.Drive_Train);
        Drive_Train_Other.Text = pitscout.Drive_Train_Other;
        Set_Preferred_Placement_Left(pitscout.Start_Left);
        Set_Preferred_Placement_Middle(pitscout.Start_Middle);
        Set_Preferred_Placement_Right(pitscout.Start_Right);
        Set_Auto_Climb(pitscout.Auto_Climb);
        Set_Auto_Shoot(pitscout.Auto_Shoot);
        Best_Auto.Text = pitscout.Auto_Best;
        Max_Fuel.Text = pitscout.Max_Fuel.ToString();
        Set_Can_Climb(pitscout.Can_Climb);
        Set_Climb_Level(pitscout.Climb_Level);
        Set_Climb_Loc_Middle(pitscout.Climb_Loc_Middle);
        Set_Climb_Loc_Side(pitscout.Climb_Loc_Side);
        Strengths.Text = pitscout.Strength;
        Fps.Text = pitscout.Fps.ToString();
        Set_Travel_Route_Over(pitscout.Travel_Route_Over);
        Set_Travel_Route_Under(pitscout.Travel_Route_Under);
        Set_Human_Acc(pitscout.Human_Acc);
        Comments.Text = pitscout.Comments;
    }

    private void ClearFields()
    {
        Team_Num_Entry.Text = "";
        Set_Drive_Train(0);
        Drive_Train_Other.Text = "";
        Set_Preferred_Placement_Left(false);
        Set_Preferred_Placement_Middle(false);
        Set_Preferred_Placement_Right(false);
        Set_Auto_Climb(false);
        Set_Auto_Shoot(false);
        Best_Auto.Text = "";
        Max_Fuel.Text = "";
        Set_Can_Climb(false);
        Set_Climb_Level(0);
        Set_Climb_Loc_Middle(false);
        Set_Climb_Loc_Side(false);
        Strengths.Text = "";
        Fps.Text = "";
        Set_Travel_Route_Over(false);
        Set_Travel_Route_Under(false);
        Set_Human_Acc(0);
        Comments.Text = "";
    }

    private void SaveData()
    {
        if (pitscout.Team_Num <= 0) return;
        pitscout.Changed = true;
        SaveToDB();
    }

    private void SaveToDB()
    {
        var taskSave = Task.Run(() => db.SavePitScoutItemAsync(pitscout));
        taskSave.Wait();
    }
}
