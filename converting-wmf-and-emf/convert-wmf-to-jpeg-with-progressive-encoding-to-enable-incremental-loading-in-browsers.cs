// HOW-TO: Convert WMF to Progressive JPEG for Incremental Browser Loading in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/input.wmf";
        string outputPath = "Output/output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (JpegOptions jpegOptions = new JpegOptions())
                {
                    jpegOptions.CompressionType = JpegCompressionMode.Progressive;
                    image.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to display vector WMF graphics on a web page and want faster perceived load times by using progressive JPEGs that render gradually in the browser.
 * 2. When a legacy application generates reports as WMF files and you must convert them to web‑friendly JPEG images with progressive encoding for seamless integration into HTML emails.
 * 3. When optimizing a content management system that stores WMF assets and you require automated C# code to produce progressive JPEG thumbnails that load incrementally on mobile devices.
 * 4. When migrating a digital archive from Windows Metafile format to JPEG while preserving bandwidth by enabling progressive compression through Aspose.Imaging in a .NET service.
 * 5. When building an image processing pipeline that converts WMF logos to progressive JPEGs so browsers can display a low‑quality preview before the full image finishes downloading.
 */
