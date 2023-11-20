using System.Text.Json.Serialization;

public class Dictionary{
    #region Atributes
    public Listing<Container> keys;
    public Listing<string> values;
    public string policy;
    #endregion


    #region Constructors
    public Dictionary(int size, string policy){
        this.policy = policy;
        if(policy == "fifo"){
            keys = new FifoListing<Container>(size, new Container(-1));
            values = new FifoListing<string>(size, "root");
        } 
        else{
            keys = new LruListing<Container>(size, new Container(-1));
            values = new LruListing<string>(size, "root");
        }
    }
    #endregion

    public void Insert(int keyValue, string value){
        Container key = new Container(keyValue);
        keys.Add(key);
        values.Add(value);
        Console.WriteLine($"Inserted new object : \"{value}\" in DataBase");
        Console.WriteLine($"{values.index} espaces out of {values.size} have been occupied in the DataBase");
    }

    public void Remove(int keyValue){
        int indexPos;

        if(Search(keyValue, out indexPos)){
            keys.Remove(indexPos);
            string removed = values.Remove(indexPos);
            Console.WriteLine($"Object : {removed} was removed from DataBase");
        }
        else Console.WriteLine("The key value informed wasn't found on the DataBase");
    }

    public bool Search(int keyValue, out int index){
        for(index = 0; index < keys.size; index++){
            if(keys[index].value.value == keyValue){
                Console.WriteLine($" Object : {values.Print(index)} was found with the {keyValue} key");
                return true;
            }
        }
        Console.WriteLine($" No object was found with the {keyValue} key");
        return false;
    }

    public void Update(int keyValue, string updateValue){
        int pos;
        if(Search(keyValue, out pos)){
            values[pos].value = updateValue;
            Console.WriteLine($"Object with key : {keyValue} new value set to : {values[pos].value}");
        }
        else Console.WriteLine($"No object was found with the {keyValue} key");
    }

    public DictionaryEntity ToEntity(){
        DictionaryEntity de = new DictionaryEntity
        {
            values = values.ToArray(),
            keys = keys.ToArray(),
            policy = policy
        };
        de.size = de.values.Length;
        return de;
    }
}

[Serializable]
public class DictionaryEntity{
    [JsonInclude] public Container[]? keys;
    [JsonInclude] public string[]? values;
    [JsonInclude] public string? policy;
    [JsonInclude] public int size;

    public DictionaryEntity(){}
}

public class Container{
    [JsonInclude] public int value;

    public Container(int value){this.value = value;}
}