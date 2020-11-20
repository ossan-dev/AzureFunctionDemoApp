using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HttpAzureFunctionDemo
{
    public class Args
    {
        [JsonPropertyName("connectionString")]
        public string ConnectionString { get; set; }
    }

    public class WriteTo
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Args")]
        public Args Args { get; set; }
    }

    public class Serilog
    {
        [JsonPropertyName("WriteTo")]
        public List<WriteTo> WriteTo { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("Serilog")]
        public Serilog Serilog { get; set; }
    }
}
