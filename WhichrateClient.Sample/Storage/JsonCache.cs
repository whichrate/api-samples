using Newtonsoft.Json;

namespace WhichrateClient.Sample.Storage;

/// <summary>
/// A minimal JSON object cache implementation.
/// </summary>
public static class JsonCache
{
    /// <summary>
    /// Try to add an object into the cache.
    /// </summary>
    /// <param name="key">The cache key.</param>
    /// <param name="obj">The object value.</param>
    /// <typeparam name="T">The object type.</typeparam>
    /// <returns>True if was added, else false if failed.</returns>
    public static bool TryAddObject<T>(string key, T obj)
    {
        try
        {
            var path = GetObjectPath(key);
            if (File.Exists(path))
            {
                return false;
            }
            
            var json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(path, json);
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    /// <summary>
    /// Try to get an object from the cache.
    /// </summary>
    /// <param name="key">The cache key.</param>
    /// <param name="obj">The object value.</param>
    /// <typeparam name="T">The object type.</typeparam>
    /// <returns>True if was retrieved, else false.</returns>
    public static bool TryGetObject<T>(string key, out T obj)
    {
        try
        {
            var path = GetObjectPath(key);
            var json = File.ReadAllText(path);
            obj = JsonConvert.DeserializeObject<T>(json)!;
            return true;
        }
        catch
        {
            obj = default!;
            return false;
        }
    }
    
    private static string GetObjectPath(string key) => Path.Combine(Path.GetTempPath(), $"{key}.json");
}