namespace GCEE
{
    public class Titulacion
    {
        public string CodTitulo {get; set;}
        public int NumAsignaturas {get; set;}
        public int NumCursos {get; set;}
        public string TipTitulacion {get; set;} //grado - master
        public string TipEstudios {get; set;} 
        /*  1- Arte Y Humanidades 
            2- Ciencias Sociales y Jurídicas
            3- Ciencias
            4- Ingerniería y Aqrquitectura
            5- Ciencias de la salud
        */
        public int NumTipEstudios {get; set;}
        public int TotalCreditos {get; set;}
        public double ProbAbandono {get; set;}
        public List<Asignatura> Asignaturas {get; set;}

        public Titulacion(string cod){

            var rand = new Random();

            CodTitulo = cod;
            Asignaturas = new List<Asignatura>();

            //Elegir entre grado y master
            int tipoTitul = rand.Next(1, 4);
            //Prob del 66% de ser un grado y 33% de master
            if(tipoTitul < 3){
                TipTitulacion = "grado";
                TotalCreditos = 240;
                NumAsignaturas  = 38;
                NumCursos = 4;
            }
            else{
                TipTitulacion = "master";
                TotalCreditos = 72;
                NumAsignaturas = 11;
                NumCursos = 2;
            }

            int tipoEst = rand.Next(1,6);

            SetTipoEst(tipoEst);

            //Tipo 1 y 2 son letras con probabilidad de entre 0 y 40
            if(tipoEst < 3)
                ProbAbandono = rand.NextDouble() * (0.40-0.0) + 0.0; //random.NextDouble() * (maximum - minimum) + minimum;
            //Tipo 3, 4 y 5 son ciencias con probabilidad de entre 35 y 75
            else
                ProbAbandono = rand.NextDouble() * (0.75-0.35) + 0.35;
        }

        public void SetTipoEst(int tip){
            NumTipEstudios = tip;

            switch(tip)
            {
                case 1:
                    TipEstudios = "Arte Y Humanidades";
                    break;

                case 2:
                    TipEstudios = "Ciencias Sociales y Juridicas";
                    break;

                case 3:
                    TipEstudios = "Ciencias";
                    break;

                case 4:
                    TipEstudios = "Ingernieria y Arquitectura";
                    break;

                case 5:
                    TipEstudios = "Ciencias de la salud";
                    break;
            }
        }
    }
}