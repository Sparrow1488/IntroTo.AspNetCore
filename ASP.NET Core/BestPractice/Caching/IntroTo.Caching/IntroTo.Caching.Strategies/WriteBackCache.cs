using Microsoft.Extensions.Caching.Distributed;

namespace IntroTo.Caching.Strategies;

/// <summary>
///     
///     Note: 
/// </summary>
public class WriteBackCache : IDistributedCache
{
    private readonly IDistributedCache _main;
    private readonly IDistributedCache _secondary;
    // Simulation of a real local caching database
    private readonly ICollection<KeyValuePair<string, byte[]>> _inMemoryCachingBuffer = new List<KeyValuePair<string, byte[]>>();

    public WriteBackCache(IDistributedCache main, IDistributedCache secondary)
    {
        _main = main;
        _secondary = secondary;
        Task.Run(WriteBackAsync);
    }

    /// <summary>
    ///     It well be a background service
    /// </summary>
    private async Task WriteBackAsync()
    {
        while (true)
        {
            try
            {
                if (_inMemoryCachingBuffer.Count > 100)
                {
                    // built batch update: https://youtu.be/EJ73Bl3AtFY?list=PLOeFnOV9YBa77eJeW39a5Q2lsyfdxpE_d&t=998

                    // The main can be a distribute cache or database or HDD/SSD storage
                    // * Local Cache - Optional
                    // * Database    - Optional
                    foreach (var keyPairValue in _inMemoryCachingBuffer)
                        _main.Set(keyPairValue.Key, keyPairValue.Value);
                }

                await Task.Delay(TimeSpan.FromMinutes(1));
            }
            catch { }
        }
    }
    
    public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
    {
        // Save in local caching storage
        _secondary.Set(key, value);
        _inMemoryCachingBuffer.Add(new KeyValuePair<string, byte[]>(key, value));
    }
    
    public byte[] Get(string key)
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