using Ricardo.Technical.Test.Errors;

namespace Ricardo.Technical.Test.Data
{
	public class BankAccount
	{
		public int Money { get; private set; }

		public BankAccount(int money)
		{
			Money = money;
		}

		public bool CanWithdraw(int amount)
		{
			return Money >= amount;
		}

		public void Withdraw(int amount)
		{
			Money -= amount;
		}

		public static BankAccount Open(int money)
		{
			if(money >= 1)
				return new BankAccount(money);
			throw new InsufficientFundsException("Cannot open a bank account with less than £1.");
		}
	}
}
