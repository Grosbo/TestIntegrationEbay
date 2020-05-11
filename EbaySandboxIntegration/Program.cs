using EbaySandboxIntegration.Services;
using System;
using System.Threading.Tasks;

namespace EbaySandboxIntegration
{
    class Program
    {
        static  async Task Main(string[] args)
        {
            Console.WriteLine("Ebay integration");
            IntegrationService integrationService = new IntegrationService();

            await integrationService.GetTokenRSharp();
            await integrationService.EmptySearch();

        }
    }
}
