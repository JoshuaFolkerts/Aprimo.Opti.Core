using EPiServer.ServiceLocation;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Aprimo.Opti.Core
{
    public class AprimoAPISettings
    {
        private static Injected<IConfiguration> Configuration;
        static AprimoAPISettings()
        {
        }

        public static string ClientId { get; } = Configuration.Service.GetValue<string>("aprimo-api-clientid");

        public static string ClientSecret { get; } = Configuration.Service.GetValue<string>("aprimo-api-clientsecret");

        public static string AprimoTenantId { get; } = Configuration.Service.GetValue<string>("aprimo-api-tenantid");

        public static string DialogMode { get; } = Configuration.Service.GetValue<string>("aprimo-api-dialogmode");

        public static string LabelButton { get; } = Configuration.Service.GetValue<string>("aprimo-api-dialogbuttontext");

        public static string Description { get; } = Configuration.Service.GetValue<string>("aprimo-api-dialogdescription");

        public static string Title { get; } = Configuration.Service.GetValue<string>("aprimo-api-dialogtitle");
    }
}