using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreTests.Models
{
    public class Writer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Story> Stories { get; set; } = new List<Story>();
    }
}
