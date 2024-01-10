using API.Data.BDD.TablesBDD.Img_Transformed;
using API.Data.BDD.TablesBDD.PARAMS;
using API.Data.BDD.TablesBDD.PDF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace monapi.Data
{
    public class MyContext : Microsoft.EntityFrameworkCore.DbContext
    {
        #region properties

        /// <summary>
        /// Property : Gets or sets the DbSet for Params entities.
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        public DbSet<ParamsDAO> Params { get; set; }

        /// <summary>
        /// Property : Gets or sets the DbSet for Img_Transformed entities.
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        public DbSet<Img_TransformedDAO> Img_Transformed { get; set; }

        /// <summary>
        /// Property : Gets or sets the DbSet for Pdf entities.
        /// </summary>
        /// <authors>Mattis GALOPPIN</authors>
        public DbSet<PdfDAO> Pdf { get; set; }

        #endregion


        #region operations

        /// <summary>
        /// Allows to configure the connexion to the database.
        /// </summary>
        /// <param name="optionsBuilder">Defines the options to be used by a DbContext.</param>
        /// <authors>Mattis GALOPPIN</authors>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //values for the connexion to the database
            string con = "User Id =IQ_BD_GALOPPIN; Password =GALOPPIN0000; Data Source = srv-iq-ora:1521/orclpdb.iut21.u-bourgogne.fr";
            
            //use the connexion to the database
            optionsBuilder.UseOracle(con);
            base.OnConfiguring(optionsBuilder);
        }

        #endregion

    }

}
