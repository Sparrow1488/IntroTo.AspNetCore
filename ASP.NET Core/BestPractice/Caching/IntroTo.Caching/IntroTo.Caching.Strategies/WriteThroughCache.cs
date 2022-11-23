using Microsoft.Extensions.Caching.Distributed;

namespace IntroTo.Caching.Strategies;

/// <summary>
///     If you are going to use main caching database and in memory caching database
///     you can synchronize data between them.
///     Note: «Write-through». Запись происходит “одновременно” и в кэш и в память.
/// </summary>
public class WriteThroughCache : IDistributedCache
{
    private readonly IDistributedCache _main;
    private readonly IDistributedCache _secondary;

    /// <param name="main">Main Database ((No)SQL database)</param>
    /// <param name="secondary">Local Caching In Memory Database</param>
    public WriteThroughCache(IDistributedCache main, IDistributedCache secondary)
    {
        _main = main;
        _secondary = secondary;
    }
    
    // Read Aside
    public byte[] Get(string key)
    {
        var value = _secondary.Get(key);
        if (value is null)
        {
            value = _main.Get(key);
            _secondary.Set(key, value);
        }
        return value;
    }

    // Write Aside
    public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
    {
        _secondary.Set(key, value);
        _main.Set(key, value);
    }

    #region NotImplemented

    public Task<byte[]> GetAsync(string key, CancellationToken token = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options,
        CancellationToken token = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public void Refresh(string key)
    {
        throw new NotImplementedException();
    }

    public Task RefreshAsync(string key, CancellationToken token = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public void Remove(string key)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(string key, CancellationToken token = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    #endregion
}