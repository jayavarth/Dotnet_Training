using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Ques1_Account
    {
        int accNo;
        string custName, accType;
        char transType;
        double amount, balance;

        public Ques1_Account(int accNo, string custName, string accType, double balance)
        {
            this.accNo = accNo;
            this.custName = custName;
            this.accType = accType;
            this.balance = balance;
        }

        public void Transaction(char type, double amt)
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

        public void ShowData()
        {
            Console.WriteLine($"AccNo: {accNo}, Name: {custName}, Type: {accType}, Balance: {balance}");
        }

        public static void Account()
        {
            Console.WriteLine("Enter Account No:");
            int accNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Account Type:");
            string type = Console.ReadLine();
            Console.WriteLine("Enter Balance:");
            double balance = double.Parse(Console.ReadLine());
            Ques1_Account account = new Ques1_Account(accNo, name, type, balance);
            Console.WriteLine("Enter Transaction Type (D/W):");
            char t = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Enter Amount:");
            double amt = double.Parse(Console.ReadLine());
            account.Transaction(t, amt);
            account.ShowData();
        }
    }
}
