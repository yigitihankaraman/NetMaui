using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteTemplate.Models
{
    [Table("User")]
    public class User
    {
        // PrimaryKey
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string? Username{ get; set; }

        [MaxLength(250)]
        public string? Mail { get; set; }

        [MaxLength(25)]
        public string? Password { get; set; }
    }
}
