using System.Text.Json;

public class Serializer{
    
    public string fileName = "DbFile.json";

    public Serializer(){}

    public void SaveDB(DictionaryEntity db){
        string serializedValues = JsonSerializer.Serialize(db);
        File.WriteAllText(fileName, serializedValues);
    }

    public Dictionary LoadDB(){
        return new Dictionary(JsonSerializer.Deserialize<DictionaryEntity>(File.ReadAllText(fileName)));
    }

}
