using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels.Tests
{
    [TestClass()]
    public class ConvertisseurEuroViewModelTests
    {
        /// <summary>
        /// Test constructeur.
        /// </summary>
        [TestMethod()]
        public void ConvertisseurEuroViewModelTest()
        {
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            Assert.IsNotNull(convertisseurEuro);
        }

        /// <summary>
        /// Test GetDataOnLoadAsyncTest OK
        /// </summary>
        [TestMethod()]
        public void GetDataOnLoadAsyncTest_OK()
        {
            // Arrange.
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();

            var devisesAttendu = new List<Devise>
            {
                new Devise(1, "Dollar", 1.08),
                new Devise(2, "Franc Suisse", 1.07),
                new Devise(3, "Yen", 120)
            };

            // Act.
            convertisseurEuro.GetDataOnLoadAsync(); 
            Thread.Sleep(1000);

            // Assert.
            Assert.IsNotNull(convertisseurEuro.Devises);
            CollectionAssert.AreEqual(devisesAttendu, convertisseurEuro.Devises.ToList(), "Les devises chargées ne correspondent pas aux devises attendues.");
        }

        /// <summary>
        /// Test conversion OK
        /// </summary>
        [TestMethod()]
        public void ActionSetConversionTest()
        {
            // Arrange.
            // Création d'un objet de type ConvertisseurEuroViewModel
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            // Property MontantEuro = 100 (par exemple)
            convertisseurEuro.Montant = 100;

            // Création d'un objet Devise, dont Taux=1.07
            Devise devise = new Devise(4, "DeviseTest", 1.07);
            // Property DeviseSelectionnee = objet Devise instancié
            convertisseurEuro.DeviseSelectionnee = devise;

            // Act.
            // Appel de la méthode ActionSetConversion
            convertisseurEuro.ActionSetConversion();

            // Assert.
            // Assertion : MontantDevise est égal à la valeur espérée 107
            Assert.AreEqual(107, convertisseurEuro.Resultat, "Le montant espérée n'est pas 107.");
        }

        /// <summary>
        /// Test GetDataOnLoadAsyncTest OK
        /// </summary>
        //[TestMethod()]
        //public void GetDataOnLoadAsyncTest_NonOK_WSnondemarre()
        //{
        //    // Arrange.
        //    ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();

        //    // Act.
        //    convertisseurEuro.GetDataOnLoadAsync();
        //    Thread.Sleep(1000);

        //    // Assert.
        //    Assert.IsNull(convertisseurEuro.Devises);
        //}
    }
}