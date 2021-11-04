namespace IAMServer.Settings {
    public class MongoDbConfig {
        public MongoDbConfig()
        {
            
        }
        public MongoDbConfig(string name, string host, int port) {
            Name = name;
            Host = host;
            Port = port;
        }
        public string Name { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

        public string ConnectionString => $"mongodb://{Host}:{Port}";
    }
}