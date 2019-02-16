using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace Data
{
    public class BaseStorageTablesRepository
    {
        private readonly CloudTableClient tableClient;

        public BaseStorageTablesRepository(CloudTableClient tableClient)
        {
            this.tableClient = tableClient;
        }

        protected async Task<CloudTable> GetTableByReference(string tableReference)
        {
            var table = this.tableClient.GetTableReference(tableReference);
            await table.CreateIfNotExistsAsync();

            return table;
        }
    }
}
