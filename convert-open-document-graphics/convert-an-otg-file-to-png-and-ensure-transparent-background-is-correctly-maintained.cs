// HOW-TO: Convert OTG to PNG with Transparent Background in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\sample.png";

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

            // Load the OTG image
            using (Image otgImage = Image.Load(inputPath))
            {
                // Prepare PNG save options
                var pngOptions = new PngOptions();

                // Configure rasterization to preserve transparency
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size,
                    BackgroundColor = Color.Transparent // keep background transparent
                };

                // Attach rasterization options to PNG options
                pngOptions.VectorRasterizationOptions = otgRasterOptions;

                // Save as PNG
                otgImage.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to display vector OTG graphics as PNG images while keeping the original transparent background for seamless overlay on HTML pages.
 * 2. When an automated batch‑processing service must convert a library of OTG icons to PNG format for use in mobile apps without losing their alpha channel.
 * 3. When a reporting tool generates charts in OTG and requires them to be saved as PNG files for inclusion in PDF documents while preserving transparency.
 * 4. When a desktop utility imports OTG drawings and exports them as PNG thumbnails that retain transparent backgrounds for file‑explorer previews.
 * 5. When a cloud‑based image pipeline needs to rasterize OTG files to PNG with Aspose.Imaging in C# to maintain transparent layers for further image compositing.
 */
