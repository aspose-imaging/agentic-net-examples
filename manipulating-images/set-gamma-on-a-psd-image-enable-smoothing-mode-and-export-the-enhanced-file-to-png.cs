using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.psd";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for adjustments
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                // Apply gamma correction
                raster.AdjustGamma(2.2f);

                // Enable smoothing mode via Graphics
                Graphics graphics = new Graphics(image);
                graphics.SmoothingMode = SmoothingMode.HighQuality;

                // Prepare PNG export options
                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Save the enhanced image as PNG
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
 * 1. When a developer needs to correct the brightness of a Photoshop PSD file by applying a 2.2 gamma curve, smooth the rendering, and deliver the result as a high‑quality PNG for web publishing.
 * 2. When an e‑commerce platform must convert product mockups stored as layered PSDs into optimized PNG thumbnails while ensuring consistent gamma and anti‑aliasing for a polished appearance.
 * 3. When a digital asset management system automates the preparation of PSD artwork for mobile apps, applying gamma correction and high‑quality smoothing before saving the assets as PNGs.
 * 4. When a print‑to‑screen workflow requires adjusting the gamma of source PSD files, enabling high‑quality smoothing to reduce jagged edges, and exporting the final images as PNGs for on‑screen proofing.
 * 5. When a content management system batch‑processes designer‑provided PSD files, standardizes their gamma, applies smoothing for smoother graphics, and stores the output as PNG files for fast loading on websites.
 */