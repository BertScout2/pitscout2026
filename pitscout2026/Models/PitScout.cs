namespace pitscout2026.Models
{
    public class PitScout
    {
        public int Drive_Train { get; set; } = 0;
        public int Preferred_Placement { get; set; } = 0;
        public bool Auto_Climb { get; set; } = false;
        public bool Auto_Shoot { get; set; } = false;
        public string Auto_Best { get; set; } = string.Empty;
        public int Max_Fuel { get; set; } = 0;
        public bool Can_Climb { get; set; } = false;
        public int Climb_Level { get; set; } = 0;
        public int Climb_Loc { get; set; } = 0;
        public string Strength { get; set; } = string.Empty;
        public int Fps { get; set; } = 0;
        public int Travel_Route { get; set; } = 0;
    }
}
