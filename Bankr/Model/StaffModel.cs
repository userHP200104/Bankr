using System;
using System.Collections.Generic;
using SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Bankr.Model
{
    // [Table("people")]
    public partial class Staff : ObservableObject
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

      
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Role { get; set; }

        //public string Password { get; set; }

    }
}
