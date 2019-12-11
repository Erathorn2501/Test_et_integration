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
        public CurrencyHolder(string name, int capacity, int amount)
        {

            Capacity = capacity;
            CurrencyName = name;
            CurrentAmount = amount;

            if (amount < 0) { throw new System.ArgumentException("Parameter cannot be null", "original"); }
            if (name == null){throw new System.ArgumentException("Parameter cannot be null", "original");}
            if (name == ""){throw new System.ArgumentException("Parameter cannot be null", "original");}
            if (name.Length < 4) { throw new System.ArgumentException("Parameter cannot be null", "original"); }
            if (name.Length > 10) { throw new System.ArgumentException("Parameter cannot be null", "original"); }
            if (name.Substring(0, 1) == "A") { throw new System.ArgumentException("Parameter cannot be null", "original"); }
            if (name.Substring(0, 1) == "a") { throw new System.ArgumentException("Parameter cannot be null", "original"); }
            if (capacity <= 0) { throw new System.ArgumentException("Parameter cannot be null", "original"); }
        }



        public bool IsEmpty(int amount)
        {
            if (amount == 0){return true;}
            else return false;
        }
        public bool IsFull(int capacity, int amount, int optionalAddAmount = 0)
        {
            if (capacity == amount){return true;}
            else if (capacity <= (amount + optionalAddAmount)){return true;}
            else return false;
        }
        public int Put(int amount, int addAmount)
        {
            if (addAmount <= 0) { throw new System.ArgumentException("Parameter cannot be null", "original"); }
            if (amount <= 0) { throw new System.ArgumentException("Parameter cannot be null", "original"); }
            //if ((amount + add_amount) > capacity){throw new System.ArgumentException("Parameter cannot be null", "original");}
            amount = amount + addAmount;
            return (amount);
        }
        public int Withdraw(int amount, int removeAmount)
        {
            if (removeAmount <= 0) { throw new System.ArgumentException("Parameter cannot be null", "original"); }
            if (amount <= 0) { throw new System.ArgumentException("Parameter cannot be null", "original"); }

            amount = amount - removeAmount;
            return amount;
        }

    }
}