using System;
using System.Xml.Serialization;
using System.IO;

// Домашнее задание Баранцева Степана ИУ6-74
// Выбран вариант C1
namespace ApplicationHomework
{
    // Тип двигателя -- бензиновый или дизельный
    public enum EngineTypeEnum
    {
        Petrol,
        Diesel
    }

    // Исполнение Стандартное, Полярное, Тропическое (для кабины)
    public enum CabinTypeEnum
    {
        Standart,
        Polar,
        Tropic
    }

    [Serializable]
    public class Engine
    {
        public string Name { get; set; }
        public int SerialNumber { get; set; }
        public EngineTypeEnum EngineType { get; set; }

        // стандартный конструктор без параметров
        public Engine() { }

        public Engine(string name, int serialNumber, EngineTypeEnum engineType)
        {
            Name = name;
            SerialNumber = serialNumber;
            EngineType = engineType;
        }
    }

    [Serializable]
    public class Cabin
    {
        public string Name { get; set; }
        public int SerialNumber { get; set; }
        public CabinTypeEnum CabinType { get; set; }

        // стандартный конструктор без параметров
        public Cabin() { }

        public Cabin(string name, int serialNumber, CabinTypeEnum cabinType)
        {
            Name = name;
            SerialNumber = serialNumber;
            CabinType = cabinType;
        }
    }

    [Serializable]
    public class Tractor
    {
        public string Name { get; set; }
        public int SerialNumber { get; set; }
        public Cabin TractorCabin { get; set; }
        public Engine TractorEngine { get; set; }

        // стандартный конструктор без параметров
        public Tractor() { }

        public Tractor(string name, int serialNumber, Cabin cabin, Engine engine)
        {
            Name = name;
            SerialNumber = serialNumber;
            TractorCabin = cabin;
            TractorEngine = engine;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var engine = new Engine("EngineName", 42, EngineTypeEnum.Diesel);
            var cabin = new Cabin("CabinName", 13, CabinTypeEnum.Polar);
            var tractor = new Tractor("TractorName", 4521, cabin, engine);

            XmlSerializer formatter = new XmlSerializer(typeof(Tractor));

            using (FileStream fs = new FileStream("tractor.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, tractor);
            }
        }
    }
}
