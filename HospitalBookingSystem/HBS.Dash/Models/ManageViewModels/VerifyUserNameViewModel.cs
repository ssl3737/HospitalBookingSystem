using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HBS.Dash.Models.ManageViewModels
{
    public class VerifyUserNameViewModel
    {
        [Required]
        public string Code { get; set; }

        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
    }
}
