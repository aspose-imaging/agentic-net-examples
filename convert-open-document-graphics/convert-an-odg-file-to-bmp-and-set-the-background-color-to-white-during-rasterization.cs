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
            // Hardcoded input and output paths
            string inputPath = "input.odg";
            string outputPath = "output\\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Set rasterization options with white background
                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Configure BMP save options
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as BMP
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
 * 1. When a developer needs to convert an OpenDocument Graphics (ODG) illustration to a BMP bitmap for legacy Windows applications while ensuring a white background replaces any transparent areas.
 * 2. When an automated document processing pipeline must rasterize vector ODG files into BMP images for thumbnail generation in a C# web service.
 * 3. When a desktop publishing tool requires exporting ODG diagrams to BMP format with a solid white background to maintain visual consistency across different operating systems.
 * 4. When a batch conversion utility written in .NET has to process multiple ODG files and save them as BMP files, using Aspose.Imaging to handle rasterization options like page size and background color.
 * 5. When integrating Aspose.Imaging into a C# application to render ODG vector graphics as BMP images for printing workflows that only accept raster formats with a white background.
 */