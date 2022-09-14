using System.Collections;
using System.Collections.Generic;

namespace ProcessaDepositos.Infrastructure.Configurations
{
    public class AppConfigurations
    {
        public string HostBaseAddress { get; set; }
        public ICollection<HttpClientConfiguration> HttpClients { get; set; }
    }
}
