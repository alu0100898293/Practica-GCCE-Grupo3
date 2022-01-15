namespace GCEE
{
    using System;
    using System.Configuration;
    using System.Collections.Specialized;
    class Simulator
    {
        private int NumAsignaturas {get; set;}
        private int NumAlumnosNuevos {get; set;}
        private double ProbAbandonoYear {get; set;}
        private int NumProfesores {get; set;}
        private int NumCursos {get; set;}
        private int NumTitulaciones {get; set;}
        private int NumAsigPorTit {get; set;}
        private int NumCursosSimular {get; set;}
        private StaticData SData {get; set;}

        public Simulator(NameValueCollection initialConfig, StaticData data){
            try{
                if(initialConfig.AllKeys.Length != 8)
                    throw new Exception("Invalid number of arguments in App.config");
                foreach (string val in initialConfig.AllKeys){
                    switch(val){
                        case "n_asignaturas":
                        NumAsignaturas = int.Parse(initialConfig.Get(val));
                        break;

                        case "n_alumnos_nuevos":
                        NumAlumnosNuevos = int.Parse(initialConfig.Get(val));
                        break;

                        case "p_abandono_year":
                        ProbAbandonoYear = double.Parse(initialConfig.Get(val));
                        break;

                        case "n_profesores":
                        NumProfesores = int.Parse(initialConfig.Get(val));
                        break;

                        case "n_cursos":
                        NumCursos = int.Parse(initialConfig.Get(val));
                        break;

                        case "n_titulaciones":
                        NumTitulaciones = int.Parse(initialConfig.Get(val));
                        break;

                        case "n_asig_por_tit":
                        NumAsigPorTit = int.Parse(initialConfig.Get(val));
                        break;
                        
                        case "n_cursos_simular":
                        NumCursosSimular = int.Parse(initialConfig.Get(val));
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Due to an exception, the programm will use the default values:\n" + e.Message);
                DefaultConfig();
            }
            
            SData = data;
        }
        private void DefaultConfig(){
            NumAsignaturas = 40;
            NumAlumnosNuevos = 200;
            ProbAbandonoYear = 0.30;
            NumProfesores = 20;
            NumCursos = 4;
            NumTitulaciones = 5;
            NumAsigPorTit = 40;
            NumCursosSimular = 6;
        }

        public void read(){
            Console.WriteLine("Num Asignaturas:" + NumAsignaturas);
        }
    }
}