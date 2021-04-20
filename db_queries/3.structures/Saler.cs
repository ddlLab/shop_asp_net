using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace db_queries._3.structures
{
    public class eSaler
    {
        public long   Id           { get; set; } = -1;
        public string Nickname     { get; set; } = "";
        public string Email        { get; set; } = "";
        public string Password     { get; set; } = "";
        public string Phone        { get; set; } = "";
        public string Photo        { get; set; } = "";
        public string Desc         { get; set; } = "";
        public string Paycard      { get; set; } = "";
        public int    Balance      { get; set; } = 0;
        public bool   IsBlocked    { get; set; } = false;
        public override string ToString()
        {
            return JsonSerializer.Serialize<eSaler>(this);
        }
    }
}
