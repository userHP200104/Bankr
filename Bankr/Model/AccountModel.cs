using System;
using System.Collections.Generic;
using SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Bankr.Model
{
    [Table("account")]
    public class AccountModel
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public float Balance { get; set; }

        public float Interest { get; set; }

        public float TransFee { get; set; }
        public string AccountType { get; set; }

        public int Owner_id { get; set; }


    }
}
