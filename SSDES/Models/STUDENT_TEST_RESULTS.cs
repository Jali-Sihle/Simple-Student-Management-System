//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SSDES.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class STUDENT_TEST_RESULTS
    {
        public int STR_id { get; set; }
        public string TEST_NAME { get; set; }
        public decimal TEST_MARK { get; set; }
        public int Stid { get; set; }
    
        public virtual STUDENT_INFO STUDENT_INFO { get; set; }
    }
}