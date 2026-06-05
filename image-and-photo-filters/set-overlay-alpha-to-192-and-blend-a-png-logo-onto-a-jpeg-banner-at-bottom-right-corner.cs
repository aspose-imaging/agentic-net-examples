using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
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

            // Load images as raster images
            using (RasterImage banner = (RasterImage)Image.Load(bannerPath))
            using (RasterImage logo = (RasterImage)Image.Load(logoPath))
            {
                // Calculate bottom‑right corner position
                int x = banner.Width - logo.Width;
                int y = banner.Height - logo.Height;
                if (x < 0) x = 0;
                if (y < 0) y = 0;
                Point origin = new Point(x, y);

                // Blend logo onto banner with alpha = 192
                banner.Blend(origin, logo, 192);

                // Save the result as JPEG
                Source src = new FileCreateSource(outputPath, false);
                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = src,
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