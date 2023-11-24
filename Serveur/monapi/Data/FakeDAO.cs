
namespace monapi.Data
{
    public class FakeDAO : IBDD
    {
        private static FakeDAO instance;

        private BDDtest bDD = new BDDtest();
        public static FakeDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new FakeDAO();
                return instance;
            }
        }


        private FakeDAO()
        {
            
        }

        public bool AddStep(int step)
        {
            bool res = false;
            if (step != null)
            {
                bDD.Step = step;
                res = true;
            }
            return res;
        }

        public  bool Addnb_color(int NB)
        {
            bool res = false;
            if (NB != null)
            {
                bDD.nb = NB;
                res = true;
            }
            return res;
        }

        public bool AddGrid_color(int color)
        {
            bool res = false;
            if (color != null)
            {
                bDD.Color = color;
                res = true;
            }
            return res;
        }

        public bool AddPDF(byte[] PDF)
        {
            bool res = false;
            if (PDF != null)
            {
                File.WriteAllBytesAsync(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jambon.pdf"),PDF);
                res = true;
                
            }
            return res;
        }
        
    }
}
