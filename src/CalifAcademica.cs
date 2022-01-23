namespace GCEE
{
    public class CalifAcademica
    {
        public string CodMatricula {get; set;}
        public string CodTitulo {get; set;}
        public string CodProfesor {get; set;}
        public string CodAlu {get; set;}
        public string CodAsignatura {get; set;}
        public string Convocatoria {get; set;}
        public double CalifNum {get; set;}
        public string Calif {get; set;}
        public bool Presentado {get; set;}
        public CalifAcademica(string codMatricula, string codAlu, string codTitulo, string codProf, string codAsig)
        {
            CodMatricula = codMatricula;
            CodAlu = codAlu;
            CodProfesor = codProf;
            CodTitulo = codTitulo;
            CodAsignatura = codAsig;
        }

        /*
        * Se presenta a las asignaturas optativas con un 95% y a las obligatorias con un 90%
        */
        public bool SetPresentado(string tipoAsignatura)
        {
            var rand = new Random();
            int probPresentado = rand.Next(0,100);

            if(tipoAsignatura.Equals("obligatoria"))
                Presentado = probPresentado < 90 ? true : false;
            else
                Presentado = probPresentado < 95 ? true : false;

            return Presentado;
        }

        /*
        * La nota media tiene posibilidades de ser mayor en caso de estar en poat y/o tener beca
        * La dificultad de la asignatura afecta a los márgenes en que varía la nota
        */
        public void SetCalif(double notaMedia, bool beca, bool poat, string difASignatura)
        {
            var rand = new Random();

            double margenSuperior = 1.5, margenInferior = 1.5;

            if(beca)
            {
                margenInferior -= 0.25;
                margenSuperior += 0.25;
            }

            if(poat)
            {
                margenInferior -= 0.25;
                margenSuperior += 0.25;
            }

            switch(difASignatura)
            {
                case "baja":
                    margenSuperior += 1.0;
                    break;
                
                case "alta":
                    margenInferior += 1.0;
                    break;
            }

            margenSuperior += notaMedia;
            margenInferior -= notaMedia;

            margenSuperior = margenSuperior <= 10.0 ? margenSuperior : 10.0;
            margenInferior = margenInferior >= 0.0 ? margenInferior : 0.0;

            CalifNum = rand.NextDouble() * (margenSuperior-margenInferior) + margenInferior;

            if(CalifNum < 5.0)
                Calif = "Suspenso";
            else if(CalifNum < 7.0)
                Calif = "Aprobado";
            else if(CalifNum < 9.0)
                Calif = "Notable";
            else
                Calif = "Sobresaliente";
        }

        public void SetConvocatoria(int cuatrimestre)
        {
            var rand = new Random();
            string[] convocatorias = {"enero", "julio", "septiembre", "junio"};

            Convocatoria = cuatrimestre == 1 ? convocatorias[rand.Next(0,3)] : convocatorias[rand.Next(1,4)];
        }

        public void SetNoPresentado()
        {
            CalifNum = 0.0;
            Calif = "No presentado";
            Convocatoria = "-";
        }
    }

}