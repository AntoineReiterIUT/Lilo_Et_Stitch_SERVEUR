using monapi.Data;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using monapi.Data.BDD;

namespace API.Data.initialize
{
    /// <summary>
    /// initialize the BDD
    /// </summary>
    public static class initialise
    {

        /// <summary>
        /// delete all tables
        /// </summary>
        /// <authors>Mattis Galoppin</authors>
        public static void DeleteAll()
        {
            using (var context = new MyContext())
            {
                //delete PDF table
                FormattableString sql = $"DELETE FROM PDF;";
                context.Database.ExecuteSql(sql);

                //delete img table
                sql = $"DELETE FROM IMG_TRANSFORMED;";
                context.Database.ExecuteSql(sql);

                //delete Params table Params
                sql = $"DELETE FROM PARAMS;";
                context.Database.ExecuteSql(sql);
            }
        }


        /// <summary>
        /// Will move the patterns to the main pattern directory for a showcase, and insert into the bdd the data
        /// </summary>
        /// <author>Maxime LAFFAYE</author>
        public static void MoveTestingPatterns()
        {
            //DAOs to insert the data later on
            ParamsDAO paramsDAO = new ParamsDAO();
            Img_TransformedDAO imgDAO = new Img_TransformedDAO();
            PdfDAO pdfDAO = new PdfDAO();

            DirectoryInfo di = new DirectoryInfo(Const.testPatternsDirectory);
            foreach (DirectoryInfo subDirectory in di.GetDirectories())
            {
                string newPath = Path.Combine(Const.patternsDirectory, subDirectory.Name);
                Directory.CreateDirectory(newPath);

                //Inserting the data
                paramsDAO.InsertInParams(6, 5, "FFFF80", Path.Combine(newPath, subDirectory.Name + "_CSV.csv"));
                imgDAO.InsertInImg_Transformed(Path.Combine(subDirectory.Name, subDirectory.Name + "_IMG.png"),subDirectory.Name);
                pdfDAO.InsertInPdf(Path.Combine(newPath, subDirectory.Name + "_PDF.pdf"));


                    //Copying the directories and their contents
                    foreach (FileInfo file in subDirectory.GetFiles())
                {
                    string fPath = Path.Combine(newPath, file.Name);
                    file.CopyTo(fPath);
                }
            }
        }

        











    }
}
