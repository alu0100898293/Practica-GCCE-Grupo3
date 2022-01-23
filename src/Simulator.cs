namespace GCEE
{
    using System;
    using System.Collections;
    using System.Collections.Specialized;
    class Simulator
    {
        const int YEAR = 2020;
        private int NumAsignaturas {get; set;}
        private int NumAlumnosNuevos {get; set;}
        private double ProbAbandonoYear {get; set;}
        private int NumProfesores {get; set;}
        private int NumCursos {get; set;}
        private int NumTitulaciones {get; set;}
        private int NumAsigPorTit {get; set;}
        private int NumCursosSimular {get; set;}
        private StaticData SData {get; set;}
        private List<Alumno> Alumnos {get; set;}
        private List<Profesor> Profesores {get; set;}
        private List<Asignatura> Asignaturas {get; set;}
        private List<Titulacion> Titulaciones {get; set;}
        private List<Acceso> Accesos {get; set;}
        private List<ServiciosExternos> ServiciosExt {get; set;}
        private List<CalifAcademica> CalifAcademicas {get; set;}
        private List<Matricula> Matriculas {get; set;}
        private List<List<Alumno>> Cohortes {get; set;}

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

            Alumnos = new List<Alumno>();
            Profesores = new List<Profesor>();
            Asignaturas = new List<Asignatura>();
            Titulaciones = new List<Titulacion>();
            ServiciosExt = new List<ServiciosExternos>();
            Matriculas = new List<Matricula>();
            CalifAcademicas = new List<CalifAcademica>();
            Accesos = new List<Acceso>();
            Cohortes = new List<List<Alumno>>();
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

        public void InitSimulation(){
                            
            var rand = new Random();

            //Generar titulaciones
            for(int i=1; i<NumTitulaciones+1; i++)
            {
                Titulacion tmp = new Titulacion("titulacion_" + (i*100));
                Titulaciones.Add(tmp);
            }

            //Generar profesores
            for(int i=0; i<NumProfesores; i++)
            {
                Profesor tmp  = new Profesor(SData.getNombre(), SData.getApellido(), SData.getApellido(), i+1);
                Profesores.Add(tmp);
            }

            //Generar asiganturas
            for(int i=0; i<NumTitulaciones; i++)
            {
                Asignatura asignaturaTmp;
                string codProf;

                //Asiganturas de Grado
                if(Titulaciones[i].TipTitulacion.Equals("grado"))
                {
                    for(int j=0; j<Titulaciones[i].NumAsignaturas-2; j++)
                    {
                        asignaturaTmp = new Asignatura(Titulaciones[i].CodTitulo, j, false);
                        asignaturaTmp.setNombreAsig((i+1)*100, j);
                        Titulaciones[i].Asignaturas.Add(asignaturaTmp);
                        codProf = Profesores[rand.Next(0, NumProfesores)].CodProf;
                        GetProfesor(codProf).AsigImp++;
                        asignaturaTmp.Profesor = codProf;

                        Asignaturas.Add(asignaturaTmp);
                    }
                    //Añadiendo TFG y PE
                    for(int j=Titulaciones[i].NumAsignaturas-2; j<Titulaciones[i].NumAsignaturas; j++)
                    {
                        asignaturaTmp = new Asignatura(Titulaciones[i].CodTitulo, j, true);
                        asignaturaTmp.setNombreAsig((i+1)*100, j);
                        Titulaciones[i].Asignaturas.Add(asignaturaTmp);
                        codProf = Profesores[rand.Next(0, NumProfesores)].CodProf;
                        GetProfesor(codProf).AsigImp++;
                        asignaturaTmp.Profesor = codProf;

                        Asignaturas.Add(asignaturaTmp);
                    }
                }
                //Asiganturas de master
                else
                {
                    for(int j=0; j<Titulaciones[i].NumAsignaturas-1; j++)
                    {
                        asignaturaTmp = new Asignatura(Titulaciones[i].CodTitulo, j, false);
                        asignaturaTmp.setNombreAsig((i+1)*100, j);
                        Titulaciones[i].Asignaturas.Add(asignaturaTmp);
                        codProf = Profesores[rand.Next(0, NumProfesores)].CodProf;
                        GetProfesor(codProf).AsigImp++;
                        asignaturaTmp.Profesor = codProf;

                        Asignaturas.Add(asignaturaTmp);
                    }

                    //Añadiendo TFM
                    asignaturaTmp = new Asignatura(Titulaciones[i].CodTitulo, Titulaciones[i].NumAsignaturas-1, true);
                    asignaturaTmp.setNombreAsig((i+1)*100, Titulaciones[i].NumAsignaturas-1);
                    Titulaciones[i].Asignaturas.Add(asignaturaTmp);
                    codProf = Profesores[rand.Next(0, NumProfesores)].CodProf;
                    GetProfesor(codProf).AsigImp++;
                    asignaturaTmp.Profesor = codProf;

                    Asignaturas.Add(asignaturaTmp);
                }
            }
            
            //Generar Cohorte
            for(int x=0; x<NumCursos; x++)
                for(int i=0; i<NumAlumnosNuevos; i++)
                {
                    Alumno alumnoTmp = new Alumno(SData.getNombre(), SData.getApellido(), SData.getApellido(), i+1, x);
                    Acceso accesoTmp = new Acceso(alumnoTmp.CodAlu);
                    ServiciosExternos serviciosExtTmp = new ServiciosExternos(alumnoTmp.CodAlu);

                    String provincia = SData.getProvincia();
                    alumnoTmp.SetLocalizacion(provincia, SData.getMunicipio(provincia));

                    alumnoTmp.CodTitulo = Titulaciones[rand.Next(0, NumTitulaciones)].CodTitulo;

                    Cohortes[x].Add(alumnoTmp); 
                    Alumnos.Add(alumnoTmp);
                    Accesos.Add(accesoTmp);
                    ServiciosExt.Add(serviciosExtTmp);
                }
            foreach(List<Alumno> cohorte in Cohortes)
                foreach(Alumno alumno in cohorte)
                {
                    if(GetTitulacion(alumno.CodTitulo).TipTitulacion.Equals("grado"))
                    {
                        SimularGrado(alumno);
                    }
                    else
                    {
                        SimularMaster(alumno);
                    }
                }
        }

        private void SimularGrado(Alumno alumno)
        {
            List<Asignatura> asignaturasPendientes = GetTitulacion(alumno.CodTitulo).Asignaturas;
            List<Asignatura> asignaturasMatriculadas = new List<Asignatura>();
            int creditosMat, numAsiganutasMatriculadas, creditosAprobados;
            double notaMedia = GetAcceso(alumno.CodAlu).NotaAccesoBaseDiez;
            double notaAcumulada;
            bool alumnoActivo = true;

            for(int i=0; i<NumCursosSimular && alumnoActivo; i++)
            {
                Matricula matriculaTmp = new Matricula(alumno.CodAlu, YEAR+i);
                matriculaTmp.SetBeca(notaMedia, alumno.NivRenta);

                creditosMat = 0;
                creditosAprobados = 0;

                //Siempre se intentan matricular 60 creditos cada curso
                while(creditosMat<60 && asignaturasPendientes.Any())
                {
                    asignaturasMatriculadas.Add(asignaturasPendientes[0]);
                    creditosMat += asignaturasPendientes[0].CredAsignatura;
                    asignaturasPendientes.RemoveAt(0);
                }

                //Si se añadio una asignatura de 12 creditos y supero los 60, esta ultima se quita
                if(creditosMat > 60)
                {
                    //Devolver la ultima asignatura a la lista de pendientes
                    asignaturasPendientes.Add(asignaturasMatriculadas[asignaturasMatriculadas.Count-1]);
                    //Quitar los cretidos
                    creditosMat -= asignaturasMatriculadas[asignaturasMatriculadas.Count-1].CredAsignatura;
                    //Quitar de la lista de asignaturas matriculadas
                    asignaturasMatriculadas.RemoveAt(asignaturasMatriculadas.Count-1);
                }

                matriculaTmp.CredMatriculados = creditosMat;
                numAsiganutasMatriculadas = asignaturasMatriculadas.Count();
                bool presentado;
                notaAcumulada = 0.0;

                foreach(Asignatura asignatura in asignaturasMatriculadas)
                {
                    CalifAcademica califAcademicaTmp = new CalifAcademica(matriculaTmp.CodMatricula, alumno.CodAlu, 
                        asignatura.CodTitulo, asignatura.Profesor, asignatura.CodAsignatura);
                    
                    presentado = califAcademicaTmp.SetPresentado(asignatura.TipoAsignatura);

                    if(presentado)
                    {
                        califAcademicaTmp.SetCalif(notaMedia, matriculaTmp.Beca, matriculaTmp.Poat, asignatura.Dificultad);
                        califAcademicaTmp.SetConvocatoria(asignatura.Cuatrimestre);
                    }
                    else
                        califAcademicaTmp.SetNoPresentado();

                    notaAcumulada += califAcademicaTmp.CalifNum;

                    //Si no se aprobo, se inserta en la lista de pendientes
                    if(califAcademicaTmp.CalifNum < 5.0)
                        asignaturasPendientes.Insert(0, asignatura);
                    else
                        creditosAprobados = asignatura.CredAsignatura;
                }

                matriculaTmp.CredAprobados = creditosAprobados;
                matriculaTmp.setCancelacion(GetServiciosExternosByAlu(alumno.CodAlu).Trabaja);
                Matriculas.Add(matriculaTmp);

                if(matriculaTmp.CancelaMatricula)
                {

                }
                    
            }
        }

        private void SimularMaster(Alumno alumno)
        {
            
        }

        private Alumno GetAlumno(string codAlu){

            Alumno tmp = Alumnos.Find(x => x.CodAlu.Equals(codAlu));

            return tmp;
        }

        private Profesor GetProfesor(string codProf){
            
            Profesor tmp = Profesores.Find(x => x.CodProf.Equals(codProf));

            return tmp;
        }

        private Titulacion GetTitulacion(string codTitul){

            Titulacion tmp = Titulaciones.Find(x => x.CodTitulo.Equals(codTitul));

            return tmp;
        }

        private Asignatura GetAsignatura(string codAsig){

            Asignatura tmp = Asignaturas.Find(x => x.CodAsignatura.Equals(codAsig));

            return tmp;
        }

        private ServiciosExternos GetServiciosExternosByAlu(string codAlu){

            ServiciosExternos tmp = ServiciosExt.Find(x => x.CodAlu.Equals(codAlu));

            return tmp;
        }

        private Acceso GetAcceso(string codAlu){

            Acceso tmp = Accesos.Find(x => x.CodAlu.Equals(codAlu));

            return tmp;
        }

        public void Read(){

            for(int i=0; i<NumTitulaciones; i++)
            {
                Console.WriteLine("Titulacion " + i + ":");
                Console.WriteLine("\t Titul cod " + Titulaciones[i].CodTitulo );
                Console.WriteLine("\t Num asig " + Titulaciones[i].NumAsignaturas);
                Console.WriteLine("\t Num cursos " + Titulaciones[i].NumCursos);
                Console.WriteLine("\t Tip titul " + Titulaciones[i].TipTitulacion );
                Console.WriteLine("\t Tip estu " + Titulaciones[i].TipEstudios );
                Console.WriteLine("\t Creditos " + Titulaciones[i].TotalCreditos );  
                Console.WriteLine("\t Abandono " + Titulaciones[i].ProbAbandono );
            }

            Console.WriteLine("Asignaturas:" );
            foreach(Asignatura asig in Asignaturas)
            {
                Console.WriteLine("\t ><Asig cod " + asig.CodAsignatura );
                Console.WriteLine("\t Titul cod " + asig.CodTitulo );
                Console.WriteLine("\t Asig nom " + asig.NomAsigantura );
                Console.WriteLine("\t Asig dif " + asig.Dificultad );
                Console.WriteLine("\t Asig cred " + asig.CredAsignatura );
                Console.WriteLine("\t Asig curso " + asig.Curso );
                Console.WriteLine("\t Asig cuatri " + asig.Cuatrimestre );
                Console.WriteLine("\t Asig tipo " + asig.TipoAsignatura );
                Console.WriteLine("\t Asig especial " + asig.Especial );
            }
        }
    }
}