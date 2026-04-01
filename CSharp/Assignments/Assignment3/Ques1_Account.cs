using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Ques1_Account
    {
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
                Console.WriteLine($"AccNo: {accNo}, Name: {custName}, Type: {accType}, Balance: {balance}");
            }
        }

        internal class Transaction : Account
        {
            char transType;
            double amount;

            public Transaction(int accNo, string custName, string accType, double balance)
                : base(accNo, custName, accType, balance)
            {
            }

            public void Transactions(char type, double amt)
            {
                transType = type;
                amount = amt;

                if (transType == 'D')
                    Credit(amount);
                else if (transType == 'W')
                    Debit(amount);
            }

            public void Credit(double amt)
            {
                balance += amt;
            }

            public void Debit(double amt)
            {
                if (amt <= balance)
                    balance -= amt;
                else
                    Console.WriteLine("Insufficient balance");
            }
        }
        public static void Accounts()
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

            account.Transactions(t, amt);
            account.ShowData();
        }
    }
}