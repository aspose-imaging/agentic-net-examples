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
            string[] inputPaths = {
                @"C:\Images\image1.psd",
                @"C:\Images\image2.psd"
            };

            // Corresponding output PNG files
            string[] outputPaths = {
                @"C:\Output\image1.png",
                @"C:\Output\image2.png"
            };

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
                    // Adjust brightness if the image supports raster operations
                    if (image is RasterImage rasterImage)
                    {
                        // Increase brightness uniformly (value range -255 to 255)
                        rasterImage.AdjustBrightness(50);
                    }

                    // Save the result as PNG
                    image.Save(outputPath, new PngOptions());
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
 * 1. When a marketing team needs to quickly brighten a batch of Photoshop (PSD) assets before publishing them as web‑ready PNGs, a developer can use this C# code to automate the process.
 * 2. When an e‑learning platform receives client‑provided PSD slides that are too dark and must be converted to PNG thumbnails with consistent brightness, the code provides a simple solution.
 * 3. When a digital asset management system must reprocess legacy PSD files to improve visibility and store the results as PNG for faster preview loading, this routine can be integrated into the C# pipeline.
 * 4. When a photo‑editing SaaS wants to apply a uniform brightness boost to multiple user‑uploaded PSD files and deliver the edited images as PNGs without manual Photoshop intervention, the example shows how to achieve it.
 * 5. When a game development studio needs to prepare brightened texture maps from PSD source files and export them as PNGs for the engine, the code automates the raster image adjustment and format conversion.
 */