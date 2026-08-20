// HOW-TO: Convert WMF to PNG with 50% Scaling in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.wmf";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WmfImage wmf = (WmfImage)Image.Load(inputPath))
            {
                var rasterOptions = new WmfRasterizationOptions
                {
                    // Set the page size to half of the original dimensions
                    PageSize = new SizeF(wmf.Width * 0.5f, wmf.Height * 0.5f)
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                wmf.Save(outputPath, pngOptions);
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
 * 1. When you need to embed a vector WMF logo into a web page that only supports raster PNG images and want the image at half its original size.
 * 2. When generating thumbnails of WMF diagrams for a document preview system and you want to reduce file size by scaling the output PNG to 50% of the source dimensions.
 * 3. When converting legacy WMF drawings to PNG for low‑resolution printing while preserving the aspect ratio with a custom half‑size rasterization factor.
 * 4. When creating responsive UI assets where a WMF icon must be displayed as a smaller PNG on mobile screens, requiring automatic scaling during conversion.
 * 5. When automating batch processing of multiple WMF files to PNG with a fixed scaling factor to ensure consistent image dimensions across a product catalog.
 */
