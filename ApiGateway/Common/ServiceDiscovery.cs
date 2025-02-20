namespace ApiGateway.Common
{
    public static class ServiceDiscovery
    {
    
        public static string GetServcice(string serviceName)
        {
            return ServiceRegistry.GetServcice(serviceName);
        }

    }
}
