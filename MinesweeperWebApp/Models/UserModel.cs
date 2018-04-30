using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

//CST- 247
//Prof. Reha
//Created by: William Bierer @ Stuart Reeder
//This is our work
namespace MinesweeperWebApp.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is a Required Field")]  //Determines the error messaging when creating a form
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is a Required Field")]
        public string LastName { get; set; }

        [Display(Name = "Sex")]
        [Required(ErrorMessage = "Sex is a Required Field")]
        public string Sex { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Birthday is a Required Field")]
        [DataType(DataType.DateTime)] //Sets the datatype when creating a form
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State is a Required Field")]
        public string State { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is a Required Field")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is a Required Field")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is a Required Field")]
        [DataType(DataType.Password)]
        [MinLength(4,ErrorMessage = "Minimum 4 characters required")]
        public string Password { get; set; }

        //Used for Confirming password
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password does not match!")] //Compares the variable to another variable ensure they are equal.  Used in the form
        public string ConfirmPassword { get; set; }


    }
}