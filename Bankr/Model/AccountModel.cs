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

        public double Balance { get; set; }
        public int FreeTransactions { get; set; }
        public double Interest { get; set; }
        public double TransFee { get; set; }
        public string AccountType { get; set; }
        public int ClientId { get; set; }
    }

    
}
