// HOW-TO: Convert ODG to BMP with Original Size Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\input.odg";
            string outputPath = @"C:\temp\output.bmp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Prepare BMP save options
                BmpOptions bmpOptions = new BmpOptions();

                // Configure rasterization to preserve original dimensions
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    // Optional: set a background color if needed
                    BackgroundColor = Color.White,
                    // Preserve the original size of the vector image
                    PageSize = image.Size
                };

                // Assign the rasterization options to the BMP options
                bmpOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as BMP
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            // Output any error messages without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to embed an OpenDocument graphic into a Windows application that only supports BMP files, preserving its exact dimensions.
 * 2. When generating thumbnails for ODG drawings in a document management system that stores images as BMP for compatibility.
 * 3. When automating a migration of legacy ODG assets to BMP format for use in legacy printing pipelines that require fixed‑size raster images.
 * 4. When creating a server‑side service that receives ODG uploads and returns BMP copies with the original size for further processing.
 * 5. When developing a batch conversion tool that converts multiple ODG files to BMP while keeping the original vector dimensions intact.
 */
