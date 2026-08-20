// HOW-TO: Blend PNG Logo onto JPEG Banner with Custom Alpha in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string bannerPath = "banner.jpg";
            string logoPath = "logo.png";
            string outputPath = "output.jpg";

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

            // Load images
            using (RasterImage banner = (RasterImage)Image.Load(bannerPath))
            using (RasterImage logo = (RasterImage)Image.Load(logoPath))
            {
                // Calculate bottom‑right position
                int x = banner.Width - logo.Width;
                int y = banner.Height - logo.Height;
                if (x < 0) x = 0;
                if (y < 0) y = 0;
                Point origin = new Point(x, y);

                // Blend logo onto banner with alpha 192
                banner.Blend(origin, logo, 192);

                // Save result as JPEG
                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    Quality = 90
                };
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
 * 1. When you need to add a semi‑transparent PNG watermark to a promotional JPEG banner for online advertising.
 * 2. When generating product catalog images that require a company logo placed at the bottom‑right corner with consistent opacity.
 * 3. When creating personalized email header images by blending a user‑provided PNG badge onto a JPEG background.
 * 4. When automating the preparation of social‑media graphics that combine a logo overlay with a fixed transparency level.
 * 5. When building a batch process that stamps a PNG logo onto multiple JPEG flyers while preserving JPEG quality.
 */
