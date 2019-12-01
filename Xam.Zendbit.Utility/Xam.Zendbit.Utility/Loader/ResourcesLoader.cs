using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Xam.Zendbit.Utility.Loader
{
    public class ResourceLoader
    {
        public async Task<string> LoadTextAsync(Type type, string identifier)
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(type).Assembly;
            var name = $"{assembly.GetName().Name}.{identifier}";
            var stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{identifier}");
            using var reader = new StreamReader(stream);
            return await reader.ReadToEndAsync();
        }
    }
}
