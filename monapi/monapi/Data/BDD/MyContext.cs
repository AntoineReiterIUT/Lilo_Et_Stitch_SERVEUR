using Microsoft.EntityFrameworkCore;
using monapi.Data.BDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace monapi.Data
{
    public class MyContext : Microsoft.EntityFrameworkCore.DbContext
    {
        #region Navigation Properties
        // Propriétés de navigation

        /// <summary>
        /// Gets or sets the DbSet for Params entities.
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        public DbSet<Params> Params { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for Img_Transformed entities.
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        public DbSet<Img_Transformed> Img_Transformed { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for Pdf entities.
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        public DbSet<Pdf> Pdf { get; set; }
        #endregion

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
