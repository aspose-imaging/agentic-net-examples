// HOW-TO: Convert ODG to PNG with Gamma Correction Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };
                image.Save(outputPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(outputPath))
            {
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }
                raster.AdjustGamma(2.2f);
                raster.Save(outputPath);
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
 * 1. When you need to display an OpenDocument Graphics (ODG) diagram on a web page, you can convert it to a PNG and adjust gamma so the colors appear with correct brightness across browsers.
 * 2. When generating thumbnails for a document management system, converting ODG files to PNG and applying gamma correction ensures consistent visual quality on different monitors.
 * 3. When preparing print‑ready assets from ODG drawings, rasterizing them to PNG and correcting gamma helps match the intended brightness before sending to a printer.
 * 4. When integrating ODG support into a C# desktop application, using Aspose.Imaging to convert and gamma‑adjust the image allows seamless viewing alongside other raster formats.
 * 5. When automating batch processing of design files, converting each ODG to PNG with gamma correction prevents washed‑out images in downstream image‑processing pipelines.
 */
