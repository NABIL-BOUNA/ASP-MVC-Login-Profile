using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ExamAspNabilBouna.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Entrez login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Entrez le password")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

        [Required(ErrorMessage = "Confirm le password")]
        [DataType(DataType.Password)]
        public string rePass { get; set; }

        [Required(ErrorMessage = "Entrez le nom")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Entrez email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Entrez la date Naissance")]
        public DateTime DateNaissance { get; set; }
    }
}