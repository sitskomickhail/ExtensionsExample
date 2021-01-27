using GetRowChangedPosition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetRowChangedPosition.Services.Interfaces
{
    public interface IRowTrackerService
    {
        void SetValue(RowInfoModel rowInfo);

        void SetDelegate(Action<RowInfoModel> action);
    }
}