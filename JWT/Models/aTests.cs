using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
