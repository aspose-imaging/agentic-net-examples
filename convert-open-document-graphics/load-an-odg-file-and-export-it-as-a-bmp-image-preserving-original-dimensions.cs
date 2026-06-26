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
            string inputPath = @"C:\temp\sample.odg";
            string outputPath = @"C:\temp\sample.bmp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure BMP save options with vector rasterization to preserve original dimensions
                BmpOptions bmpOptions = new BmpOptions();

                // Set rasterization options: use the source image size and a white background
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                bmpOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When a C# application must convert OpenDocument graphics (ODG) files into legacy BMP images for compatibility with older Windows software while keeping the original size.
 * 2. When a developer needs to generate thumbnail previews of ODG drawings in BMP format for a file‑explorer UI that only supports raster images.
 * 3. When an automated reporting tool has to embed ODG diagrams into a PDF that requires BMP images with a white background and exact dimensions.
 * 4. When a batch‑processing script must migrate a library of ODG assets to BMP for use in a game engine that does not support vector formats.
 * 5. When a document management system needs to store ODG files as BMP snapshots to enable fast image indexing and search based on pixel dimensions.
 */