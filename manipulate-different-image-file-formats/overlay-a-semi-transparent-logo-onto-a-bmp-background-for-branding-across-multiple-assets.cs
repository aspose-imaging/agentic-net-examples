using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input files
            string logoPath = "logo.png";
            string[] backgroundPaths = { "background1.bmp", "background2.bmp" };

            // Verify logo exists
            if (!File.Exists(logoPath))
            {
                Console.Error.WriteLine($"File not found: {logoPath}");
                return;
            }

            foreach (string bgPath in backgroundPaths)
            {
                // Verify background exists
                if (!File.Exists(bgPath))
                {
                    Console.Error.WriteLine($"File not found: {bgPath}");
                    return;
                }

                // Prepare output path
                string outputPath = Path.Combine("output", Path.GetFileNameWithoutExtension(bgPath) + "_branded.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load background and logo images
                using (RasterImage background = (RasterImage)Image.Load(bgPath))
                using (RasterImage logo = (RasterImage)Image.Load(logoPath))
                {
                    // Create output canvas bound to file
                    Source source = new FileCreateSource(outputPath, false);
                    BmpOptions bmpOptions = new BmpOptions() { Source = source };
                    using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, background.Width, background.Height))
                    {
                        // Draw background
                        canvas.SaveArgb32Pixels(new Rectangle(0, 0, background.Width, background.Height),
                            background.LoadArgb32Pixels(background.Bounds));

                        // Draw logo at top-left corner
                        canvas.SaveArgb32Pixels(new Rectangle(0, 0, logo.Width, logo.Height),
                            logo.LoadArgb32Pixels(logo.Bounds));

                        // Save the composed image
                        canvas.Save();
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
 * 1. When a developer needs to brand a collection of BMP assets with a semi‑transparent PNG logo for consistent corporate identity across marketing materials.
 * 2. When an application must automatically add a watermark logo to scanned BMP documents before archiving them in a document management system.
 * 3. When a game engine requires overlaying a transparent PNG badge onto BMP texture atlases during the build pipeline to indicate version or copyright information.
 * 4. When a batch‑processing tool has to place a company logo on the top‑left corner of multiple BMP product images before uploading them to an e‑commerce platform.
 * 5. When a reporting service generates BMP charts and needs to embed a semi‑transparent logo onto each chart image for compliance with branding guidelines.
 */