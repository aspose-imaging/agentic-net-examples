// HOW-TO: Convert OTG File to BMP While Preserving Original Dimensions in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.bmp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization to keep the original size
                var otgRasterizationOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Set up BMP save options with the rasterization settings
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = otgRasterizationOptions
                };

                // Save the image as BMP
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
 * 1. When you need to display a vector OTG diagram in a legacy Windows application that only supports BMP images.
 * 2. When you must generate bitmap thumbnails of OTG drawings for printing or reporting while keeping the exact size.
 * 3. When an automated batch process converts OTG assets to BMP for compatibility with third‑party image analysis tools.
 * 4. When you want to preserve the original dimensions of a CAD‑style OTG file while saving it as a raster BMP for archival.
 * 5. When a web service receives OTG uploads and must return BMP files without scaling for downstream processing.
 */
