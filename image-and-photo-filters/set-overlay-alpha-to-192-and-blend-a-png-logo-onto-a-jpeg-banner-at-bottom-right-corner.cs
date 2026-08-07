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
                // Calculate bottom‑right corner position
                Point origin = new Point(banner.Width - logo.Width, banner.Height - logo.Height);

                // Blend logo onto banner with alpha 192
                banner.Blend(origin, logo, 192);

                // Save the result as JPEG
                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    Quality = 100
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
 * 1. When a marketing web app must add a semi‑transparent PNG logo to the bottom‑right corner of a JPEG banner before sending the image to an email campaign.
 * 2. When an e‑commerce platform needs to watermark product photos by blending a company logo with 75 % opacity onto large JPEG images for brand consistency.
 * 3. When a desktop publishing tool automatically generates promotional flyers by overlaying a PNG sponsor badge onto a JPEG background at the lower‑right edge.
 * 4. When a mobile game server prepares shareable screenshots by compositing a PNG achievement icon onto a JPEG game scene with an alpha value of 192.
 * 5. When a digital signage system updates billboard graphics by programmatically merging a PNG logo onto a JPEG advertisement image at the bottom‑right corner using C# and Aspose.Imaging.
 */