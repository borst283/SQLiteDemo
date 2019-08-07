using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteDemo.Database.Connection.Abstractions
{
    public interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
