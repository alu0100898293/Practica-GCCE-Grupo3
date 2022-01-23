namespace GCEE
{
    public class Acceso
    {
        public string CodAlu {get; set;}
        public string TipoAcceso{get; set;} //Bachiller - FP - Extranjero
        public double NotaMedBase{get; set;}
        public double NotaMedEspecial{get; set;}
        public double NotaBach{get; set;}
        public double NotaAcceso{get; set;}
        public double NotaAccesoBaseDiez {get; set;}

        public Acceso(string codAlu)
        {
            CodAlu = codAlu;

            var rand = new Random();

            switch (rand.Next(1, 4))
            {
                case 1:
                    TipoAcceso = "Bachiller";
                    SetNotasBach();
                    break;
                case 2:
                    TipoAcceso = "FP";
                    SetNotasFPyExt();
                    break;
                case 3: 
                    TipoAcceso = "Extranjero";
                    SetNotasFPyExt();
                    break;
            }

            //La nota de la prubea de acceso es sobre catorce
            NotaAccesoBaseDiez = (10 * NotaAcceso) / 14;

            if(NotaAccesoBaseDiez < 5.0)
                NotaAccesoBaseDiez = 5.0;
        }

        private void SetNotasBach()
        {
            //Notas de bachiller oscilan entre 6 y 10
            var rand = new Random();

            NotaBach = rand.NextDouble() * (10.0-6.0) + 6.0;

            NotaMedBase = rand.NextDouble() * (10.0-6.0) + 6.0;
            NotaMedEspecial = rand.NextDouble() * (4.0-1.0) + 1.0;

            NotaAcceso = NotaMedBase + NotaMedEspecial;
        }

        private void SetNotasFPyExt()
        {
            //Notas de FP y exntranjero oslcila entre 5 y 8
            var rand = new Random();

            NotaBach = 0.0;

            NotaMedBase = rand.NextDouble() * (8.0-5.0) + 6.0;
            NotaMedEspecial = rand.NextDouble() * (2.0-0.0) + 0.0;

            NotaAcceso = NotaMedBase + NotaMedEspecial;
        }
    }
}