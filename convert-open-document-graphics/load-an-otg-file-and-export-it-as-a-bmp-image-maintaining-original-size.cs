using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.otg";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization to keep original size
                OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set BMP save options and attach rasterization options
                BmpOptions bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = otgOptions
                };

                // Save as BMP preserving original dimensions
                image.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to convert a vector OTG diagram to a raster BMP for legacy Windows applications while preserving the original image dimensions.
 * 2. When a C# service must generate thumbnail‑style BMP previews of OTG files for a document management system without scaling the graphics.
 * 3. When an automated batch job has to export OTG engineering drawings to BMP format for inclusion in reports that only accept bitmap images.
 * 4. When a desktop utility must load OTG icons and save them as BMP files to ensure compatibility with older UI components that require fixed‑size bitmaps.
 * 5. When a migration script has to transform OTG assets into BMP assets for a game engine that does not support vector formats but needs the exact original size.
 */