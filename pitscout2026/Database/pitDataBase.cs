using Microsoft.Data.Sqlite;
using pitscout2026.Models;

namespace pitscout2026.Database;

public class PitDataBase : BaseDatabase
{
    private const string PitDBFilename = "PitScoutThe2026.db3";
    private const string TableName = PitScout.TableName;
    private SqliteConnection Database = new();
    private string? databasePath;
    private bool created = false;

    public PitDataBase()
    {
    }

    private async Task Init()
    {
        if (created)
        {
            return;
        }
        try
        {
            databasePath = Path.Combine(DatabasePath, PitDBFilename);
            Database = new SqliteConnection("Data Source=" + databasePath);
            await Database.OpenAsync();
            var createTableCmd = Database.CreateCommand();
            createTableCmd.CommandText = PitScout.CreateTableCommand();
            await createTableCmd.ExecuteNonQueryAsync();
            Database.Close();
            created = true;
        }
        catch (Exception ex)
        {
            throw new SystemException($"Error initializing PitScout database: {databasePath}\r\n{ex.Message}");
        }
    }

    public async Task<PitScout?> GetPitScoutAsync(int team)
    {
        await Init();
        await Database.OpenAsync();
        var selectCmd = Database.CreateCommand();
        selectCmd.CommandText =
            @$"SELECT
            {PitScout.PitScoutFieldsWithId()}
            FROM {TableName}
            WHERE Team_Num = @team";
        selectCmd.Parameters.AddWithValue("@team", team);
        await using var reader = await selectCmd.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return PitScout.FromReader(reader);
        }
        return null;
    }

    public async Task<int> SavePitScoutItemAsync(PitScout item)
    {
        await Init();
        await Database.OpenAsync();
        var cmd = Database.CreateCommand();
        if (item.Id != 0)
        {
            cmd.CommandText = item.UpdateCommand();
        }
        else
        {
            var oldItem = await GetPitScoutAsync(item.Team_Num);
            if (oldItem != null)
            {
                item.Id = oldItem.Id;
                item.Uuid = oldItem.Uuid;
                if (!string.IsNullOrWhiteSpace(oldItem.AirtableId))
                {
                    item.AirtableId = oldItem.AirtableId;
                }
                cmd.CommandText = item.UpdateCommand();
            }
            else
            {
                cmd.CommandText = item.AddCommand();
            }
        }
        var count = await cmd.ExecuteNonQueryAsync();
        Database.Close();
        return count;
    }
}
