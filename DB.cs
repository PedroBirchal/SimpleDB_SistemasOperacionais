
public class DB{

    private Serializer serializer = new Serializer();
    public Dictionary db;
    

    public DB(){}

    public void HandleArgs(string[] args){

        if(args[0] == "-cache-size"){
            if(int.Parse(args[1]) <= 0) throw new Exception ("Invalid size for data-base");
            if(args[2] != "fifo" && args[2] != "lru") throw new Exception("Invalid policy");
            CacheSize(int.Parse(args[1]), args[2]);
            return;
        }
        db = serializer.GetDB();
        if(args[0] == "--insert"){
            if(int.Parse(args[1]) <= 0) throw new Exception($"Invalid key informed :{args[1]}");
            Insert(int.Parse(args[1]), args[2]);
            return;
        }
        if(args[0] == "--remove"){
            Remove(int.Parse(args[1]));
            return;
        }
        if(args[0] == "--search"){
            Search(int.Parse(args[1]));
            return;
        }
        if(args[0] == "--update"){
            Update(int.Parse(args[1]), args[2]);
            return;
        }

    }

    public void Insert(int key, string value){
        db.Insert(key, value);
        serializer.SaveDB(db.ToEntity());
    }

    public void Remove(int key){
        db.Remove(key);
        serializer.SaveDB(db.ToEntity());
    }

    public void Search(int key){
        db.Search(key, out _);
        if(db.policy == "lru") serializer.SaveDB(db.ToEntity());
    }

    public void Update(int key, string newValue){
        db.Update(key, newValue);
        serializer.SaveDB(db.ToEntity());
    }

    public void CacheSize(int size, string policy){
        db = new Dictionary(size,policy);
        serializer.SaveDB(db.ToEntity());
    }
}
