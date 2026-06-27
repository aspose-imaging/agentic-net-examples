using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\source.tif";
        string outputPath = @"C:\temp\result.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image tiffImage = Image.Load(inputPath))
            {
                // Convert and save as PNG
                var pngOptions = new PngOptions();
                tiffImage.Save(outputPath, pngOptions);
            }

            // Load the generated PNG image
            using (Image pngImg = Image.Load(outputPath))
            {
                var pngImage = (PngImage)pngImg;
                bool hasAlpha = pngImage.HasAlpha;
                Console.WriteLine($"Generated PNG has alpha channel: {hasAlpha}");
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
 * 1. When a developer needs to convert scanned TIFF documents to PNG for web display and verify whether the resulting PNG retains any transparency for proper layering in HTML/CSS.
 * 2. When building an automated image pipeline that extracts alpha channel information from TIFF‑to‑PNG conversions to decide if the PNG can be used as a mask in graphic design workflows.
 * 3. When integrating Aspose.Imaging into a desktop application that generates thumbnails from multi‑page TIFF files and logs transparency status to avoid rendering artifacts in UI components.
 * 4. When creating a batch processing script that validates medical imaging files converted from TIFF to PNG, ensuring that no unintended alpha channel is introduced that could affect diagnostic software.
 * 5. When developing a GIS mapping tool that converts geospatial TIFF layers to PNG tiles and needs to confirm the presence of an alpha channel to correctly overlay tiles on a map canvas.
 */