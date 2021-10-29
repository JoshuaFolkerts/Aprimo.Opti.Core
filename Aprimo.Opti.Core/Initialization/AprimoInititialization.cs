using Aprimo.Opti.Core.Services;
using EPiServer.Core;
using EPiServer.Core.Internal;
using EPiServer.DataAbstraction;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using Microsoft.Extensions.DependencyInjection;

namespace Aprimo.Opti.Core.Initialization
{
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule), typeof(EPiServer.Initialization.CmsCoreInitialization))]
    public class AprimoInititialization : IInitializableModule, IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.ConfigurationComplete += (o, e) =>
            {
                context.Services.Configure<ContentOptions>(o => o.AddProvider<AprimoContentProvider>(AprimoConstants.ProviderKey, config =>
                {
                    var aprimoRoot = AprimoContentProvider.GetRoot();
                    config[ContentProviderParameter.EntryPoint] = aprimoRoot.ToString();
                }));
            };
        }

        public void Initialize(InitializationEngine context)
        {
            context.Locate.Advanced.GetInstance<AprimoContentAssetResolver>()
                .Initialize(context.Locate.Advanced.GetInstance<ContentTypeModelRepository>());
        }

        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}