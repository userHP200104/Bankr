using System;
using SQLite;

namespace Bankr.Model
{

    [Table("account")]

    public class Account
	{
        //Properties = values class
        [PrimaryKey, AutoIncrement]
        public int AccountId { get; set; }

        [MaxLength(11)]
        public float Balance { get; set; }

        [MaxLength(250)]
        public string AccountType { get; set; }

        [MaxLength(11)]
        public float Intrest { get; set; }

        [MaxLength(11)]
        public float TransactionFee { get; set; }

        [MaxLength(11), Unique, NotNull]
        public int UserId { get; set; }

        [MaxLength(13), Unique, NotNull]
        public string TransactionId { get; set; }
    }
}

