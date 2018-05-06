using System.Collections.Generic;

namespace OverWeightControl.Core.FileTransfer.WorkFlow
{
    public interface IWorkflowStatistic
    {
        IDictionary<string, int> GetStatistic();
    }
}