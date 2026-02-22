using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using pitscout2026.Models;

namespace pitscout2026.Database
{
    public class pitDataBase
    {
        private const string PitDBFilename = "PitScoutThe2026.db3";
        private SqliteConnection Database = new();
        private string? databasePath;

        public pitDataBase()
        {
        }
        public async Task Init()
        {
            databasePath = "Data Source=" + Path.Combine("C:\\Temp", PitDBFilename);
            Database = new SqliteConnection(databasePath);
            await Database.OpenAsync();
            var createTableCmd = Database.CreateCommand();
            createTableCmd.CommandText = PitScout.CreateTableCommand();
            await createTableCmd.ExecuteNonQueryAsync();
            Database.Close();
        }
    }
}
