using Microsoft.Extensions.Caching.Distributed;

namespace IntroTo.Caching.Strategies;

/// <summary>
///     Attaches prefix to the key to get or set values to the caching database.
///     It very useful when many (micro)services are using shared caching database and they need to identify their stored data.
/// </summary>
public class NamespacedCache : IDistributedCache
{
    private readonly IDistributedCache _cache;
    private readonly string _name;

    public NamespacedCache(IDistributedCache cache, string name)
    {
        _cache = cache;
        _name = name;
    }

    public byte[] Get(string key)
        => _cache.Get(_name + key);

    public Task<byte[]> GetAsync(string key, CancellationToken token = new())
        => _cache.GetAsync(_name + key, token);

    #region NotImplemented
    public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
        => throw new NotImplementedException();

    public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options,
        CancellationToken token = new CancellationToken())
        => throw new NotImplementedException();

    public void Refresh(string key)
        => throw new NotImplementedException();

    public Task RefreshAsync(string key, CancellationToken token = new CancellationToken())
        => throw new NotImplementedException();

    public void Remove(string key)
        => throw new NotImplementedException();

    public Task RemoveAsync(string key, CancellationToken token = new CancellationToken())
        => throw new NotImplementedException();
    #endregion
}