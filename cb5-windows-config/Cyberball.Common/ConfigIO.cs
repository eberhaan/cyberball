using System.IO;
using System.Xml.Serialization;

namespace Cyberball.Common
{
    // ReSharper disable once InconsistentNaming
    public class ConfigIO
    {
        public static CBConfig ReadConfig(string configFilePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof (CBConfig));
            CBConfig config;
            using (TextReader reader = new StreamReader(configFilePath))
            {
                config = serializer.Deserialize(reader) as CBConfig;
            }
            return config;
        }

        public static void SaveConfig(CBConfig cbConfig, string configFilePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof (CBConfig));
            using (TextWriter writer = new StreamWriter(configFilePath))
            {
                serializer.Serialize(writer, cbConfig);
            }
        }

        public static CBSchedule ReadSchedule(string scheduleFilePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof (CBSchedule));
            CBSchedule schedule;
            using (TextReader reader = new StreamReader(scheduleFilePath))
            {
                schedule = serializer.Deserialize(reader) as CBSchedule;
            }
            return schedule;
        }

        public static void SaveSchedule(CBSchedule cbSchedule, string scheduleFilePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof (CBSchedule));
            using (TextWriter writer = new StreamWriter(scheduleFilePath))
            {
                serializer.Serialize(writer, cbSchedule);
            }
        }
    }
}