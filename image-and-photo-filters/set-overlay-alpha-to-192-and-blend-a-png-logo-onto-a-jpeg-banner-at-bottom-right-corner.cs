using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string bannerPath = "banner.jpg";
        string logoPath = "logo.png";
        string outputPath = "output.jpg";

        // Verify input files exist
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

        // Load the background JPEG banner
        using (RasterImage banner = (RasterImage)Image.Load(bannerPath))
        {
            // Load the PNG logo
            using (RasterImage logo = (RasterImage)Image.Load(logoPath))
            {
                // Calculate bottom‑right position for the overlay
                Point origin = new Point(banner.Width - logo.Width, banner.Height - logo.Height);

                // Blend the logo onto the banner with alpha = 192
                banner.Blend(origin, logo, 192);
            }

            // Prepare JPEG save options with bound source
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = 90 // optional quality setting
            };

            // Save the blended image
            banner.Save(outputPath, jpegOptions);
        }
    }
}