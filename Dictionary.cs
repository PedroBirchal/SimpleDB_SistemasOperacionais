using System.Text.Json.Serialization;

public class Dictionary{
    #region Atributes
    public Listing<Key> keys;
    public Listing<string> values;
    public string policy;
    #endregion


    #region Constructors
    public Dictionary(int size, string policy){
        if(size <= 0) throw new Exception ("Invalid size for data-base");
        if(policy != "fifo" && policy != "lru") throw new Exception("Invalid policy");
        if(policy == "fifo"){
            this.policy = policy;
            keys = new FifoListing<Key>(size, new Key(-1));
            values = new FifoListing<string>(size, null);
        } 
        else if(policy == "lru"){
            this.policy = policy;
            keys = new LruListing<Key>(size, new Key(-1));
            values = new LruListing<string>(size, null);
        }
    }

    [JsonConstructor]
    public Dictionary(DictionaryEntity db){
        policy = db.policy;
        
        if(policy == "fifo"){
            keys = new FifoListing<Key>(db.size, new Key(-1));
            values = new FifoListing<string>(db.size, null);
        } 
        else{
            keys = new LruListing<Key>(db.size, new Key(-1));
            values = new LruListing<string>(db.size, null);
        }

        for(int i = 0; i < db.keys.Length; i++){
            keys.Add(db.keys[i]);
            values.Add(db.values[i]);
        }
    }
    #endregion

    public void Insert(int keyValue, string value){
        if(keyValue <= 0) throw new Exception($"Invalid key informed :{keyValue}");

        Key key = new Key(keyValue);
        keys.Add(key);
        values.Add(value);
        Console.WriteLine($"Inserted new object : \"{value}\" in DataBase");
        Console.WriteLine($"{values.index} espaces out of {values.size} have been occupied in the DataBase");
    }

    public void Remove(int keyValue){
        int indexPos;
        Key key = new Key(keyValue);

        if(keys.Search(key, out indexPos)){
            keys.Remove(indexPos);
            string removed = values.Remove(indexPos);
            Console.WriteLine($"Object : {removed} was removed from DataBase");
        }
        else throw new Exception("The key value informed wasn't found on the DataBase");
    }

    public bool Search(int keyValue, out int indexPos){
        Key key = new Key(keyValue);
        if(keys.Search(key, out indexPos)){
            Console.WriteLine($" Object : {values.Print(indexPos)} was found with the {keyValue} key");
            return true;
        }
        else{
            Console.WriteLine($" No object was found with the {keyValue} key");
            return false;
        }
    }

    public void Update(int keyValue, string updateValue){
        int pos;
        if(Search(keyValue, out pos)){
            values[pos].value = updateValue;
            Console.WriteLine($"Object with key : {keyValue} new value set to : {values[pos].value}");
        }
    }

    public DictionaryEntity ToEntity(){
        DictionaryEntity de = new DictionaryEntity();
        de.values = values.ToArray();
        de.keys = keys.ToArray();
        de.policy = policy;
        de.size = de.values.Length;
        return de;
    }

    //[JsonConstructor]
    //public Dictionary(int[] keys, string[] values, POLICY policy){
    //    this.keys = keys;
    //    this.values = values;
    //    this.policy = policy;
    //}
}

[Serializable]
public class DictionaryEntity{
    [JsonInclude] public Key[] keys;
    [JsonInclude] public string[] values;
    [JsonInclude] public string policy;
    [JsonInclude] public int size;
}

public class Key{
    public int value;

    public Key(int value){this.value = value;}
}