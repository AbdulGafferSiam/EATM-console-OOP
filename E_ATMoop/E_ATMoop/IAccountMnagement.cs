using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace E_ATMoop
{
    interface IAccountMnagement
    {
        void cashWithdrawn();
        void checkBalance();
        void exit();
        int inputNumber();
        void InitDefaultValues();
        void cardNumber();
        void pinNumber();
        void options();
        bool checkCardNumber(int n);
        bool checkPinNumber(int n);
        void checkWithdrawalLimit();


    }
}
