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
        private bool created = false;

        public pitDataBase()
        {
        }
        public async Task Init()
        {
            if (created)
            {
                return;
            }
            databasePath = "Data Source=" + Path.Combine("C:\\Temp", PitDBFilename);
            Database = new SqliteConnection(databasePath);
            await Database.OpenAsync();
            var createTableCmd = Database.CreateCommand();
            createTableCmd.CommandText = PitScout.CreateTableCommand();
            await createTableCmd.ExecuteNonQueryAsync();
            Database.Close();
            created = true;
        }
        public async Task<int> SavePitScoutItemAsync(PitScout item)
        {
            await Init();
            await Database.OpenAsync();
            var cmd = Database.CreateCommand();
           // if (item.Id !=0)
           // {
           //     cmd.CommandText = item.UpdateCommand();
           // }
           // else
          //  {
                cmd.CommandText = item.AddCommand();
            //  }
            var count = await cmd.ExecuteNonQueryAsync();
            Database.Close();
            return count;
        }
    }
}
