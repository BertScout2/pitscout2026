namespace pitscout2026.Models
{
    public class PitScout
    {
        public int Drive_Train { get; set; } = 0;
        public int Preferred_Placement { get; set; } = 0;
        public bool Climb_Auto { get; set; } = false;
        public bool Shoot_Auto { get; set; } = false;
        public string Best_Auto { get; set; } = string.Empty;
        public int Max_Fuel { get; set; } = 0;
        public bool Can_Climb { get; set; } = false;
        public string Strength { get; set; } = string.Empty;
        public int Fps { get; set; } = 0;
        public int Travel_Route { get; set; } = 0;
    }
}
