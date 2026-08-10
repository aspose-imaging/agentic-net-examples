// HOW-TO: Adjust Gamma of GIF and Apply Lossy Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Wrap the whole logic to catch unexpected exceptions
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.gif";
            string outputPath = "output_gamma.gif";
            string outputLossyPath = "output_gamma_lossy.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputLossyPath));

            // Load the GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF-specific methods
                GifImage gifImage = (GifImage)image;

                // Apply gamma correction (example gamma value 2.2f)
                gifImage.AdjustGamma(2.2f);

                // Save the gamma‑corrected GIF (lossless)
                gifImage.Save(outputPath, new GifOptions());

                // Prepare options for lossy compression
                GifOptions lossyOptions = new GifOptions
                {
                    // Enable palette correction for better quality
                    DoPaletteCorrection = true,
                    // Set maximum pixel difference to trigger lossy compression
                    MaxDiff = 80
                };

                // Save the lossy compressed GIF
                gifImage.Save(outputLossyPath, lossyOptions);
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
 * 1. When a developer needs to improve the brightness and contrast of an animated GIF for better visual appearance on different displays, they can use gamma correction before saving it.
 * 2. When a web application must reduce the file size of a GIF animation while preserving acceptable visual quality, the lossy compression options can be applied after gamma adjustment.
 * 3. When an e‑commerce platform wants to standardize product animation colors and also meet bandwidth limits, they can adjust the GIF’s gamma and then compress it with palette correction.
 * 4. When a mobile app processes user‑uploaded GIFs and needs to ensure the images load quickly on cellular networks, it can apply gamma correction and lossy compression in a single workflow.
 * 5. When a digital marketing tool prepares animated banners for email campaigns, it can enhance the GIF’s gamma for brand consistency and then shrink the file using Aspose.Imaging’s lossy GIF compressor.
 */
