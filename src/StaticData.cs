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

        public string getNombre(){
            var rand = new Random();
            int index = rand.Next(Nombres.Length);

            return Nombres[index];
        }

        public string getApellido(){
            var rand = new Random();
            int index = rand.Next(Apellidos.Length);

            return Apellidos[index];
        }

        public string getProvincia(){
            var rand = new Random();
            int index = rand.Next(Provincias.Length);

            return Provincias[index];
        }

        public string getMunicipio(string provincia){
            var rand = new Random();
            string municipio = "";
            int index = 0;

            if(provincia.Equals("Santa Cruz de Tenerife"))
            {
                index = rand.Next(MunicipiosSantaCruz.Length);
                municipio = MunicipiosSantaCruz[index];
            }
            else
                if(provincia.Equals("Las Palmas de Gran Canaria"))
                {
                    index = rand.Next(MunicipiosLasPalmas.Length);
                    municipio = MunicipiosLasPalmas[index];
                }

            return municipio;
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