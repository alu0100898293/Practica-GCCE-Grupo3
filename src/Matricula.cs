namespace GCEE
{
    public class Matricula
    {
        public string CodMatricula { get; set; }
        public string CodAlu { get; set; }
        public int CredAprobados { get; set; }
        public int CredMatriculados { get; set; }
        public int Year { get; set; }
        public bool Poat { get; set; }
        public bool NuevoIngreso { get; set; }
        public double CosteCredito { get; set; }
        public bool Beca { get; set; }
        public bool CancelaMatricula { get; set; }

        const double COSTECREDITO2021 = 12.45;

        public Matricula(string codAlu, int year, bool nuevoIngreso)
        {
            CodAlu = codAlu;
            CodMatricula = "matricula_" + codAlu + "_" + year;
            Year = year;
            CosteCredito = COSTECREDITO2021;
            CredAprobados = 0;
            NuevoIngreso = nuevoIngreso;

            var rand = new Random();

            int poat = rand.Next(0, 2);

            if (poat == 0)
                Poat = false;
            else
                Poat = true;

        }

        /*
        *La matricula se cancela si no se aprueba al menos cuarto de las asignaturas matriculadas
        *Si trabaja tiene un 10% de posibilidades de cancelar
        */
        public void setCancelacion(bool trabaja, int numAsignaturas)
        {   
            var rand = new Random();

            if( (rand.Next(1, 11) == 1) && trabaja)
                CancelaMatricula = true;
            else
                //Si se matricula en menos de 5 asignaturas, no importa si no aprueba un 25%
                if(numAsignaturas > 5)
                {
                    double cancelacion = ((double)CredAprobados / CredMatriculados) * 100;

                    if (cancelacion < 25.0)
                        CancelaMatricula = true;
                    else
                        CancelaMatricula = false;
                }
                else
                    CancelaMatricula = false;
        }

        /*
        Los alumnos conta nota media >= 7 y renta baja tienen un 50% de psoibilidades de tener beca
        */
        public void SetBeca(double notaMedia, string nivRenta)
        {
            var rand = new Random();
            if(notaMedia >= 7.0)
                if(nivRenta.Equals("Bajo"))
                {
                    int probBeca = rand.Next(0, 2);
                    if (probBeca == 0)
                        Beca = false;
                    else
                        Beca = true;
                }
                else
                    Beca = false;
            else
                Beca = false;
        }

    }
}