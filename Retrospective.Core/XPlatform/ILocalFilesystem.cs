namespace Retrospective.Core.XPlatform
{
    public interface ILocalFilesystem
    {
        string GetLocalFilePath(string filename);
    }
}