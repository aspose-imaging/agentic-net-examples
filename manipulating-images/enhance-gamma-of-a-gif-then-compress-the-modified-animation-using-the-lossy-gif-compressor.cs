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
            string outputPath = "output\\modified_lossy.gif";

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

                // Enhance gamma (example value 2.0f)
                gifImage.AdjustGamma(2.0f);

                // Prepare GIF save options for lossy compression
                GifOptions saveOptions = new GifOptions
                {
                    // Enable palette correction for better quality
                    DoPaletteCorrection = true,
                    // Set maximum allowed pixel difference to trigger lossy compression
                    MaxDiff = 80
                };

                // Save the modified GIF with lossy compression
                gifImage.Save(outputPath, saveOptions);
            }

            Console.WriteLine("Gamma enhancement and lossy compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to brighten an animated GIF for a web banner and shrink its download size, they can use this C# code to adjust the gamma and apply Aspose.Imaging’s lossy GIF compression.
 * 2. When a mobile app must display a high‑contrast GIF animation while staying under a strict bandwidth limit, the code can enhance the gamma and reduce the file size with palette correction and MaxDiff settings.
 * 3. When an e‑learning platform wants to improve the visual clarity of instructional GIFs and store them efficiently on a CDN, this snippet shows how to modify gamma and save the result using GifOptions for lossy compression.
 * 4. When a social‑media scheduler needs to preprocess user‑uploaded GIFs to make colors pop and ensure fast loading, the example demonstrates adjusting gamma and compressing the animation in C# with Aspose.Imaging.
 * 5. When a game developer is preparing animated GIF assets for in‑game UI and must balance brightness with minimal storage, the code provides a practical way to enhance gamma and apply lossy compression before deployment.
 */