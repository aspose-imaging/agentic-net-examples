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
            // Hard‑coded input and output paths
            string bannerPath = "banner.jpg";
            string logoPath = "logo.png";
            string outputPath = "output\\result.jpg";

            // Validate input files
            if (!File.Exists(bannerPath))
            {
                Console.Error.WriteLine($"File not found: {bannerPath}");
                return;
            }
            if (!File.Exists(logoPath))
            {
                Console.Error.WriteLine($"File not found: {logoPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load images as raster images
            using (RasterImage banner = (RasterImage)Image.Load(bannerPath))
            using (RasterImage logo = (RasterImage)Image.Load(logoPath))
            {
                // Position logo at bottom‑right corner
                Point origin = new Point(banner.Width - logo.Width, banner.Height - logo.Height);

                // Blend logo onto banner with alpha = 192
                banner.Blend(origin, logo, 192);

                // Prepare JPEG save options
                Source src = new FileCreateSource(outputPath, false);
                JpegOptions jpegOptions = new JpegOptions { Source = src };

                // Save the composited image
                banner.Save(outputPath, jpegOptions);
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
 * 1. When creating marketing email banners that need a semi‑transparent PNG logo placed at the bottom‑right of a JPEG background, a developer can use this Aspose.Imaging C# code to blend the logo with an alpha value of 192 and save the result as a JPEG.
 * 2. When generating product catalog images on‑the‑fly, a web service can overlay a company watermark PNG onto each JPEG photo at the lower‑right corner with 75 % opacity using the Blend method shown.
 * 3. When automating the production of event flyers, a desktop application can combine a high‑resolution JPEG banner with a PNG sponsor logo at the bottom‑right, controlling the transparency via the alpha parameter (192) before exporting the final JPEG.
 * 4. When building a batch‑processing tool that adds a brand logo to thousands of existing JPEG advertisements, developers can employ this code to position the PNG logo at the corner, apply a consistent alpha blend, and write the composited images back to disk.
 * 5. When integrating dynamic graphics into a C# reporting engine, the code enables the insertion of a semi‑transparent PNG badge onto a JPEG chart image at the lower‑right edge, ensuring the overlay respects the desired opacity and JPEG output settings.
 */