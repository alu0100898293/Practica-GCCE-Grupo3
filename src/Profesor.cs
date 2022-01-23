namespace GCEE
{
    public class Profesor
    {
        public string CodProf {get; set;}
        public int AsigImp {get; set;}
        public string NomProf {get; set;}
        public string Apellido1 {get; set;}
        public string Apellido2 {get; set;}
        public string Catego {get; set;}
        public int TiempoULL {get; set;}
        public int Year {get; set;}

        public Profesor(string nombre, string apellido1, string apellido2, int num)
        {
            NomProf = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            CodProf = "profesor_" + (num*10).ToString("0000");

            var rand = new Random();

            TiempoULL = rand.Next(1, 16);
            Year = rand.Next(1950, 1996);
            AsigImp = 0;

            Catego = "categoria_" + (num*20);
        }
    }
}