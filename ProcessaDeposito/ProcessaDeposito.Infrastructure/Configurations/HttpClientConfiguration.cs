using System.Text;

namespace ProcessaDepositos.Infrastructure.Configurations
{
    public class HttpClientConfiguration
    {
        public string Name { get; set; }
        public string BaseAddress { get; set; }
        public static HttpClientConfiguration Default { get; } = 
            new HttpClientConfiguration()
        {
                Name = nameof(Default)
        };
    }
}