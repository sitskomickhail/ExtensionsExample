using GetRowChangedPosition.Models;
using GetRowChangedPosition.Services.Interfaces;
using System;

namespace GetRowChangedPosition.Services
{
    public static class RowTrackerService
    {
        private delegate void ChangeToolInfo(RowInfoModel model);

        private static ChangeToolInfo ToolInfo { get; set; }

        public static void SetDelegate(Action<RowInfoModel> action)
        {
            ToolInfo = (r) => action(r);
        }

        public static void SetValue(RowInfoModel rowInfo)
        {
            if (ToolInfo != null)
            {
                ToolInfo(rowInfo);
            }
        }
    }
}