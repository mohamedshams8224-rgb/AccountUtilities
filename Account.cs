using System;
using System.Collections.Generic;
using System.Text;

namespace AccountUtilities
{

    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string name = "unnamed", double balance = 0.0)
        {
            this.Name = name;
            this.Balance = balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount < 0)
                return false;
            else
            {
                Balance += amount;
                return true;
            }
        }

        public virtual bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
    public class SavingsAccount : Account
    {
        public SavingsAccount(string name = "unnamed", double balance = 0.0, double interestRate = 0.0) : base(name, balance)
        {
            Balance += interestRate;
        }


    }
    public class CheckingAccount : Account
    {
        public CheckingAccount(string name = "unnamed", double balance = 0.0) : base(name, balance)
        {
        }


        public override bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= (amount + 1.50);
                Console.WriteLine("there is  a fee = $1.50 ");
                return true;
            }
            Console.WriteLine("faild operation");
            return false;

        }
    }
    public class TrustAccount : Account
    {
        public TrustAccount(string name = "unnamed", double balance = 0.0, double interestrate = 0.0) : base(name, balance)
        {
            Balance += interestrate;
        }
        public override bool Deposit(double amount)
        {
            if (amount < 0)
                return false;
            else if (amount >= 5000)
            {

                Balance += (amount + 50);
                Console.WriteLine("you have 50$ bonus");

                return true;
            }
            else
            {
                Balance += amount;
                return true;
            }
        }
        public override bool Withdraw(double amount)
        {
            if (Balance - amount >= 0 && amount <= Balance * 0.20)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                Console.WriteLine($"failed operation\nyour limit {Balance * 0.20}");
                return false;
            }
        }

    }

}
