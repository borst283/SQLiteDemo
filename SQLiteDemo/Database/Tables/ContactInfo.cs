﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteDemo.Database.Tables
{
    [Table("ContactInfo")]
    public class ContactInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }

    }
}
