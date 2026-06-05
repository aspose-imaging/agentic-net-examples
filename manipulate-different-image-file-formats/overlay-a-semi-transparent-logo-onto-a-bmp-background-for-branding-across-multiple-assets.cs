using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string backgroundPath = "background.bmp";
            string logoPath = "logo.png";
            string outputPath = "output.bmp";

            if (!File.Exists(backgroundPath))
            {
                Console.Error.WriteLine($"File not found: {backgroundPath}");
                return;
            }
            if (!File.Exists(logoPath))
            {
                Console.Error.WriteLine($"File not found: {logoPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            FileCreateSource outputSource = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = outputSource };

            using (Aspose.Imaging.RasterImage background = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(backgroundPath))
            using (Aspose.Imaging.RasterImage logo = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(logoPath))
            {
                int offsetX = (background.Width - logo.Width) / 2;
                int offsetY = (background.Height - logo.Height) / 2;
                background.Blend(new Aspose.Imaging.Point(offsetX, offsetY), logo, 128);
                background.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to brand a collection of BMP product images with a semi‑transparent PNG logo using Aspose.Imaging’s Blend method in C# before publishing them to an e‑commerce site.
 * 2. When an automation script must add a watermark logo to scanned BMP documents for compliance tracking, blending a PNG logo with 50 % opacity while preserving the original image dimensions.
 * 3. When a desktop application generates custom BMP badges and overlays a translucent company logo at the center using the Blend function of Aspose.Imaging in C#.
 * 4. When a batch‑processing tool prepares BMP assets for a video game and applies a semi‑transparent logo overlay with the Blend method to ensure consistent branding across all textures.
 * 5. When a reporting service creates BMP charts and needs to embed a faint logo overlay by blending a PNG image at 128 alpha value to identify the source of the data in the final image file.
 */