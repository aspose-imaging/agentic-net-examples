using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded list of SVG files to convert
            string[] inputFiles = new[]
            {
                @"C:\Images\example1.svg",
                @"C:\Images\example2.svg",
                @"C:\Images\example3.svg"
            };

            // Single rasterization options instance reused for all conversions
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Adjust page size for the current image
                    rasterOptions.PageSize = image.Size;

                    // Prepare BMP save options and attach the shared rasterization options
                    BmpOptions bmpOptions = new BmpOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Determine output BMP path (same folder, .bmp extension)
                    string outputPath = Path.ChangeExtension(inputPath, ".bmp");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image as BMP
                    image.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to generate bitmap thumbnails from a collection of SVG icons for a Windows desktop application, they can batch convert the SVG files to BMP using a shared SvgRasterizationOptions instance.
 * 2. When an automated build pipeline must convert vector graphics stored as SVG into BMP assets for legacy reporting tools that only accept raster images, this code provides a fast C# solution.
 * 3. When a content management system imports user‑uploaded SVG illustrations and must store them as BMP files for compatibility with older printers, the developer can reuse a single rasterization options object to process many files efficiently.
 * 4. When a game engine requires BMP textures derived from SVG assets and the developer wants to ensure consistent page size across all conversions, this example shows how to loop through files with Aspose.Imaging.
 * 5. When a batch image‑processing script needs to validate the existence of SVG files, adjust their dimensions, and save them as BMP in the same folder, the code demonstrates the necessary C# file‑system and Aspose.Imaging operations.
 */