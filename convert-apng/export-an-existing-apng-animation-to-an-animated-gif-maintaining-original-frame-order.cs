using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\animation.apng";
        string outputPath = @"C:\Images\animation_converted.gif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the APNG image
            using (Image image = Image.Load(inputPath))
            {
                // Save as animated GIF, preserving frame order
                var gifOptions = new GifOptions
                {
                    // FullFrame ensures each frame is saved as a full image (optional)
                    FullFrame = true
                };
                image.Save(outputPath, gifOptions);
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
 * 1. When a web developer needs to convert user‑uploaded APNG stickers into animated GIFs for browsers that only support GIF animation, they can use this C# Aspose.Imaging code to preserve the original frame order.
 * 2. When a mobile app backend must generate shareable GIF previews from APNG game assets while keeping the animation sequence intact, the example shows how to load the APNG and save it as a GIF using Aspose.Imaging.
 * 3. When an e‑learning platform wants to transform APNG tutorial animations into GIFs for email newsletters, the code demonstrates the C# file‑system checks and GifOptions needed to maintain frame timing.
 * 4. When a digital marketing team automates batch processing of APNG product demos into GIFs for social media, this snippet provides the necessary steps to load, verify, and export each animation with correct frame ordering.
 * 5. When a legacy content management system only accepts GIF files, developers can employ this Aspose.Imaging for .NET routine to convert APNG banners to animated GIFs without losing the original frame sequence.
 */