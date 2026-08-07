// HOW-TO: Convert EPS to JPEG with Maximum Quality Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                var rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = epsImage.Width,
                    PageHeight = epsImage.Height
                };

                using (var pngStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };
                    epsImage.Save(pngStream, pngOptions);
                    pngStream.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(pngStream))
                    {
                        var jpegOptions = new JpegOptions
                        {
                            Quality = 100
                        };
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
 * 1. When a developer needs to render a vector EPS logo as a high‑resolution JPEG for inclusion in a web page or email campaign.
 * 2. When an automated workflow must convert EPS artwork to JPEG thumbnails while preserving maximum image quality for a digital asset management system.
 * 3. When a C# application has to rasterize EPS files to JPEG for printing previews where the original EPS cannot be directly used.
 * 4. When a batch process has to transform a collection of EPS design files into JPEGs for archival or backup in a format supported by most image viewers.
 * 5. When a developer wants to programmatically generate JPEGs from EPS diagrams for use in reports or PowerPoint presentations without losing detail.
 */
