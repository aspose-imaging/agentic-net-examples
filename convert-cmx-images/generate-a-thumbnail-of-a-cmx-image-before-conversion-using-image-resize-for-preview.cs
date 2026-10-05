// HOW-TO: Create PNG Thumbnail of CMX Image and Convert to JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cmx";
            string thumbnailPath = "output/thumbnail.png";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(thumbnailPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage thumb = (CmxImage)Image.Load(inputPath))
            {
                int thumbWidth = 200;
                int thumbHeight = (int)(thumb.Height * (thumbWidth / (double)thumb.Width));
                thumb.Resize(thumbWidth, thumbHeight);
                thumb.Save(thumbnailPath, new PngOptions());
            }

            using (CmxImage original = (CmxImage)Image.Load(inputPath))
            {
                original.Save(outputPath, new JpegOptions());
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
 * 1. When a web application needs to show a small preview of a CMX drawing before the user downloads the full image, this code creates a PNG thumbnail.
 * 2. When migrating legacy CMX files to JPEG for web publishing, developers can generate a preview thumbnail to verify quality before conversion.
 * 3. When building a document management system that lists CMX assets, the thumbnail can be displayed in a grid while the original is stored as JPEG.
 * 4. When implementing batch processing of CMX files, the code can quickly produce 200‑pixel wide PNG previews for each file to speed up UI rendering.
 * 5. When integrating Aspose.Imaging into a C# desktop tool, developers can use Image.Resize to generate consistent thumbnail sizes for CMX files before saving them in different formats.
 */
