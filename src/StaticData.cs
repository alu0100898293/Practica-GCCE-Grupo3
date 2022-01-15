namespace GCEE
{
    using Newtonsoft.Json;
    public class StaticData
    {

        const string NOMBRES = @"./data/nombres.json";
        const string LOCALIZACIONES = @"./data/localizacion.json";
        public string[] Nombres {get; set;}
        public string[] Apellidos {get; set;}
        public string[] Provincias {get; set;}
        public string[] MunicipiosSantaCruz {get; set;}
        public string[] MunicipiosLasPalmas {get; set;}

        public StaticData(){}

        public void loadData(){
            loadNombres();
            loadLocalizaciones();
        }

        private void loadNombres(){
            string nombresJson = File.ReadAllText(NOMBRES);
        
            var tmp = JsonConvert.DeserializeObject<StaticData>(nombresJson);
            this.Nombres = tmp.Nombres;
            this.Apellidos = tmp.Apellidos;
        }
        private void loadLocalizaciones(){
            string localizacionesJson = File.ReadAllText(LOCALIZACIONES);
            var tmp = JsonConvert.DeserializeObject<StaticData>(localizacionesJson);
                        
            this.Provincias = tmp.Provincias;
            this.MunicipiosSantaCruz = tmp.MunicipiosSantaCruz;
            this.MunicipiosLasPalmas= tmp.MunicipiosLasPalmas; 
        }
        public void readData(){
            Console.WriteLine("Nombres ------->") ;
            foreach(var nom in Nombres)
                Console.WriteLine(nom) ;

            Console.WriteLine("Apellidos ------->") ;
            foreach(var nom in Apellidos)
                Console.WriteLine(nom) ;
            
            Console.WriteLine("Provincias ------->") ;
            foreach(var nom in Provincias)
                Console.WriteLine(nom) ;

            Console.WriteLine("Municipios SC ------->") ;
            foreach(var nom in MunicipiosSantaCruz)
                Console.WriteLine(nom) ;

            Console.WriteLine("Municipios LP ------->") ;
            foreach(var nom in MunicipiosLasPalmas)
                Console.WriteLine(nom) ;
        }
    }
}