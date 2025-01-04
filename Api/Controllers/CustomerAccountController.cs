using Data.Enum;
using Data;
using Microsoft.AspNetCore.Mvc;
using Data.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAccountController : ControllerBase
    {

        private readonly AppDbContext _context;

        public CustomerAccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("createAccount")]
        public string CreateAccount(Guid customerId, AccountTypeEnum accountTypeEnum)
        {
            using (var context = new AppDbContext())
            {
                var userEixts = context.Customers.FirstOrDefault(x => x.Id == customerId);
                if (userEixts == null)
                {
                    return "This userId does not exists on customers table";
                }
            }

            var account = new CustomerAccount();

            account.AccountType = accountTypeEnum;
            account.AccountNumber = GenerateAccountNumber();
            account.CustomerId = customerId;

           
                _context.CustomerAccounts.Add(account);
                _context.SaveChanges();
            
            return $"here are the customer details\n" +
                $"account id: {customerId}\n" +
                $"accountNumber:{account.AccountNumber}\n" +
                $"account type{account.AccountType}\n";


        }


        private string GenerateAccountNumber()
        {
            Random random = new Random();
            string firstDigit = random.Next(1, 10).ToString();
            string remainingDigitS = string.Empty;
            for (int i = 0; i < 9; i++)
            {
                remainingDigitS += random.Next(2, 9).ToString();
            }
            return firstDigit + remainingDigitS;
        }


        [HttpPatch("DepositFunds")]
        public string DepositFunds(string accountNumber, decimal amtToDeposit)
        {

            try
            {
                using (var context = new AppDbContext())
                {

                    var acctExist = context.CustomerAccounts.FirstOrDefault(q => q.AccountNumber == accountNumber);
                    if (acctExist == null)
                    {
                        return "Account not found";
                    }
                    else
                    {
                        acctExist.AccountBalance += amtToDeposit;
                        context.SaveChanges();
                        var statement = new StatementOfAccount();
                        statement.AddAStatement(acctExist.Id, DateTime.Now, amtToDeposit, "cash withdrawal", $"{amtToDeposit} has been deposited to your account on {DateTime.Now}");
                        return "Deposit successful";
                    }
                }
            }
            catch (Exception ex)
            {

                return $"there was an error{ex.Message}";
            }
            return null;
        }





    }
}
