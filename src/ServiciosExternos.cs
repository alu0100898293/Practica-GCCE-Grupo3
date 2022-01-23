namespace GCEE
{
    public class ServiciosExternos
    {
        public string CodAlu {get; set;}
        public string NumSS {get; set;}
        public bool Trabaja {get; set;}
        public double Sueldo {get; set;}

        public ServiciosExternos(string codAlu)
        {
            CodAlu = codAlu;
            NumSS = "ss_" + codAlu;
        }

        public void setRenta(string tipTitulacion)
        {
            var rand = new Random();
            int prob = 0;
            //En grado tiene un 25% de posibilidades de estar trabajando con renta baja-media
            if(tipTitulacion.Equals("grado"))
            {
                //Numero aleatorio entre 1 y 4
                prob = rand.Next(1,5);
                if(prob == 1)//25%
                {
                    Trabaja = true;
                    Sueldo = rand.NextDouble() * (2500.0-1500.0) + 1500.0;
                }
                else{//75%
                    Trabaja = false;
                    Sueldo = 0.0;
                }
            }
            //En master tiene un 66% de posibilidades de estar trabajando con renta media-alta
            else
            {
                //Numero aleatorio entre 1 y 3
                prob = rand.Next(1,4);
                if(prob == 1)//33%
                {
                    Trabaja = false;
                    Sueldo = 0.0;
                }
                else{//66%
                    Trabaja = true;
                    Sueldo = rand.NextDouble() * (5000.0-2500.0) + 2500.0;
                }
            }
        }
    }
}