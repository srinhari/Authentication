namespace IAMService.Settings {
    public class MongoDbConfig {
        public MongoDbConfig(string name, string host, int port)
        {
            Name = name;
            Host = host;
            Port = port;
        }
        public string Name { get; }
        public string Host { get; }
        public int Port { get; }

        public string ConnectionString => $"mongodb://{Host}:{Port}";
    }
}
