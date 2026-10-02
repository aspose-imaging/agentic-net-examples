// HOW-TO: Overlay Semi Transparent PNG Logo onto Multiple BMP Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input paths
            string logoPath = "logo.png";
            if (!File.Exists(logoPath))
            {
                Console.Error.WriteLine($"File not found: {logoPath}");
                return;
            }

            List<string> backgroundPaths = new List<string>
            {
                "background1.bmp",
                "background2.bmp",
                "background3.bmp"
            };

            foreach (string bgPath in backgroundPaths)
            {
                if (!File.Exists(bgPath))
                {
                    Console.Error.WriteLine($"File not found: {bgPath}");
                    return;
                }
            }

            // Output directory
            string outputDir = "output";

            // Load logo once
            using (RasterImage logoImage = (RasterImage)Image.Load(logoPath))
            {
                foreach (string bgPath in backgroundPaths)
                {
                    using (RasterImage background = (RasterImage)Image.Load(bgPath))
                    {
                        // Position logo at top-left corner
                        Point position = new Point(0, 0);

                        // Blend logo onto background with semi-transparency (opacity 127)
                        background.Blend(position, logoImage, 127);

                        // Prepare output path
                        string fileName = Path.GetFileNameWithoutExtension(bgPath);
                        string outputPath = Path.Combine(outputDir, fileName + "_with_logo.bmp");

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save as BMP
                        Source outSource = new FileCreateSource(outputPath, false);
                        BmpOptions bmpOptions = new BmpOptions() { Source = outSource };
                        background.Save(outputPath, bmpOptions);
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
 * 1. When you need to brand a series of product photos stored as BMP files by adding a semi‑transparent PNG logo to each image automatically.
 * 2. When you want to generate watermarked BMP assets for a Windows desktop application without altering the original files.
 * 3. When a marketing pipeline requires batch overlay of a corporate logo onto high‑resolution BMP scans before publishing.
 * 4. When you must create consistent branding across multiple BMP textures used in a game engine by blending a logo with 50% opacity.
 * 5. When an automated build process has to add a transparent logo to BMP screenshots for compliance reporting.
 */
