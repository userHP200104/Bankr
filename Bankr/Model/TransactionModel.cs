using System;
using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace Bankr.Model
{
    public partial class Transaction : ObservableObject
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int TransactionId { get; set; }

        public int SenderId{ get; set; }

        public string SenderAccount { get; set; }

        public int ReceiverId{ get; set; }

        public string ReceiverAccount{ get; set; }

        public int Amount{ get; set; }

    }
}

