using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appdev.Models
{
    public class Course
    {
		[Key]
		public int ID { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[Required]
		[StringLength(255)]
		public string Description { get; set; }
		[ForeignKey("Category")]
		[Required]
		public int CategoryID { get; set; }
		public Category Category { get; set; }
		[ForeignKey("User")]
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }
	}
}