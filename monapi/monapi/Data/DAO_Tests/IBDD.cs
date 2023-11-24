namespace API.Data.DAO_Tests
{
    public interface IBDD
    {
        bool AddStep(int step);

        bool Addnb_color(int NB);

        bool AddGrid_color(int color);

        bool AddPDF(byte[] pdf);
    }
}
