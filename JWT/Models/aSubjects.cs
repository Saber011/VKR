using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWT.Models
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class aSubjects
    {

        /// <summary>
        /// ID 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSubject { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public string NameSubject { get; set; }
    }
}
