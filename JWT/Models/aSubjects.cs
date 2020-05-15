using System.ComponentModel.DataAnnotations;

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
        public int IdSubject { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public string NameSubject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HierarchyTests { get; set; }
    }
}
