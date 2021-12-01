using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InfinityWorks.TechTest.Test.Resources
{
    internal static class ResourceRetriever
    {
        public static async Task<string> ReadResource(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourcePath = assembly.GetManifestResourceNames().Single(str => str.EndsWith($"{name}.json"));
            var resourceStream = assembly.GetManifestResourceStream(resourcePath);
            using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}