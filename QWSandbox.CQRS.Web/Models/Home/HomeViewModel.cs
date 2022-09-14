using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QWSandbox.CQRS.Web.Models.Home
{
	public class HomeViewModel
    {
        public List<UserViewModel> Users { get; set; } = new();
    }
}
