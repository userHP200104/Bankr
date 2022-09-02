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
    public partial class People : ObservableObject
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string surname;

        [ObservableProperty]
        public string role;

        //public string Password { get; set; }

    }
}
