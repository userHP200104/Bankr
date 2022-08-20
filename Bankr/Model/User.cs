using System;
using SQLite;

namespace Bankr.Model
{
    [Table("user")]

    public class User
	{
        //Properties = values class
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Surname { get; set; }

        [MaxLength(100)]
        public string Role { get; set; }

        [MaxLength(100), NotNull]
        public string Password { get; set; }

        [MaxLength(13), Unique, NotNull]
        public string AccountId { get; set; }
    }
}

