using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_ATMoop
{
    public class EATMMainStructure : IAccountMnagement
    {
        public int num;
        public int inputCardNumber;
        public int inputPinNumber;
        public IList<Account> numbers;
        public int index;
        public int amountWithdraw;
        public int[] times = {0, 0, 0, 0};

        public void InitDefaultValues()
        {
                numbers = new List<Account>() { 
                new Account(){ cardNumber= 1, pinNumber= 101, balance = 500},
                new Account(){ cardNumber= 2, pinNumber= 201, balance = 1000},
                new Account(){ cardNumber= 3, pinNumber= 301, balance = 200},
                new Account(){ cardNumber= 4, pinNumber= 401, balance = 1500}
            };
        }

        public void cardNumber()
        {
            Console.WriteLine("Please enter your card number: ");
            inputCardNumber = inputNumber();
            if (checkCardNumber(inputCardNumber) == true)
            {
                pinNumber();
            }
            else
            {
                Console.WriteLine("Your card number is invalid. Try again!");
                cardNumber();
            }
        }

        public bool checkCardNumber(int n)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i].cardNumber == n)
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }

        public void pinNumber()
        {
            Console.WriteLine("Enter Your pin number: ");
            inputPinNumber = inputNumber();
            if (checkPinNumber(inputPinNumber) == true)
            {
                options();
            }
            else
            {
                Console.WriteLine("Your pin number is invalid.Try again!");
                cardNumber();
            }
        }
        public bool checkPinNumber(int n)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (n == numbers[i].pinNumber)
                {
                    return true;
                }
            }
            return false;
        }
        public void options()
        {
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Cash Withdrawal");
            Console.WriteLine("3. Exit");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    checkBalance();
                    break;
                case 2:
                    cashWithdrawn();
                    break;
                case 3:
                    exit();
                    break;
            }
        }

        public void cashWithdrawn()
        {
            checkWithdrawalLimit();

            Console.WriteLine("Enter Your amount: ");
            amountWithdraw = inputNumber();

            if (amountWithdraw > 1000)
            {
                Console.WriteLine("Can not withdraw more than 1000tk. Try again!");
                cashWithdrawn();
            }
            else if (amountWithdraw <= 1000 && amountWithdraw > numbers[index].balance)
            {
                Console.WriteLine("You have not sufficient balance in your account to withdraw. Try again!");
                cashWithdrawn();
            }
            else
            {
                Console.WriteLine("Withdraw successful!");
                numbers[index].balance = numbers[index].balance - amountWithdraw;
                Console.WriteLine("Your current balance is: {0} tk", numbers[index].balance);
                times[index]++;
            }

            Console.WriteLine("Do you want to exit?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            int p = Convert.ToInt32(Console.ReadLine());
            switch (p)
            {
                case 1:
                    exit();
                    break;
                case 2:
                    cashWithdrawn();
                    break;
            }
        }

        public void checkWithdrawalLimit()
        {
            if (times[index] == 3)
            {
                Console.WriteLine("Your transection limit is over");
                Console.WriteLine("1. Balance");
                Console.WriteLine("2. Exit");
                int input = inputNumber();
                switch (input)
                {
                    case 1:
                        checkBalance();
                        break;
                    case 2:
                        exit();
                        break;
                }
            }    
        }

        public void checkBalance()
        {
            Console.WriteLine("Your current balance is " + numbers[index].balance);
            Console.WriteLine();
            Console.WriteLine("1. Cash withdrawn");
            Console.WriteLine("2. Exit");
            int p = inputNumber();
            switch (p)
            {
                case 1:
                    cashWithdrawn();
                    break;
                case 2:
                    exit();
                    break;
            }
        }

        public void exit()
        {
            cardNumber();
        }

        public int inputNumber()
        {
            try
            {
                num = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Please input a valid number");
                inputNumber();
            }
            return num;
        }

    }
}
