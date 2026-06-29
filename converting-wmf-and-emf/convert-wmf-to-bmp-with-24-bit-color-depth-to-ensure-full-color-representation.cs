using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.wmf";
        string outputPath = @"C:\Images\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for the WMF
                var rasterizationOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.White
                };

                // Set BMP save options with 24‑bit color depth
                var bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24,
                    VectorRasterizationOptions = rasterizationOptions
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
 * 1. When a Windows desktop application needs to display legacy vector WMF icons as high‑color BMP thumbnails in a file‑explorer view, the code converts WMF to a 24‑bit BMP preserving full color.
 * 2. When a batch image‑processing service must archive old WMF diagrams as raster BMP files for compatibility with legacy printing hardware that only accepts 24‑bit BMP, this snippet performs the conversion.
 * 3. When a C# reporting tool generates charts in WMF format but the final PDF generator only supports bitmap images, developers can use this code to rasterize the WMF to a 24‑bit BMP before embedding.
 * 4. When a migration script moves graphic assets from a legacy CAD system that exports WMF files to a modern web portal that stores images as BMP with true‑color depth, the example provides the necessary conversion.
 * 5. When an automated testing framework validates visual fidelity by comparing rendered WMF graphics against reference BMP images, developers can employ this code to produce consistent 24‑bit BMP outputs for pixel‑by‑pixel comparison.
 */