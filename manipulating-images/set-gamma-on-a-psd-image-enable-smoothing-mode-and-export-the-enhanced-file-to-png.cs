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
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Load the PSD image
            using (Image image = Image.Load(inputPath))
            {
                // Adjust gamma on the raster image
                if (image is RasterImage raster)
                {
                    raster.AdjustGamma(2.2f); // Example gamma value
                }

                // Prepare PNG export options with smoothing mode enabled
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias
                    }
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
 * 1. When a web developer needs to convert a high‑resolution Photoshop PSD file to a web‑friendly PNG while correcting the image’s brightness with gamma adjustment and ensuring smooth edges via anti‑aliasing.
 * 2. When an e‑commerce platform must generate product thumbnails from PSD assets, applying a 2.2 gamma curve and smoothing mode to maintain visual consistency across browsers.
 * 3. When a digital publishing system automates the preparation of print‑ready PSD artwork for online preview, adjusting gamma for accurate color representation and using anti‑aliasing before saving as PNG.
 * 4. When a mobile app backend processes user‑uploaded PSD designs, normalizes their gamma levels, enables vector rasterization smoothing, and outputs optimized PNGs for faster download.
 * 5. When a batch‑processing tool needs to standardize a library of PSD graphics by applying gamma correction, activating smoothing mode, and exporting them as PNG files for archival or distribution.
 */