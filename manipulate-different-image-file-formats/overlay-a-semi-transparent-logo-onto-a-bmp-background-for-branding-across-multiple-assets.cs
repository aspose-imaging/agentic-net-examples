using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Paths (hard‑coded)
            string logoPath = "logo.png";
            string[] backgroundPaths = { "bg1.bmp", "bg2.bmp", "bg3.bmp" };
            string outputDirectory = "output";

            // Validate logo file
            if (!File.Exists(logoPath))
            {
                Console.Error.WriteLine($"File not found: {logoPath}");
                return;
            }

            // Load the semi‑transparent logo once
            using (RasterImage logo = (RasterImage)Image.Load(logoPath))
            {
                // Process each background image
                foreach (string bgPath in backgroundPaths)
                {
                    // Validate background file
                    if (!File.Exists(bgPath))
                    {
                        Console.Error.WriteLine($"File not found: {bgPath}");
                        return;
                    }

                    // Prepare output path
                    string outputPath = Path.Combine(outputDirectory,
                        Path.GetFileNameWithoutExtension(bgPath) + "_branded.bmp");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load background BMP
                    using (RasterImage background = (RasterImage)Image.Load(bgPath))
                    {
                        // Overlay logo at (0,0) with 50% opacity (128 out of 255)
                        background.Blend(new Point(0, 0), logo, 128);

                        // Save the result as BMP
                        BmpOptions bmpOptions = new BmpOptions
                        {
                            Source = new FileCreateSource(outputPath, false)
                        };
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
 * 1. When a marketing team wants to automatically brand a batch of BMP product images with a semi‑transparent PNG logo using C# and Aspose.Imaging.
 * 2. When a software vendor needs to embed a watermark logo onto legacy BMP screenshots before distributing them to customers.
 * 3. When an e‑commerce platform must add a corporate logo to multiple background images during a nightly build pipeline with .NET image processing.
 * 4. When a game developer wants to overlay a transparent logo onto BMP textures for in‑game branding without altering the original files.
 * 5. When a document management system requires batch processing of scanned BMP pages to include a semi‑transparent logo for compliance purposes.
 */