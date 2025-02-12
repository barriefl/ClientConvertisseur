using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.ViewModels;
using ClientConvertisseurV2.Models;

namespace ClientConvertisseurV2.Services.Tests
{
    [TestClass()]
    public class WSServiceTests
    {
        [TestMethod()]
        public void WSServiceTest()
        {
            WSService service = new WSService("https://localhost:7057/api/");
            Assert.IsNotNull(service);
        }

        [TestMethod()]
        public void GetDevisesAsyncTest()
        {
            // Arrange.
            WSService service = new WSService("https://localhost:7057/api/");

            var devisesAttendu = new List<Devise>
            {
                new Devise(1, "Dollar", 1.08),
                new Devise(2, "Franc Suisse", 1.07),
                new Devise(3, "Yen", 120)
            };

            // Act.
            var result = service.GetDevisesAsync("devises").Result;

            // Assert.
            Assert.IsNotNull(result, "Le résultat ne doit pas être nul.");
            Assert.IsInstanceOfType(result, typeof(List<Devise>), "Le résultat doit être de type List<Devise>.");
            CollectionAssert.AreEqual(devisesAttendu, result.ToList(), "Les devises chargées ne correspondent pas aux devises attendues.");
        }
    }
}