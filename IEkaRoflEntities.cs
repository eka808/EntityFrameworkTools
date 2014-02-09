using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkaRofl.Data.Interfaces
{
    public interface IEkaRoflEntities
    {
        IDbSet<EkaRofl.Data.Model.BaseItem> BaseItems { get; set; }
        IDbSet<EkaRofl.Data.Model.TextItem> TextItems { get; set; }
        IDbSet<EkaRofl.Data.Model.ListItem> ListItems { get; set; }
    }
}
