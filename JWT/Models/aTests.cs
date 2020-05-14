using System.ComponentModel.DataAnnotations;

namespace JWT.Models
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class aTests
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int IdTest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdSubject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NameTest { get; set; }
    }
}
