// HOW-TO: Create 150x150 JPEG Thumbnail From DNG Image In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dng";
        string outputPath = "thumbnail.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage dngImage = (RasterImage)Image.Load(inputPath))
            {
                dngImage.Resize(150, 150, ResizeType.NearestNeighbourResample);
                var jpegOptions = new JpegOptions();
                jpegOptions.Quality = 90;
                dngImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate small preview images for raw DNG photos to display in a web gallery.
 * 2. When an e‑commerce platform must show fast‑loading thumbnails of product photos captured in DNG format.
 * 3. When a digital asset management system requires converting high‑resolution raw files to low‑size JPEG thumbnails for quick browsing.
 * 4. When a mobile app needs to create 150 × 150 pixel previews of user‑uploaded DNG images before uploading them to a server.
 * 5. When a batch processing script must resize raw camera files to JPEG thumbnails for archival cataloging.
 */
