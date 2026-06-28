using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input images of different resolutions
            string[] inputPaths = {
                "image_640x480.png",
                "image_1280x720.png",
                "image_1920x1080.png"
            };

            foreach (var inputPath in inputPaths)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output path and ensure directory exists
                string outputPath = Path.Combine("Output", Path.GetFileNameWithoutExtension(inputPath) + "_masked.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Measure mask generation time
                var startTime = DateTime.Now;

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Simple mask: select around the image center and apply
                    MagicWandTool
                        .Select(image, new MagicWandSettings(image.Width / 2, image.Height / 2))
                        .Apply();

                    // Save the masked image
                    image.Save(outputPath);
                }

                var elapsed = DateTime.Now - startTime;
                Console.WriteLine($"Processed {inputPath} in {elapsed.TotalMilliseconds} ms, saved to {outputPath}");
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
 * 1. When a developer needs to compare the performance of Aspose.Imaging’s MagicWandTool on low‑resolution PNG thumbnails versus high‑definition JPEGs for a photo‑editing web service.
 * 2. When a QA engineer wants to benchmark mask generation time across 640×480, 1280×720, and 1920×1080 images to set acceptable latency thresholds in a C# desktop application.
 * 3. When an optimization team is evaluating the impact of different image formats (PNG, BMP, TIFF) on the speed of applying a center‑based mask using the MagicWandTool.
 * 4. When a CI pipeline must automatically verify that recent library updates do not degrade the runtime of mask creation on images of varying resolutions.
 * 5. When a product manager needs concrete millisecond measurements to justify hardware requirements for a batch‑processing server that applies masks to user‑uploaded images in .NET.
 */