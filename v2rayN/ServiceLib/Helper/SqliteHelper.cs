using System.Collections;

namespace ServiceLib.Helper;

public sealed class SQLiteHelper
{
    private static readonly Lazy<SQLiteHelper> _instance = new(() => new());
    public static SQLiteHelper Instance => _instance.Value;
    private readonly string _connstr;
    private SQLiteConnection _db;
    private SQLiteAsyncConnection _dbAsync;
    private readonly string _configDB = "guiNDB.db";

    public SQLiteHelper()
    {
        _connstr = Utils.GetConfigPath(_configDB);
        _db = new SQLiteConnection(_connstr, false);
        _dbAsync = new SQLiteAsyncConnection(_connstr, false);
    }

    public CreateTableResult CreateTable<T>()
    {
        return _db.CreateTable<T>();
    }

    /// <summary>
    /// Ensures a column exists on a table (migration helper for older DBs).
    /// </summary>
    public async Task EnsureColumnAsync(string table, string column, string columnType)
    {
        var tableCount = await _dbAsync.ExecuteScalarAsync<string>(
            "SELECT COUNT(1) FROM sqlite_master WHERE type='table' AND name=?", table);
        if (string.IsNullOrEmpty(tableCount) || tableCount == "0")
        {
            return;
        }

        var rows = await _dbAsync.QueryAsync<PragmaColumnRow>($"PRAGMA table_info({table})");
        var exists = rows.Any(r =>
            string.Equals(r.ColumnName, column, StringComparison.OrdinalIgnoreCase));
        if (!exists)
        {
            await _dbAsync.ExecuteAsync($"ALTER TABLE {table} ADD COLUMN {column} {columnType}");
        }
    }

    private sealed class PragmaColumnRow
    {
        public int? Cid { get; set; }
        public string? ColumnName { get; set; }
        public string? Type { get; set; }
        public bool NotNull { get; set; }
        public string? DfltValue { get; set; }
        public int? Pk { get; set; }
    }

    public async Task<int> InsertAllAsync(IEnumerable models)
    {
        return await _dbAsync.InsertAllAsync(models, runInTransaction: true).ConfigureAwait(false);
    }

    public async Task<int> InsertAsync(object model)
    {
        return await _dbAsync.InsertAsync(model);
    }

    public async Task<int> ReplaceAsync(object model)
    {
        return await _dbAsync.InsertOrReplaceAsync(model);
    }

    public async Task<int> UpdateAsync(object model)
    {
        return await _dbAsync.UpdateAsync(model);
    }

    public async Task<int> UpdateAllAsync(IEnumerable models)
    {
        return await _dbAsync.UpdateAllAsync(models, runInTransaction: true).ConfigureAwait(false);
    }

    public async Task<int> DeleteAsync(object model)
    {
        return await _dbAsync.DeleteAsync(model);
    }

    public async Task<int> DeleteAllAsync<T>()
    {
        return await _dbAsync.DeleteAllAsync<T>();
    }

    public async Task<int> ExecuteAsync(string sql)
    {
        return await _dbAsync.ExecuteAsync(sql);
    }

    public async Task<List<T>> QueryAsync<T>(string sql) where T : new()
    {
        return await _dbAsync.QueryAsync<T>(sql);
    }

    public AsyncTableQuery<T> TableAsync<T>() where T : new()
    {
        return _dbAsync.Table<T>();
    }

    public async Task DisposeDbConnectionAsync()
    {
        await Task.Run(() =>
        {
            try
            {
                _db?.Close();
                _db?.Dispose();
            }
            finally
            {
                _db = null;
            }

            try
            {
                var conn = _dbAsync?.GetConnection();
                conn?.Close();
                conn?.Dispose();
            }
            finally
            {
                _dbAsync = null;
            }
        });
    }
}
