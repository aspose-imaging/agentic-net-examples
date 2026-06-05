using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully.
        try
        {
            // Hard‑coded input and output file paths.
            string inputPath = @"C:\Images\source.wmf";
            string outputPath = @"C:\Images\result.png";

            // Verify that the input WMF file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary).
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WMF image.
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options with vector rasterization settings.
                var pngOptions = new PngOptions
                {
                    // Preserve transparency by setting a transparent background.
                    VectorRasterizationOptions = new WmfRasterizationOptions
                    {
                        PageSize = image.Size,
                        BackgroundColor = Aspose.Imaging.Color.Transparent
                    }
                };

                // Save the image as PNG.
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Output any runtime error message without crashing.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to render legacy WMF icons on a modern web page by converting them to PNG with a transparent background using Aspose.Imaging for .NET.
 * 2. When a Windows desktop application must embed WMF diagrams into printable PDF reports and first convert them to PNG while preserving the alpha channel via Aspose.Imaging.
 * 3. When an automated build pipeline generates PNG thumbnails from vector WMF assets for a digital asset management system, ensuring transparency with Aspose.Imaging rasterization options.
 * 4. When a SaaS platform accepts user‑uploaded WMF logos and stores them as PNG files with preserved transparency for use in email templates, leveraging Aspose.Imaging in C#.
 * 5. When a batch script migrates a library of old WMF graphics to PNG for a mobile app that only supports raster images with alpha transparency, using Aspose.Imaging’s vector rasterization.
 */