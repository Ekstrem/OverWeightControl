using System.Collections.Generic;
using System.ServiceModel;

namespace OverWeightControl.Core.Upgrade
{
    [ServiceContract]
    public interface IDownloader
    {
        [OperationContract]
        int GetLastVersion();
        [OperationContract]
        IEnumerable<string> GetFileList(int version);
        [OperationContract]
        byte[] DownLoadFile(int version, string fileName);
    }
}