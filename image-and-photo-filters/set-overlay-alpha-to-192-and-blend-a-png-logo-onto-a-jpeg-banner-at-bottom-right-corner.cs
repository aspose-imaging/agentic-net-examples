// HOW-TO: Overlay PNG Logo with Alpha 192 onto JPEG Banner in C# (Aspose.Imaging for .NET)
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
            string bannerPath = "banner.jpg";
            string logoPath = "logo.png";
            string outputPath = "output.jpg";

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

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (RasterImage banner = (RasterImage)Image.Load(bannerPath))
            using (RasterImage logo = (RasterImage)Image.Load(logoPath))
            {
                // Adjust logo alpha to 192
                Rectangle logoBounds = logo.Bounds;
                int[] logoPixels = logo.LoadArgb32Pixels(logoBounds);
                for (int i = 0; i < logoPixels.Length; i++)
                {
                    int pixel = logoPixels[i];
                    pixel = (pixel & 0x00FFFFFF) | (192 << 24);
                    logoPixels[i] = pixel;
                }
                logo.SaveArgb32Pixels(logoBounds, logoPixels);

                // Position logo at bottom-right corner
                int posX = banner.Width - logo.Width;
                int posY = banner.Height - logo.Height;
                if (posX < 0) posX = 0;
                if (posY < 0) posY = 0;

                Rectangle destRect = new Rectangle(posX, posY, logo.Width, logo.Height);
                banner.SaveArgb32Pixels(destRect, logoPixels);

                // Save the merged image as JPEG
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    Source = new FileCreateSource(outputPath, false)
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
 * 1. When you need to add a semi‑transparent company logo to the corner of a promotional JPEG banner for web advertising.
 * 2. When you want to programmatically watermark product images with a PNG logo that retains partial transparency.
 * 3. When generating dynamic email newsletters that require a logo blended onto a background image without fully obscuring it.
 * 4. When creating batch‑processed marketing assets where each JPEG banner must display a PNG badge at the bottom‑right with consistent opacity.
 * 5. When building a C# application that composites a transparent PNG overlay onto a JPEG photo for social‑media sharing.
 */
