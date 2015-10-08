using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Zadanie.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public double Value { get; set; }
        [Required]
        [RegularExpression(@"^\d+")]
        public double Quantity { get; set; }

        public string CategoryId { get; set; }
        public IEnumerable<SelectListItem> Items { get; set; }
    }
}