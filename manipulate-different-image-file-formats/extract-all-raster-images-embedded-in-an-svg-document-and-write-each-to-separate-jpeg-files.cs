// HOW-TO: Extract Embedded Raster Images from SVG and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputFolder = "Output";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputFolder);

            using (Image image = Image.Load(inputPath))
            {
                var vectorImage = image as VectorImage;
                if (vectorImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a vector image.");
                    return;
                }

                var embeddedImages = vectorImage.GetEmbeddedImages();
                int index = 0;
                foreach (var embedded in embeddedImages)
                {
                    using (embedded)
                    {
                        var raster = embedded.Image as RasterImage;
                        if (raster == null)
                            continue;

                        string outputPath = Path.Combine(outputFolder, $"embedded_{index++}.jpg");
                        string dir = Path.GetDirectoryName(outputPath);
                        if (!string.IsNullOrEmpty(dir))
                            Directory.CreateDirectory(dir);

                        JpegOptions jpegOptions = new JpegOptions();
                        raster.Save(outputPath, jpegOptions);
                    }
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
 * 1. When you need to pull out bitmap graphics embedded in an SVG logo and convert them to JPEG files for use in a web‑gallery.
 * 2. When a design workflow requires separating raster assets from a vector illustration so they can be edited independently in Photoshop.
 * 3. When an automated build process must extract all embedded images from SVG icons and store them as JPEG thumbnails for a mobile app.
 * 4. When migrating legacy SVG assets to a content management system that only accepts JPEG images, you can programmatically extract and convert each raster element.
 * 5. When generating reports that embed SVG diagrams but need the raster parts as separate JPEG files for compatibility with PDF generators.
 */
