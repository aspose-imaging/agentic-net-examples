// HOW-TO: Apply Gamma Correction to Multiple PSD Files and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output directories
            string inputDir = @"C:\Images\Input\";
            string outputDir = @"C:\Images\Output\";

            // List of PSD files to process
            string[] files = new string[]
            {
                "image1.psd",
                "image2.psd",
                "image3.psd"
            };

            // Gamma coefficient to apply to all images
            float gamma = 2.0f;

            foreach (string fileName in files)
            {
                // Build full input path and verify existence
                string inputPath = Path.Combine(inputDir, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PNG path
                string outputFileName = Path.GetFileNameWithoutExtension(fileName) + ".png";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PSD image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access AdjustGamma
                    if (image is RasterImage rasterImage)
                    {
                        // Apply gamma correction
                        rasterImage.AdjustGamma(gamma);

                        // Save as PNG
                        rasterImage.Save(outputPath, new PngOptions());
                    }
                    else
                    {
                        Console.Error.WriteLine($"Unsupported image type for file: {inputPath}");
                        return;
                    }
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
 * 1. When you need to batch‑process a set of Photoshop PSD layers to brighten or darken them uniformly before publishing them as web‑ready PNGs.
 * 2. When an automated build pipeline must convert design assets from PSD to PNG while applying a specific gamma value to ensure consistent visual appearance across devices.
 * 3. When a digital‑printing workflow requires adjusting the gamma of multiple source PSD files to match print color profiles and then exporting them as lossless PNGs for proofing.
 * 4. When a content‑management system imports user‑uploaded PSD files and you must normalize their brightness via gamma correction before storing them as PNG thumbnails.
 * 5. When creating a photo‑editing tool that lets developers programmatically apply the same gamma correction to several PSD images and save the results in PNG format for further processing.
 */
