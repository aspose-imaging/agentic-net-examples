using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.psd";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Image psdImage = Image.Load(inputPath))
            {
                // Set PNG options to preserve alpha channel
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Save PSD as PNG into a memory stream first
                using (var memoryStream = new MemoryStream())
                {
                    psdImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // Load the PNG from the memory stream to check transparency
                    using (PngImage pngImage = (PngImage)Image.Load(memoryStream))
                    {
                        bool hasAlpha = pngImage.HasAlpha;
                        Console.WriteLine($"PNG has alpha channel: {hasAlpha}");
                    }

                    // Reset stream position and write final PNG to disk
                    memoryStream.Position = 0;
                    using (FileStream fileStream = File.Create(outputPath))
                    {
                        memoryStream.CopyTo(fileStream);
                    }
                }
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
 * 1. When a web application uses Aspose.Imaging for .NET to convert user‑uploaded Photoshop PSD files to PNG and must verify that the resulting PNG retains its alpha channel for transparent backgrounds.
 * 2. When an e‑commerce platform employs Aspose.Imaging to generate product thumbnails from layered PSD assets and needs to confirm the PNG output preserves transparency before displaying on the storefront.
 * 3. When a game development pipeline utilizes Aspose.Imaging for .NET to export sprite sheets from PSD files and checks the PNG’s HasAlpha property to ensure proper alpha blending in the engine.
 * 4. When an automated image processing service batch‑processes PSD logos with Aspose.Imaging, converting them to PNG and validating the presence of an alpha channel to prevent white backgrounds in printed collateral.
 * 5. When a digital publishing tool creates PNG previews of PSD artwork using Aspose.Imaging for .NET and must confirm transparency to keep layout consistency in email newsletters.
 */