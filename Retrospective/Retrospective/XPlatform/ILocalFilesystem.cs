namespace Retrospective.XPlatform
{
    public interface ILocalFilesystem
    {
        string GetLocalFilePath(string filename);
    }
}