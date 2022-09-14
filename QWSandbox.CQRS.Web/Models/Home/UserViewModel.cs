using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWSandbox.CQRS.Web.Models.Home
{
	public class UserViewModel
	{
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(20)]
        public string Comment { get; set; }
    }
}
