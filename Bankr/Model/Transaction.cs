using System;
using SQLite;

namespace Bankr.Model
{
    [Table("transaction")]

    public class Transaction
	{
        //Properties = values class
        [PrimaryKey, AutoIncrement]
        public int TransactionId { get; set; }

        [MaxLength(11)]
        public float Amount { get; set; }

        [MaxLength(250)]
        public string TransactionType { get; set; }

        [MaxLength(11)]
        public float TransactionCost { get; set; }

        [MaxLength(100), NotNull]
        public DateTime Date { get; set; }

        [MaxLength(13), Unique, NotNull]
        public int AccountInId { get; set; }

        [MaxLength(13), Unique, NotNull]
        public int AccountOutId { get; set; }
    }
}


