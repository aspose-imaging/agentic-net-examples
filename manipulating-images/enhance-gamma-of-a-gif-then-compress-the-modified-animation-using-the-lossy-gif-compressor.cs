using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.gif";
            string outputPath = "output.lossy.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF-specific methods
                GifImage gifImage = (GifImage)image;

                // Enhance gamma (example value 2.5f)
                gifImage.AdjustGamma(2.5f);

                // Prepare GIF save options for lossy compression
                GifOptions saveOptions = new GifOptions
                {
                    // Set maximum allowed pixel difference to enable lossy compression
                    MaxDiff = 80
                };

                // Save the modified GIF with lossy compression
                gifImage.Save(outputPath, saveOptions);
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
 * 1. When a web developer needs to brighten a legacy animated GIF and reduce its file size for faster page loads, they can adjust the gamma and apply lossy compression using Aspose.Imaging in C#.
 * 2. When an e‑commerce platform wants to optimize product animation thumbnails by enhancing contrast (via gamma) and shrinking bandwidth consumption, this code provides a C# solution for GIF processing.
 * 3. When a mobile app developer must prepare animated GIF stickers with consistent brightness and meet strict size limits for app stores, they can use the example to adjust gamma and set MaxDiff for lossy compression.
 * 4. When a digital marketing team automates the creation of promotional GIFs that need to appear vibrant on social media while staying under upload size caps, they can run this C# routine to boost gamma and compress the animation.
 * 5. When a game developer integrates user‑generated GIF avatars and wants to ensure they render correctly and load quickly, the code demonstrates how to enhance gamma and apply lossy GIF compression in .NET.
 */