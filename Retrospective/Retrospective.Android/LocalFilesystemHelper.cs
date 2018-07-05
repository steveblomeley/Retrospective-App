using System;
using System.IO;
using Retrospective.Core.XPlatform;
using Retrospective.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(LocalFilesystemHelper))]
namespace Retrospective.Droid
{
    public class LocalFilesystemHelper : ILocalFilesystem
    {
        public string GetLocalFilePath(string filename)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}