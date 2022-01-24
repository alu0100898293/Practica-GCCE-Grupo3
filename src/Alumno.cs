namespace GCEE
{
    public class Alumno
    {
        public string CodAlu {get; set;}
        public string CodTitulo {get; set;}
        public string Estado {get; set;}
        public string NomAlu {get; set;}
        public string Apellido1 {get; set;}
        public string Apellido2 {get; set;}
        public string Sexo {get; set;}
        public int Year {get; set;}
        public string NivelEstProg1 {get; set;}
        public string NivelEstProg2 {get; set;}
        public string NivRenta {get; set;}
        public int RentaNum {get; set;}
        public string Municipio {get; set;}
        public string Provincia {get; set;}
        
        public Alumno(string nombre, string apellido1, string apellido2, int num, int year)
        {
            NomAlu = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;

            CodAlu = "alumno_" + (1000+num);
            Year = 2020+year;

            var rand = new Random();

            //Masculino o femenino con probabilidad del 47%, y otro al 6%
            int prob = rand.Next(1, 101);
            if(prob <= 47)
                    Sexo = "Masculino";
            else
                if(prob > 47 && prob <= 94)
                    Sexo = "Femenino";
                else
                    Sexo = "Otro";
            
            RentaNum = 0;

            int estudiosProgenitor = rand.Next(0, 6);
            NivelEstProg1 = GetNivelEstudios(estudiosProgenitor);

            estudiosProgenitor = rand.Next(0, 6);
            NivelEstProg2 = GetNivelEstudios(estudiosProgenitor);

            if(RentaNum < 4)
                NivRenta = "Bajo";
            else
                if(RentaNum >= 4 && RentaNum <= 7)
                    NivRenta = "Medio";
                else
                    NivRenta = "Alto";
        }

        public void SetLocalizacion(string provincia, string municipio)
        {
            Provincia = provincia;
            Municipio = municipio;
        }

        private string GetNivelEstudios(int num)
        {
            string nivelEstudios = "";
            switch(num)
            {
                case 0:
                    nivelEstudios = "Analfabeto";
                    RentaNum += 0;
                    break;

                case 1:
                    nivelEstudios = "Primaria";
                    RentaNum += 1;
                    break;

                case 2:
                    nivelEstudios = "ESO/EGB";
                    RentaNum += 2;
                    break;

                case 3:
                    nivelEstudios = "Ciclo medio";
                    RentaNum += 3;
                    break;

                case 4:
                    nivelEstudios = "Ciclo Superior";
                    RentaNum += 4;
                    break;

                case 5:
                    nivelEstudios = "Universitario";
                    RentaNum += 5;
                    break;
            }
            return nivelEstudios;
        }

        /*
        * Si ha cancelado la matricula y quedan menos de dos años a simular el alumno puede estar 
        *    pausado o ha abandonado, más años es siempre abandono
        */
        public void CancelacionMatricula(int yearRestantes, double probAbandono)
        {
            if(yearRestantes < 2)
            {
                var rand = new Random();

                if(rand.NextDouble()*100 > probAbandono)
                    Estado = "Pausado";
                else
                    Estado = "Abandono";
            }
            else
                Estado = "Abandono";
        }

        public void CalcularAbandono(double probAbandono)
        {
            var rand = new Random();
            
            if( (rand.NextDouble()*100) > probAbandono)
                Estado = "Activo";
            else
                Estado = "Abandono";
        }
    }
}