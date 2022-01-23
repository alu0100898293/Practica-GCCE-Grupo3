namespace GCEE
{
    public class Asignatura
    {
        public string CodAsignatura {get; set;}
        public string CodTitulo {get; set;}
        public string Profesor {get; set;}
        public string Dificultad {get; set;}
        public int CredAsignatura {get; set;}
        public string NomAsigantura {get; set;}
        public int Curso {get; set;}
        public int Cuatrimestre {get; set;}
        public string TipoAsignatura {get; set;} //obligatoria - opcional
        public bool Especial {get; set;} // true solo en 2 - PE y TFG

        public Asignatura(String codTitul, int num, bool especial){

            var rand = new Random();

            CodAsignatura = "asignatura_" + codTitul + "_" + (num+1).ToString("000");

            CodTitulo = codTitul;

            Especial = especial;

            //dificultad baja al 25%, media al 50% y alata al 25%;
            int dif = rand.Next(1, 5);
            if(dif < 2)
                Dificultad = "baja";
            else
                if(dif < 4)
                    Dificultad = "media";
                else    
                    Dificultad = "alta";

            //Si es una de las cinco primeras de un año de diez asiganturas
            if(num % 10 < 5)
            {
                Cuatrimestre = 1;
            }
            else{
                Cuatrimestre = 2;
            }

            Curso = (int)Math.Ceiling(num / 10.0);

            //Las especiales son siempre obligatorias
            if(especial){
                TipoAsignatura = "obligatoria";
                CredAsignatura  = 12;
            }
            else
            {
                //Probabilidad de ser obligatoria al 75% y optativa al 25%
                int tipoAsig = rand.Next(1, 5);
                if(tipoAsig < 4)
                    TipoAsignatura = "obligatoria";
                else
                    TipoAsignatura = "optativa";

                CredAsignatura = 6;
            }
        }

        public void setNombreAsig(int titul, int num)
        {
            string nombre = "asigantura_" + titul;

            nombre += "_" + TipoAsignatura;

            if(Especial)
                nombre += "_especial";

            nombre += "_" + (num+1);

            NomAsigantura = nombre;

        }
    }
}