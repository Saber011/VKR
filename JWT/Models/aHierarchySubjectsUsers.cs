using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWT.Models
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class aHierarchySubjectsUsers
    {

        /// <summary>
        /// ef
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Key { get; set; }

        /// <summary>
        /// ID 
        /// </summary>
        public int? IdUser { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public int IdSubject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdTest { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int? IdParent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Depth { get; set; }
    }
}
