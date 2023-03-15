using System.Transactions;

namespace Server.Utility
{
    public static class Utility
    {
        public static TransactionScope CreateAsyncTransactionScope(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            var transactionOptions = new TransactionOptions
            {
                /* IsolationLevel = isolationLevel,*/
                Timeout = TransactionManager.MaximumTimeout,

            };
            return new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
        }
    }
}
