using System;
namespace dark_place_game
{
    [System.Serializable]
    /// Une Exeption Custom
    public class TestException0 : SystemException { }
    public class NotEnoughtSpaceInCurrencyHolderExeption : System.Exception { }
    public class CurrencyHolder
    {
        public static readonly string CURRENCY_DEFAULT_NAME = "Unnamed";
        /// Le nom de la monnaie
        public string CurrencyName
        {
            get { return currencyName; }
            private set
            {
                currencyName = value;
            }
        }
        // Le champs interne de la property
        private string currencyName = CURRENCY_DEFAULT_NAME;
        /// Le montant actuel

        //Getter et setter
        //**Principe à étudier
        public int CurrentAmount
        {
            get { return currentAmount; }
            set
            {
                currentAmount = value;
            }
        }
        // Le champs interne de la property
        private int currentAmount = 0;
        /// La contenance maximum du conteneur
        public int Capacity
        {
            get { return capacity; }
            set
            {
                capacity = value;
            }
        }
        // Le champs interne de la property
        private int capacity = 0;
        //Constructeur de la classe CurrencyHolder
        public CurrencyHolder(string name, int capacity, int amount)
        {
            //Principe de base du constructeur, liant les valeurs données en attribut avec les variables associées
            //**Principe à étudier
            Capacity = capacity;
            CurrencyName = name;
            CurrentAmount = amount;

            //Définition des exceptions permettant d'éviter les situations empêchant le programme de fonctionner correctement
            //-Repère si le montant "essai" de dépasser le minimum valide
            if (amount < 0) { throw new System.ArgumentException("Parameter cannot be null", "original"); }
            //-Repère si le nom est bien renseigné
            if (name == null){throw new System.ArgumentException("Parameter cannot be null", "original");}
            if (name == ""){throw new System.ArgumentException("Parameter cannot be null", "original");}
            //-Repère si le nom a une taille valide
            if (name.Length < 4) { throw new System.ArgumentException("Parameter cannot be null", "original"); }
            if (name.Length > 10) { throw new System.ArgumentException("Parameter cannot be null", "original"); }
            //-Repère si le nom commence par la lettre a(maj ou min, aucun n'est accepté)
            if (name.Substring(0, 1) == "A") { throw new System.ArgumentException("Parameter cannot be null", "original"); }
            if (name.Substring(0, 1) == "a") { throw new System.ArgumentException("Parameter cannot be null", "original"); }
            //-Repère si la capacité a une valeur valide
            if (capacity <= 0) { throw new System.ArgumentException("Parameter cannot be null", "original"); }
        }


        //Méthode déterminant si la bourse est vide ou non
        public bool IsEmpty(int amount)
        {   //Renvoie un true si le montant contenu dans la bourse est à 0
            //Peut-être à modifier le == par <=
            if (amount == 0){return true;}
            else return false;
        }

        //Méthode déterminant si la bourse est pleine ou non
        public bool IsFull(int capacity, int amount, int optionalAddAmount = 0)
        {   //Renvoie true si la bourse est pleine ou déborde, ou renvoie false autrement
            if (capacity == amount){return true;}   
            else if (capacity <= (amount + optionalAddAmount)){return true;}
            else return false;
        }
        //Méthode permettant d'augmenter le montant contenu dans la bourse
        public int Put(int amount, int addAmount)
        {   //Le montant ainsi que sa modification ne peuvent être de valeur négative,
            //Relève les exceptions si ces montants sont inférieurs ou égaux à 0
            if (addAmount <= 0) { throw new System.ArgumentException("Parameter cannot be null", "original"); }
            if (amount <= 0) { throw new System.ArgumentException("Parameter cannot be null", "original"); }
            amount = amount + addAmount;//Renvoie la valeur amount incrémentée par la valeur demandée
            return (amount);
        }
        //Méthode permettant de diminuer le montant contenu dans la bourse
        public int Withdraw(int amount, int removeAmount)
        {   //Même principe que la méthode Put
            if (removeAmount <= 0) { throw new System.ArgumentException("Parameter cannot be null", "original"); }
            if (amount <= 0) { throw new System.ArgumentException("Parameter cannot be null", "original"); }

            amount = amount - removeAmount;//Renvoie la valeur amount décrémentée par la valeur demandée
            return amount;
        }

    }
}