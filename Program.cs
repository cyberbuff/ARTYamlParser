using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Newtonsoft.Json.Linq;

namespace ARTYamlParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .Build();
            var fileReader = File.OpenText("test.yaml");
            var yamlObject = deserializer.Deserialize(fileReader);
            
            // Converting to JSON as YamlDotNet can convert YAML either to a class or none. 
            // Converting to class needs all the variables to be defined. 
            var serializer = new SerializerBuilder()
                .JsonCompatible()
                .Build();

            var json = serializer.Serialize(yamlObject);
            dynamic aTechnique = JToken.Parse(json);
            Console.WriteLine(aTechnique.atomic_tests[0].executor.command);        
        }
    }
}
