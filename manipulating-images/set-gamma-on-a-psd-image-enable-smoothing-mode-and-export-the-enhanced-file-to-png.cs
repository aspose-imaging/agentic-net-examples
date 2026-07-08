using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.AdjustGamma(2.2f);

                Graphics graphics = new Graphics(image);
                graphics.SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias;

                PngOptions pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert a high‑resolution Photoshop PSD file to a web‑ready PNG while correcting the image’s brightness using gamma adjustment and ensuring smooth edges with anti‑aliasing.
 * 2. When an e‑commerce platform must generate product thumbnails from PSD assets, applying a 2.2 gamma curve and smoothing mode to maintain visual consistency across browsers.
 * 3. When a digital publishing workflow requires batch processing of PSD illustrations to PNG with standardized gamma for print‑to‑screen color matching and anti‑aliased rendering for crisp text.
 * 4. When a mobile app prepares user‑uploaded PSD designs for display on high‑DPI screens, adjusting gamma for proper contrast and enabling smoothing to reduce jagged lines before saving as PNG.
 * 5. When a graphic‑design automation script needs to ensure that exported PNGs from PSD files have consistent gamma correction and anti‑aliasing to meet brand guidelines for marketing materials.
 */