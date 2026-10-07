// HOW-TO: Crop a Region from OTG Image and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.otg";
            string outputPath = "Output/cropped.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                var cropRect = new Rectangle(50, 50, 200, 200);
                image.Crop(cropRect);

                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to extract a specific part of an OTG diagram for a report and deliver it as a lightweight PNG file.
 * 2. When an application processes scanned engineering drawings in OTG format and must generate cropped thumbnails for a web gallery.
 * 3. When a batch job converts selected sections of OTG maps into PNG assets for use in mobile apps.
 * 4. When a document management system isolates a region of an OTG image to create a preview image without exposing the full original file.
 * 5. When a developer integrates Aspose.Imaging to programmatically cut out a logo area from an OTG file and save it as a PNG for branding purposes.
 */
