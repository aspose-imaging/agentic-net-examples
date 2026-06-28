using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\output.bmp";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the ODG vector image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Set up BMP rasterization options for ODG
                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = new OdgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = odgImage.Size
                    }
                };

                // Rasterize and save as BMP
                odgImage.Save(outputPath, bmpOptions);
            }

            // Load the rasterized BMP
            using (Image bmpImage = Image.Load(outputPath))
            {
                // Cast to RasterImage to access binarization
                var raster = (RasterImage)bmpImage;

                // Apply Otsu threshold to create a binary image
                raster.BinarizeOtsu();

                // Save the binary BMP (overwrites the previous file)
                raster.Save(outputPath);
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
 * 1. When a developer needs to import an OpenDocument Graphics (ODG) diagram into a legacy Windows application that only accepts BMP files, they can rasterize the vector image and save it as BMP.
 * 2. When preparing scanned engineering drawings stored as ODG for OCR processing, converting them to BMP and applying an Otsu threshold creates a high‑contrast binary image that improves text recognition accuracy.
 * 3. When generating printable line art from ODG files for laser cutting, converting to BMP and binarizing the image ensures the cutter receives a clean black‑and‑white bitmap.
 * 4. When archiving vector diagrams as compact, device‑independent raster images, developers can use this code to convert ODG to BMP and then apply a threshold to reduce file size and simplify storage.
 * 5. When integrating ODG assets into a .NET web service that returns binary images for downstream image‑analysis APIs, the code converts the ODG to BMP and produces a binary image ready for analysis.
 */