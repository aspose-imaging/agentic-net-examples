using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\temp\sample.otg";
            string outputPath = @"C:\temp\sample.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options with white background
                OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageSize = image.Size
                };

                // Set up BMP save options and assign rasterization options
                BmpOptions saveOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as BMP
                image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to convert vector‑based OTG diagrams into raster BMP files for legacy Windows applications that only accept bitmap images.
 * 2. When an automated document processing pipeline must render OTG charts with a white background to ensure consistent appearance on white‑paper reports before saving them as BMP for printing.
 * 3. When a desktop application integrates Aspose.Imaging to let users export their OTG floor‑plan drawings as BMP thumbnails with a solid white background for quick previews.
 * 4. When a batch conversion utility written in C# has to rasterize multiple OTG files to BMP while normalizing the background color to white to avoid transparency issues in downstream image editors.
 * 5. When a web service needs to transform uploaded OTG graphics into BMP format with a white canvas so that the images can be displayed correctly in browsers that do not support vector formats.
 */