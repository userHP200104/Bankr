using System;
using System.Collections.Generic;
using SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Bankr.Model
{
   // [Table("account")]
    public partial class Account : ObservableObject
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [ObservableProperty]
        public double balance;
        [ObservableProperty]
        public int freeTransactions;
        [ObservableProperty]
        public double interest;
        [ObservableProperty]
        public double transFee;
        [ObservableProperty]
        public string accountType;
        [ObservableProperty]
        public int clientId;
    }

    
}
