using Microsoft.WindowsAzure.Storage.Table;

namespace Data
{
    public class UserEntity : TableEntity
    {
        public UserEntity()
        {
            this.ETag = "*";
        }

        public string Id
        {
            get { return this.PartitionKey; }
            set { this.PartitionKey = value; }
        }

        public string Nickname
        {
            get { return this.RowKey; }
            set { this.RowKey = value; }
        }

        public string Name { get; set; }

        public string Mail { get; set; }

        public string ProfilePic { get; set; }

        public string SocialMedia { get; set; }

        public string Phone { get; set; }

        public string Gender { get; set; }
    }
}
