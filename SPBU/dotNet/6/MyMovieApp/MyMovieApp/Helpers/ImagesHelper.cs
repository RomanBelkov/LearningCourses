using System.Drawing;
using static System.String;

namespace MyMovieApp.Helpers
{
    internal static class ImagesHelper
    {
        internal static Image FromFile(string path)
        {
            return IsNullOrEmpty(path) ? null : Image.FromFile(path);
        }
    }
}
