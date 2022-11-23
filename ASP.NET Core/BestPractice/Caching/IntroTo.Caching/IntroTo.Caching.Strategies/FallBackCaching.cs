using System.Net;
using Microsoft.Extensions.Caching.Distributed;
using Polly;
using Polly.Retry;

namespace IntroTo.Caching.Strategies;

/// <summary>
///     If you are going to use two caching databases and you want to be sure that
///     when main database crashes, you will just start using secondary database.
/// </summary>
public class FallBackCaching : IDistributedCache
{
    private readonly IDistributedCache _main;
    private readonly IDistributedCache _secondary;
    private readonly RetryPolicy _polly;

    public FallBackCaching(IDistributedCache main, IDistributedCache secondary)
    {
        _main = main;
        _secondary = secondary;
        _polly = Policy.Handle<WebException>()
            .WaitAndRetry(new[] {TimeSpan.FromSeconds(3)});
    }
    
    public byte[] Get(string key)
    {
        // Note: If main database fell we trying receive data from secondary caching database
        var mainData = default(byte[]);
        _polly.Execute(() => mainData = _main.Get(key)); // It should not throws exceptions
        return mainData ?? _secondary.Get(key);
    }

    public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
    {
        throw new NotImplementedException();
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