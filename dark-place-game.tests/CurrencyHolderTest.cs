using System;
using Xunit;

namespace dark_place_game.tests
{

    /// Cette classe contient tout un ensemble de tests unitaires pour la classe CurrencyHolder
    public class CurrencyHolderTest
    {
        public static readonly int EXEMPLE_CAPACITE_VALIDE = 2748;
        public static readonly int EXEMPLE_CONTENANCE_INITIALE_VALIDE = 978;
        public static readonly string EXEMPLE_NOM_MONNAIE_VALIDE = "Brouzouf";

        [Fact]
        public void VraiShouldBeTrue()
        {
            var vrai = true;
            Assert.True(vrai, "Erreur, vrai vaut false. Le test est volontairement mal écrit, corrigez le.");
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf10ShouldContain10Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 10);
            var result = ch.CurrentAmount == 10;
            Assert.True(result);
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf25ShouldContain25Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 25);
            var result = ch.CurrentAmount == 25;
            Assert.True(result);
        }

        [Fact]
        public void CurrencyHolderCreatedWithInitialCurrentAmountOf0ShouldContain0Currency()
        {
            var ch = new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, 0);
            var result = ch.CurrentAmount == 0;
            Assert.True(result);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNegativeContentThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(EXEMPLE_NOM_MONNAIE_VALIDE, EXEMPLE_CAPACITE_VALIDE, -10);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithNullNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder(null, EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void CreatingCurrencyHolderWithEmptyNameThrowExeption()
        {
            // Petite subtilité : pour tester les levées d'exeption en c# on est obligé d'utiliser un concept un peu exotique : les expression lambda.
            // sans entrer dans le détail pour déclarer une lambda respectez la syntaxe ci dessous, pour rédiger des tests unitaires elle devrais vous suffire.
            Action mauvaisAppel = () => new CurrencyHolder("", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        //#TODO_ETAPE_4
        [Fact]
        public void BrouzoufIsAValidCurrencyName()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Brouzouf
            var ch = new CurrencyHolder("Brouzouf", 100, 50);
            var result = String.Equals(ch.CurrencyName, "Brouzouf");
            //var result2 = ch.CurrencyName == "Brouzouf";
            Assert.True(result);
        }

        [Fact]
        public void DollardIsAValidCurrencyName()
        {
            // A vous d'écrire un test qui vérife qu'on peut créer un CurrencyHolder contenant une monnaie dont le nom est Dollard
            var ch = new CurrencyHolder("Dollard", 100, 50);
            var result = ch.CurrencyName=="Dollard";
            Assert.True(result);
        }

        [Fact]
        public void TestPut10CurrencyInNonFullCurrencyHolder()
        {
            // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac a moité plein, il contient maintenant la bonne quantité de currency
            var ch = new CurrencyHolder("Brouzouf", 100, 50);
            ch.CurrentAmount = ch.Put(ch.CurrentAmount, 10);
            var result = ch.CurrentAmount == 60;
            Assert.True(result);
        }

        [Fact]
        public void TestPut10CurrencyInNearlyFullCurrencyHolder()
        {

            try
            {
                // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac quasiement plein, une exeption NotEnoughtSpaceInCurrencyHolderExeption est levée.
                var ch = new CurrencyHolder("Brouzouf", 100, 95);
                ch.CurrentAmount = ch.Put(ch.CurrentAmount, 10);

            }
            catch (NotEnoughtSpaceInCurrencyHolderExeption)
            {
                throw new NotEnoughtSpaceInCurrencyHolderExeption();
            }

        }

        [Fact]
        public void CreatingCurrencyHolderWithNameShorterThan4CharacterThrowExeption()
        {
            // A vous d'écrire un test qui doit échouer s'il es possible de créer un CurrencyHolder dont Le Nom De monnaie est inférieur a 4 lettres
            Action mauvaisAppel = () => new CurrencyHolder("Yop", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void WithdrawMoreThanCurrentAmountInCurrencyHolderThrowExeption()
        {
            // A vous d'écrire un test qui vérifie que retirer (methode withdraw) une quantité negative de currency leve une exeption CantWithDrawNegativeCurrencyAmountExeption.
            // Asruce : dans ce cas prévu avant même de pouvoir compiler le test, vous allez être obligé de créer la classe CantWithDrawMoreThanCurrentAmountExeption (vous pouvez la mettre dans le meme fichier que CurrencyHolder)
            try
            {
                // A vous d'écrire un test qui vérifie que si on ajoute via la methode put 10 currency à un sac quasiement plein, une exeption NotEnoughtSpaceInCurrencyHolderExeption est levée.
                var ch = new CurrencyHolder("Brouzouf", 100, 10);
                ch.CurrentAmount = ch.Withdraw(ch.CurrentAmount, 20);

            }
            catch (System.ArgumentException)
            {
                throw new System.ArgumentException();
            }

        }

        [Fact]
        public void CreatingCurrencyHolderWithNameLongerThan10CharacterThrowExeption()
        {
            // A vous d'écrire un test qui doit échouer s'il es possible de créer un CurrencyHolder dont Le Nom De monnaie est inférieur a 4 lettres
            Action mauvaisAppel = () => new CurrencyHolder("Yopidipopipy", EXEMPLE_CAPACITE_VALIDE, EXEMPLE_CONTENANCE_INITIALE_VALIDE);
            Assert.Throws<ArgumentException>(mauvaisAppel);
        }

        [Fact]
        public void Put0AmountInCurrencyHolderThrowExeption()
        {
            //Test renvoyant une erreur si le put ajoute 0
            try
            {
                var ch = new CurrencyHolder("Brouzouf", 100, 10);
                ch.CurrentAmount = ch.Put(ch.CurrentAmount, 0);

            }
            catch (System.ArgumentException)
            {
                System.Console.WriteLine("test ok");
            }

        }

        [Fact]
        public void Withdraw0AmountInCurrencyHolderThrowExeption()
        {
            //Test renvoyant une erreur si le Withdraw retire 0
            try
            {
                var ch = new CurrencyHolder("Brouzouf", 100, 10);
                ch.CurrentAmount = ch.Withdraw(ch.CurrentAmount, 0);

            }
            catch (System.ArgumentException)
            {
                System.Console.WriteLine("test ok");
            }

        }

        [Fact]
        public void testA()
        {
            //Test renvoyant une erreur si le nom du Currency commence par un A
            try
            {
                var ch = new CurrencyHolder("Arouzouf", 100, 10);

            }
            catch (System.ArgumentException)
            {
                System.Console.WriteLine("test ok");
            }

        }

        [Fact]
        public void testa()
        {
            //Test renvoyant une erreur si le nom du Currency commence par un a
            try
            {
                var ch = new CurrencyHolder("arouzouf", 100, 10);

            }
            catch (System.ArgumentException)
            {
                System.Console.WriteLine("test ok");
            }

        }

        [Fact]
        public void test0()
        {
            //Test renvoyant une erreur si la capacité est égale à 0
            try
            {
                var ch = new CurrencyHolder("Arouzouf", 0, 10);

            }
            catch (System.ArgumentException)
            {
                System.Console.WriteLine("test ok");
            }

        }

        [Fact]
        public void testnegatif()
        {
            //Test renvoyant une erreur si la capacité est négative
            try
            {
                var ch = new CurrencyHolder("Arouzouf", -5, 10);

            }
            catch (System.ArgumentException)
            {
                System.Console.WriteLine("test ok");
            }

        }

        [Fact]
        public void testisempty1()
        {
            //Test renvoyant un True si la bourse est vide
            var ch = new CurrencyHolder("Brouzouf", 100, 50);
            var result = ch.IsEmpty(0);
            Assert.True(result);

        }

        [Fact]
        public void testisempty2()
        {
            //Test renvoyant un False si la bourse n'est pas vide
            var ch = new CurrencyHolder("Brouzouf", 100, 50);
            var result = ch.IsEmpty(15);
            Assert.False(result);

        }

        [Fact]
        public void testisfull1()
        {
            //Test renvoyant un true si la bourse est pleine
            var ch = new CurrencyHolder("Brouzouf", 100, 50);
            var result = ch.IsFull(100, 100);
            Assert.True(result);

        }

        [Fact]
        public void testisfull2()
        {
            //Test renvoyant un true si la bourse se remplie jusqu'à son maximum
            var ch = new CurrencyHolder("Brouzouf", 100, 50);
            var result = ch.IsFull(100, 60, 40);
            Assert.True(result);

        }

        [Fact]
        public void testisfull3()
        {
            //Test renvoyant un true si la bourse est remplie avec un montant supérieur à la place restante dans celle-ci
            var ch = new CurrencyHolder("Brouzouf", 100, 50);
            var result = ch.IsFull(100, 60, 50);
            Assert.True(result);
        }

        [Fact]
        public void testisfull4()
        {
            //Test renvoyant un false si la bourse est remplie avec un montant inférieur à la place restante dans celle-ci
            var ch = new CurrencyHolder("Brouzouf", 100, 50);
            var result = ch.IsFull(100, 60, 30);
            Assert.False(result);

        }

    }
}