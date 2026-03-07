using Microsoft.Data.Sqlite;

namespace pitscout2026.Models
{
    public class PitScout : BaseModel
    {

        public const string TableName = "PitScout";

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
        public bool Climb_Loc_Side { get; set; } = false;
        public bool Climb_Loc_Middle { get; set; } = false;
        public string Strength { get; set; } = string.Empty;
        public int Fps { get; set; } = 0;
        public bool Travel_Route_Over { get; set; } = false;
        public bool Travel_Route_Under { get; set; } = false;
        public int Human_Acc { get; set; } = 0;
        public string Comments { get; set; } = string.Empty;

        public static string CreateTableCommand()
        {
            return
               @$"CREATE TABLE IF NOT EXISTS {TableName} (
               {BaseCreateTableFields()},
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
                Climb_Loc_Side INTEGER,
                Climb_Loc_Middle INTEGER,
                Strength TEXT,
                Fps INTEGER,
                Travel_Route_Over INTEGER,
                Travel_Route_Under INTEGER,
                Human_Acc INTEGER,
                Comments TEXT,
                PRIMARY KEY(Id AUTOINCREMENT)
                );";
        }

        public static string PitscoutFields()
        {
            return
               @"
                Team_Num  ,
                Drive_Train ,
                Preferred_Placement_Left ,
                Preferred_Placement_Middle ,
                Preferred_Placement_Right ,
                Auto_Climb ,
                Auto_Shoot ,
                Auto_Best ,
                Max_Fuel ,
                Can_Climb ,
                Climb_Level ,
                Climb_Loc_Side ,
                Climb_Loc_Middle ,
                Strength ,
                Fps ,
                Travel_Route_Over ,
                Travel_Route_Under ,
                Human_Acc ,
                Comments ";
        }

        public static string PitScoutFieldsWithId()
        {
            return
                @$"{BaseFieldsWithID()}
                , {PitscoutFields()}";
        }

        public string AddCommand()
        {
            return
                @$"INSERT INTO {TableName} (
                {BaseFields()},
                {PitscoutFields()}
                ) VALUES (
                {BaseAddValues()},
                {Team_Num}  ,
                {Drive_Train} ,
                {Preferred_Placement_Left} ,
                {Preferred_Placement_Middle} ,
                {Preferred_Placement_Right} ,
                {Auto_Climb} ,
                {Auto_Shoot} ,
               '{SQLInjectionFix(Auto_Best)}' ,
                {Max_Fuel} ,
                {Can_Climb} ,
                {Climb_Level} ,
                {Climb_Loc_Side} ,
                {Climb_Loc_Middle} ,
               '{SQLInjectionFix(Strength)}' ,
                {Fps} ,
                {Travel_Route_Over} ,
                {Travel_Route_Under} ,
                {Human_Acc} ,
               '{SQLInjectionFix(Comments)}' 
                )";
        }

        public string UpdateCommand()
        {
            return
                @$"UPDATE {TableName}
                SET
                {BaseUpdateValues()},
                Team_Num = {Team_Num}  ,
                Drive_Train = {Drive_Train} ,
                Preferred_Placement_Left = {Preferred_Placement_Left} ,
                Preferred_Placement_Middle = {Preferred_Placement_Middle} ,
                Preferred_Placement_Right = {Preferred_Placement_Right} ,
                Auto_Climb = {Auto_Climb} ,
                Auto_Shoot = {Auto_Shoot} ,
                Auto_Best = '{SQLInjectionFix(Auto_Best)}' ,
                Max_Fuel = {Max_Fuel} ,
                Can_Climb = {Can_Climb} ,
                Climb_Level = {Climb_Level} ,
                Climb_Loc_Side = {Climb_Loc_Side} ,
                Climb_Loc_Middle = {Climb_Loc_Middle} ,
                Strength = '{SQLInjectionFix(Strength)}' ,
                Fps = {Fps} ,
                Travel_Route_Over = {Travel_Route_Over} ,
                Travel_Route_Under = {Travel_Route_Under} ,
                Human_Acc = {Human_Acc} ,
                Comments = '{SQLInjectionFix(Comments)}' 
                WHERE Id = {Id}";
        }

        public static PitScout FromReader(SqliteDataReader reader)
        {
            var item = new PitScout();
            item.BaseFromReader(reader);
            item.Team_Num = reader.GetInt32(BaseFieldCount);
            item.Drive_Train = reader.GetInt32(BaseFieldCount + 1);
            item.Preferred_Placement_Left = reader.GetInt32(BaseFieldCount + 2) == 1;
            item.Preferred_Placement_Middle = reader.GetInt32(BaseFieldCount + 3) == 1;
            item.Preferred_Placement_Right = reader.GetInt32(BaseFieldCount + 4) == 1;
            item.Auto_Climb = reader.GetInt32(BaseFieldCount + 5) == 1;
            item.Auto_Shoot = reader.GetInt32(BaseFieldCount + 6) == 1;
            item.Auto_Best = reader.GetString(BaseFieldCount + 7);
            item.Max_Fuel = reader.GetInt32(BaseFieldCount + 8);
            item.Can_Climb = reader.GetInt32(BaseFieldCount + 9) == 1;
            item.Climb_Level = reader.GetInt32(BaseFieldCount + 10);
            item.Climb_Loc_Side = reader.GetInt32(BaseFieldCount + 11) == 1;
            item.Climb_Loc_Middle = reader.GetInt32(BaseFieldCount + 12) == 1;
            item.Strength = reader.GetString(BaseFieldCount + 13);
            item.Fps = reader.GetInt32(BaseFieldCount + 14);
            item.Travel_Route_Over = reader.GetInt32(BaseFieldCount + 15) == 1;
            item.Travel_Route_Under = reader.GetInt32(BaseFieldCount + 16) == 1;
            item.Human_Acc = reader.GetInt32(BaseFieldCount + 17);
            item.Comments = reader.GetString(BaseFieldCount + 18);
            return item;
        }
    }
}
