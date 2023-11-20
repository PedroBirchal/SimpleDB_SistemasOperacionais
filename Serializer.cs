using System.Text.Json;

public class Serializer{
    
    public string fileName = "Db_File.json";

    public Serializer(){}

    public void SaveDB(DictionaryEntity db){
        string serializedValues = JsonSerializer.Serialize(db);
        Console.WriteLine(serializedValues);
        File.WriteAllText(fileName, serializedValues);
    }

    public Dictionary GetDB(){
        return ParseDB(LoadDB());
    }

    public DictionaryEntity LoadDB(){
        string sourceFile = File.ReadAllText(fileName);
        DictionaryEntity db = JsonSerializer.Deserialize<DictionaryEntity>(sourceFile);
        return db;
    }

    public Dictionary ParseDB(DictionaryEntity de){
        Dictionary db = new Dictionary(de.size, de.policy);
        foreach(Container data in de.keys){
            if(data == null) break;
            else db.keys.Add(data);
        }
        foreach(string data in de.values){
            if(data == null) break;
            db.values.Add(data);
        }
        return db;
    }

}
