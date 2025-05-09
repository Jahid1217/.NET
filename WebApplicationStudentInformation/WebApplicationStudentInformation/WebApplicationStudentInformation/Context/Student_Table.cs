//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationStudentInformation.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Student_Table
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First Name can not exceed 50 charecters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name can not exceed 50 charecters.")]
        [StringLength(50, ErrorMessage = "Last  Name can not exceed 50 charecters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public System.DateTime Dob { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Display(Name = "Email")]
        public string Emaill { get; set; }

        [Required(ErrorMessage = "Phone no is required.")]
        [Phone(ErrorMessage = "Invalid Phone Number.")]
        public string Phone_No { get; set; }

        [Required(ErrorMessage = "CGPA is required.")]
        [Range(0.00, 4.00, ErrorMessage = "CGPA must be between 0.00 and 4.00.")]
        public double CGPA { get; set; }

        [Required(ErrorMessage = "Blood Group is required.")]
        [RegularExpression(@"^(A|B|AB|O)[+-]$", ErrorMessage = "Invalid Blood Group format.")]
        [Display(Name = "Blood Group")]
        public string Blood_Group { get; set; }
    }
}
