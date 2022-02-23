using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Intertel.Models
{

    public class MasterSearchParam
    {
        public int page { get; set; } = 1;
        public int limt { get; set; } = 20;
        public string name { get; set; }
    }
}
