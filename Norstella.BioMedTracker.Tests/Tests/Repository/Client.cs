using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq.EntityFrameworkCore;
using System.Collections.Generic;
using MMIT.BioMedTracker.Repository.EFModels;
using System.Threading.Tasks;

namespace MMIT.BioMedTracker.Test.Repository
{
    [TestClass]
    public class ClientsRepositoryClientTests : RepositoryUnitTestBase
    {
        [TestMethod]
        public async Task GetClient()
        {
            MockContext.Setup(x => x.Clients).ReturnsDbSet(ClientMockDataGenerator.GetClients());
            Assert.IsNotNull(_clientBaseRepository);
            Shared.Models.Client client = await _clientBaseRepository.GetClientAsync(ClientMockDataGenerator.CLIENT_ID);
            Assert.IsNotNull(client);
        }
    }

    public static class ClientMockDataGenerator
    {
        public const int CLIENT_ID = 12345;
        public const string CLIENT_NAME = "TestClient";

        public static List<Client> GetClients()
        {
            List<Client> ret = new List<Client>
            {
                new Client() { ClientId = CLIENT_ID, ClientName = CLIENT_NAME }
            };
            return ret;
        }
    }
}
