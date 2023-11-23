using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace monapi.Data
{
    /// <summary>
    /// connect to the bdd
    /// </summary>
    public class MyContext : Microsoft.EntityFrameworkCore.DbContext
    {
        #region DbContext Configuration
        /// <summary>
        /// permet de configurer la conxexion a la bdd
        /// </summary>
        /// <param name="optionsBuilder">definit le type de connexion</param>
        /// <authors>Mattis Galoppin</authors>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string con = "User Id =IQ_BD_GALOPPIN; Password =GALOPPIN0000; Data Source = srv-iq-ora:1521/orclpdb.iut21.u-bourgogne.fr";

            optionsBuilder.UseOracle(con);

            base.OnConfiguring(optionsBuilder);
        }
        #endregion

    }

}
