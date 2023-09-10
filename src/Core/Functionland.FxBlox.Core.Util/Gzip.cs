using System.IO.Compression;
using System.Text;

namespace Functionland.FxBlox.Core.Util;

public class Gzip
{
    public static byte[] Compress(string s)
    {
        try
        {
            var bytes = Encoding.Unicode.GetBytes(s);
            using var msi = new MemoryStream(bytes);
            using var mso = new MemoryStream();
            using (var gs = new GZipStream(mso, CompressionMode.Compress))
            {
                msi.CopyTo(gs);
            }

            return mso.ToArray();
        }
        catch (OutOfMemoryException ex)
        {
            //ToDo: Log
            //ToDo: Notify support; send something to botLog
            throw;
        }
    }

    public static string Decompress(byte[] bytes)
    {
        using var msi = new MemoryStream(bytes);
        using var mso = new MemoryStream();
        using (var gs = new GZipStream(msi, CompressionMode.Decompress))
        {
            gs.CopyTo(mso);
        }
        return Encoding.Unicode.GetString(mso.ToArray());
    }
}
