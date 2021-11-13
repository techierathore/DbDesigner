using DbDesigner.Models;
using Microsoft.AspNetCore.Components;
namespace DbDesigner.UI.Components
{
    public partial class TableNode
    {
        [Parameter]
        public Table Node { get; set; }
    }
}
