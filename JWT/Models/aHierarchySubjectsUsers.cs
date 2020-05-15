using System.ComponentModel.DataAnnotations;

namespace JWT.Models
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class aHierarchySubjectsUsers
    {
        /// <summary>
        /// ID 
        /// </summary>
        public int IdUser { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public int IdSubject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HierarchyTestsUser { get; set; }
    }
}
