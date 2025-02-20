namespace ApiGateway.Common
{
    public static class ServiceRegistry
    {
        static List<ServiceDefiniton> _db = new List<ServiceDefiniton>();


        public static void Register(ServiceDefiniton serviceDefiniton)
        {
            _db.Add(serviceDefiniton);
        }

        public static void Remove(ServiceDefiniton serviceDefiniton)
        {

            var service = _db
                .FirstOrDefault(x => x.Name == serviceDefiniton.Name && x.Url == serviceDefiniton.Url);

            _db.Remove(serviceDefiniton);
        }

        public static string GetServcice(string serviceName)
        {
            return  _db
               .FirstOrDefault(x => x.Name == serviceName).Url;
        }
    }
}
