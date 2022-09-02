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
    public partial class Transaction : ObservableObject
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int AccountIn { get; set; }
        public int AccountOut { get; set; }
        public string TransactionType { get; set; }
        public double TransactionFee { get; set; }

        public double TransactionAmount { get; set; }
        public Color TransactionColour { get; set; }


    }


}
