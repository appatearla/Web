using Microsoft.WindowsAzure.Storage.Table;

namespace Data.Entities
{
    public class BaseEntity : TableEntity
    {
        public BaseEntity()
        {
            this.ETag = "*";
        }

        public string Id
        {
            get { return this.PartitionKey; }
            set { this.PartitionKey = value; }
        }
    }
}
