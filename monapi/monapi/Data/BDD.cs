namespace monapi.Data
{
    public class BDD
    {
        private int step;
        private int NB;
        private int color;
        private string name;

        public int Step
        {
            get { return step; }
            set { step = value; }
        }

        public int Color
        {
            get { return color; }
            set { color = value; }
        }

        public int nb
        {
            get { return NB; }
            set { NB = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public BDD() { }

    }
}
