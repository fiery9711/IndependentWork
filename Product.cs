using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace IndependentWork
{
    internal class Product
    {
        DBconnect conn = new DBconnect();
        // create a function to add new product to the databases

        public bool insertProduct(string pname, string pcount, string pbrand, string pprice, DateTime pdate, byte[] pimg)
        {
            MySqlCommand terminal = new MySqlCommand("INSERT INTO `products`(`prId`, `prName`, `prCount`, `prBrand`, `prPrice`, `PrPhoto`, `prdate`) VALUES (@pn,@pc,@pb,@pp,@pi,@pd)", conn.getConnection);

            // @pn,@pc,@pb,@pp, @pd,@pi Going
            terminal.Parameters.Add("@pn", MySqlDbType.VarChar).Value = pname;
            terminal.Parameters.Add("@pc", MySqlDbType.VarChar).Value = pcount;
            terminal.Parameters.Add("@pb", MySqlDbType.VarChar).Value = pbrand;
            terminal.Parameters.Add("@pp", MySqlDbType.VarChar).Value = pprice;
            terminal.Parameters.Add("@pd", MySqlDbType.Date).Value = pdate;
            terminal.Parameters.Add("@pi", MySqlDbType.Blob).Value = pimg;

            conn.openConnection();
            if (terminal.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }
        }

    }
}
