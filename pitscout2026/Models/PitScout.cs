namespace pitscout2026.Models
{
    public class PitScout
    {
        public int Team_Num { get; set; } = 0;
        public int Drive_Train { get; set; } = 0;
        public bool Preferred_Placement_Left { get; set; } = false;
        public bool Preferred_Placement_Middle { get; set; } = false;
        public bool Preferred_Placement_Right { get; set; } = false;
        public bool Auto_Climb { get; set; } = false;
        public bool Auto_Shoot { get; set; } = false;
        public string Auto_Best { get; set; } = string.Empty;
        public int Max_Fuel { get; set; } = 0;
        public bool Can_Climb { get; set; } = false;
        public int Climb_Level { get; set; } = 0;
        //public int Climb_Loc { get; set; } = 0;
        public bool Climb_Loc_Side { get; set; } = false;
        public bool Climb_Loc_Middle { get; set; } = false;
        public string Strength { get; set; } = string.Empty;
        public int Fps { get; set; } = 0;
        //public int Travel_Route { get; set; } = 0;
        public bool Travel_Route_Over { get; set; } = false;
        public bool Travel_Route_Under { get; set; } = false;
        public string Comments { get; set; } = string.Empty;
        public int Human_Acc { get; set; } = 0;
        public static string CreateTableCommand()
        {
            return
                @"CREATE TABLE pitScout(
                Id    INTEGER,
                Team_Num  INTEGER,
                Drive_Train INTEGER,
                Preferred_Placement_Left INTEGER,
                Preferred_Placement_Middle INTEGER,
                Preferred_Placement_Right INTEGER,
                Auto_Climb INTEGER,
                Auto_Shoot INTEGER,
                Auto_Best TEXT,
                Max_Fuel INTEGER,
                Can_Climb INTEGER,
                Climb_Level INTEGER,
                Climb_Loc INTEGER,
                Strength TEXT,
                Fps INTEGER,
                Travel_Route INTEGER,
                Comments TEXT,
                PRIMARY KEY(Id AUTOINCREMENT)
                );";
        }
    }
}
