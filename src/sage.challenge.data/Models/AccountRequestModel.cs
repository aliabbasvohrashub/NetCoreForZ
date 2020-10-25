using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace sage.challenge.data.Models
{
    public class AccountRequestModel
    {
        [Required]
        [MaxLength(128,ErrorMessage ="Company name can at most be 128 characters in length.")]
        public string CompanyName { get; set; }
        public string Website { get; set; }
    }
}
