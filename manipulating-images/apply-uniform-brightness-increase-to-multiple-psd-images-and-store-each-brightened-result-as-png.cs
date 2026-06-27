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
            // Hardcoded input PSD files
            string[] inputPaths = new string[]
            {
                @"C:\Images\Input1.psd",
                @"C:\Images\Input2.psd",
                @"C:\Images\Input3.psd"
            };

            // Corresponding output PNG files
            string[] outputPaths = new string[]
            {
                @"C:\Images\Output\Brightened1.png",
                @"C:\Images\Output\Brightened2.png",
                @"C:\Images\Output\Brightened3.png"
            };

            // Process each file
            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

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
                    // Cast to RasterImage to adjust brightness
                    RasterImage raster = image as RasterImage;
                    if (raster != null)
                    {
                        // Increase brightness uniformly (e.g., +50)
                        raster.AdjustBrightness(50);

                        // Save the brightened image as PNG
                        PngOptions pngOptions = new PngOptions();
                        raster.Save(outputPath, pngOptions);
                    }
                    else
                    {
                        Console.Error.WriteLine($"Unable to process image (not a raster image): {inputPath}");
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
 * 1. When a designer needs to batch‑process Photoshop PSD files to make them uniformly brighter before publishing them as web‑ready PNGs.
 * 2. When an e‑commerce platform wants to automatically enhance product mock‑ups stored as PSDs and store the brighter versions as PNG thumbnails for faster page loads.
 * 3. When a marketing automation script must convert a set of layered PSD assets into brightened PNGs for use in email campaigns that require consistent lighting.
 * 4. When a digital asset management system needs to apply a fixed brightness offset to multiple PSD files and save the results as PNGs for preview generation.
 * 5. When a game development pipeline requires preprocessing of PSD texture maps by increasing their brightness and exporting them as PNGs for runtime use.
 */