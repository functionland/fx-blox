using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functionland.FxBlox.Client.Core.Models
{
    public class ListItem<T>
    {
        public T Item { get; set; }
        public bool IsSelected { get; set; } = false;

    }
}
