using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directory
        string inputDir = @"C:\Images\Input\";
        string outputDir = @"C:\Images\Output\";

        // List of PSD files to process
        string[] psdFiles = new string[]
        {
            "sample1.psd",
            "sample2.psd",
            "sample3.psd"
        };

        // Gamma value to apply (same for all channels)
        float gamma = 2.2f;

        try
        {
            foreach (string fileName in psdFiles)
            {
                // Build full input and output paths
                string inputPath = Path.Combine(inputDir, fileName);
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(fileName) + ".png");

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PSD image, apply gamma correction, and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access AdjustGamma
                    var rasterImage = (RasterImage)image;
                    rasterImage.AdjustGamma(gamma);
                    rasterImage.Save(outputPath, new PngOptions());
                }

                Console.WriteLine($"Processed: {inputPath} -> {outputPath}");
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
 * 1. When a graphic designer needs to batch‑convert layered Photoshop PSD files to web‑ready PNGs with consistent gamma correction for accurate color display across browsers.
 * 2. When an e‑commerce platform must preprocess product mockups stored as PSDs, applying a uniform gamma curve before publishing the images as PNG thumbnails.
 * 3. When a digital archivist wants to preserve legacy PSD artwork by adjusting its gamma to a standard 2.2 value and saving the result in a lossless PNG format for long‑term storage.
 * 4. When a marketing automation script has to generate print‑ready PNG assets from multiple PSD source files while ensuring the same gamma setting for consistent visual tone.
 * 5. When a photo‑editing application offers a batch‑export feature that reads PSD files, applies gamma correction using Aspose.Imaging in C#, and writes the output as PNG files for quick sharing.
 */