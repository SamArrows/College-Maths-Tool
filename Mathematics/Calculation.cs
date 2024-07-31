using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Mathematics
{
    class Calculation
    {
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get;
            set;
        }
        [NotNull]
        public string Result
        {
            get;
            set;
        }
        [NotNull]
        public string Inputs
        {
            get;
            set;
        }
        public Calculation()
        {
        }
    }
}
