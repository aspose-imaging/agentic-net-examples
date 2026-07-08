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
            string inputPath = @"C:\Temp\sample.odg";
            string outputPath = @"C:\Temp\sample.png";

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
                // Configure rasterization options with transparent background
                OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.Transparent,
                    PageSize = image.Size // preserve original size
                };

                // Set PNG save options and attach rasterization options
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as PNG preserving transparency
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to render OpenDocument graphics (ODG) on a website that only supports raster formats, they can use this C# Aspose.Imaging code to convert the ODG to a PNG while preserving the transparent background.
 * 2. When an application must generate thumbnail previews of ODG drawings for a file‑manager UI, this code creates PNG thumbnails that keep the original shape without adding an opaque background.
 * 3. When a reporting system has to embed ODG diagrams into PDF or Word documents, the code converts the ODG to a PNG with an alpha channel so the images layer correctly in the final report.
 * 4. When a mobile app imports user‑created ODG illustrations and needs them as stickers, this snippet converts the ODG to a PNG with transparency, allowing the stickers to blend seamlessly on any background.
 * 5. When an automated build pipeline processes design assets for a game engine that requires texture files with transparency, the code converts the source ODG files to PNGs while maintaining the transparent background.
 */