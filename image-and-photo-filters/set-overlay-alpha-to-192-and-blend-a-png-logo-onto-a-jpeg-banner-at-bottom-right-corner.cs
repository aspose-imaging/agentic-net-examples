using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string bannerPath = "banner.jpg";
            string logoPath = "logo.png";
            string outputPath = "Output\\output.jpg";

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
                Point origin = new Point(x, y);

                // Blend logo onto banner with alpha = 192
                banner.Blend(origin, logo, 192);

                // Save the result
                banner.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}