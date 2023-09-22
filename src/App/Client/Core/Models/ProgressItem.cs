using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functionland.FxBlox.Client.Core.Models
{
    public class ProgressItem
    {
        public ProgressItem(string title, string? description = null, ProgressType progressType = ProgressType.Pending)
        {
            Title = title;
            Description = description;
            ProgressType = progressType;
        }

        public string Title { get; set; }
        public string? Description { get; set; }
        public ProgressType ProgressType { get; set; }
    }
}
