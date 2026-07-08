using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.psd";
            string outputPath = "Output/adjusted.png";

            // Verify input file exists
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
                // Cast to RasterImage for pixel operations
                RasterImage raster = (RasterImage)image;

                // Cache image data if not already cached
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                // Lower contrast by 20% (negative value reduces contrast)
                raster.AdjustContrast(-20f);

                // Prepare PNG save options
                using (PngOptions pngOptions = new PngOptions())
                {
                    // Save the adjusted image as PNG
                    raster.Save(outputPath, pngOptions);
                }
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
 * 1. When a developer needs to lower the contrast of a Photoshop PSD file by twenty percent and export it as a PNG for faster web preview or thumbnail generation.
 * 2. When an e‑commerce platform must convert high‑contrast product mockups in PSD format to softer PNG images to match the site’s visual style guidelines.
 * 3. When a mobile app requires PSD assets to be pre‑processed with reduced contrast before saving them as PNGs to improve readability on low‑light screens.
 * 4. When a printing workflow needs to adjust the contrast of PSD artwork to prevent overly dark prints and then save the result as a PNG for proofing.
 * 5. When a batch script processes multiple PSD files, applies a 20 % contrast reduction, and outputs PNG files for use in accessibility‑friendly UI components.
 */