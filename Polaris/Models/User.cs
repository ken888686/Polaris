using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polaris.Models
{
    public class User
    {
        public int Id { get; set; }
        public string MyProperty { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<Character>? Characters { get; set; }
    }
}
