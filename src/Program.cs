namespace GCEE
{
    using System;
    using System.Configuration;
    using System.Collections.Specialized;
    class Programs
    {
        static void Main(string[] args)
        {
            StaticData data = new StaticData();
            data.loadData();

            //Simulator simulator = new Simulator(ConfigurationManager.AppSettings, data);
            //simulator.InitSimulation();
            //simulator.Read();
        }
    }
}