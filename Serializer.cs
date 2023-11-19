using System.Text.Json;

public class Serializer{
    
    public string fileName = "Db_File.json";

    public Serializer(){}

    public void SaveDB(DictionaryEntity db){
        string serializedValues = JsonSerializer.Serialize(db);
        Console.WriteLine(serializedValues);
        File.WriteAllText(fileName, serializedValues);

        Console.WriteLine(File.ReadAllText(fileName));
    }

    public Dictionary LoadDB(){
        return new Dictionary(JsonSerializer.Deserialize<DictionaryEntity>(File.ReadAllText(fileName)));
    }

}
