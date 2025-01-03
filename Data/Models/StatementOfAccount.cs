

namespace Data.Models
{
    public class StatementOfAccount
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AccountId { get; set; }
        public DateTime DateOfTransaction {  get; set; }  
        public decimal Amount  {  get; set; }  
        public string TransactionType {  get; set; }  
        public string Description {  get; set; } 
        public  void AddAStatement(Guid accountID,DateTime dateOfTransaction,decimal amount, string transactionType,string description)
        {
            var statement = new StatementOfAccount()
            {
                AccountId = accountID,
                DateOfTransaction = dateOfTransaction,
                Amount = amount,
                TransactionType = transactionType,
                Description = description

            };
            using (var context = new AppDbContext())
            {
                context.StatementOfAccounts.Add(statement);
                context.SaveChanges();
            }

        }

    }
}
