using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string msg) :base(msg)
        { 
        }
    }

    internal class Account
    {
        protected int accNo;
        protected string custName, accType;
        protected double balance;

        public Account(int accNo, string custName, string accType, double balance)
        {
            this.accNo = accNo;
            this.custName = custName;
            this.accType = accType;
            this.balance = balance;
        }

        public void ShowData()
        {
            Console.WriteLine($"AccNo:{accNo},Name:{custName},Type:{accType},Balance:{balance}");
        }
    }

    internal class Transaction : Account
    {
        public Transaction(int accNo, string custName, string accType, double balance)
            : base(accNo, custName, accType, balance)
        {
        }
        public void Deposit(double amt)
        {
            balance += amt;
        }
        public void Withdraw(double amt)
        {
            if (amt > balance)
            {
                throw new InsufficientBalanceException("Balance is not sufficient for withdrawal");
            }
            balance -= amt;
        }
        public void ShowBalance()
        {
            Console.WriteLine("Current Balance:" + balance);
        }
    }
    internal class Ques1
    {
        public static void Accounts()
        {
            try
            {
                Console.WriteLine("Enter Account No:");
                int accNo = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Account Type:");
                string type = Console.ReadLine();
                Console.WriteLine("Enter Balance:");
                double balance = double.Parse(Console.ReadLine());
                Transaction account = new Transaction(accNo, name, type, balance);
                Console.WriteLine("Enter Transaction Type (D/W):");
                char t = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Enter Amount:");
                double amt = double.Parse(Console.ReadLine());
                if (t == 'D')
                {
                    account.Deposit(amt);
                }
                else if (t == 'W')
                {
                    account.Withdraw(amt);
                }
                account.ShowData();
                account.ShowBalance();
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Custom Exception:" + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
    }
}
