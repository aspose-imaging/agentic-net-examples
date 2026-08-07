// HOW-TO: Convert Multi‑Layer SVG to PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = image as SvgImage;
                if (svgImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not an SVG.");
                    return;
                }

                // Prepare rasterization options
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize SVG to a memory stream and save to output file
                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;
                    using (FileStream outStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        ms.CopyTo(outStream);
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
 * 1. When you need to generate a raster PNG preview of an SVG diagram for web thumbnails.
 * 2. When you must programmatically convert user‑uploaded SVG assets to PNG for email attachments.
 * 3. When you want to ensure consistent page size by rasterizing an SVG at its original dimensions.
 * 4. When you need to automate batch processing of SVG files into PNGs in a .NET backend service.
 * 5. When you require error handling for missing files while converting vector graphics to raster images.
 */
