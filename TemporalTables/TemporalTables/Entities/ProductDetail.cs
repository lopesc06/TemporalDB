using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TemporalTables.Entities
{
    public class ProductDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [JsonIgnore]
        public virtual Product Product { get; set; }

        [Required]
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
