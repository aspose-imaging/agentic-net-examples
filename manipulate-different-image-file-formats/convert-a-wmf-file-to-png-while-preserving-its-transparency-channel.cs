// HOW-TO: Convert WMF to PNG with Transparent Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = "input.wmf";
        string outputPath = "output.png";

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

            // Load the WMF image
            using (WmfImage wmf = (WmfImage)Image.Load(inputPath))
            {
                // Set up rasterization options to preserve transparency
                var rasterOptions = new WmfRasterizationOptions
                {
                    PageSize = wmf.Size,
                    BackgroundColor = Aspose.Imaging.Color.Transparent
                };

                // Configure PNG options with the vector rasterization options
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save as PNG preserving transparency
                wmf.Save(outputPath, pngOptions);
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
 * 1. When a Windows desktop application needs to display legacy WMF icons on a modern UI that requires PNG images with alpha transparency.
 * 2. When a reporting service generates charts as WMF files and must embed them into web pages as transparent PNGs for seamless background blending.
 * 3. When a document conversion pipeline processes vector drawings from old CAD files saved as WMF and needs loss‑less PNG output that retains transparent regions.
 * 4. When a mobile app imports WMF logos and must convert them to PNG format while preserving transparency for overlay on variable‑color backgrounds.
 * 5. When an automated build script creates asset bundles and requires converting WMF assets to PNG with transparent backgrounds to reduce file size and improve rendering performance.
 */
