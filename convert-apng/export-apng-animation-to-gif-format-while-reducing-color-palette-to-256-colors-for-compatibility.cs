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
            // Hardcoded input and output paths
            string inputPath = "input.apng";
            string outputPath = "output/output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the APNG animation
            using (Image apngImage = Image.Load(inputPath))
            {
                // Configure GIF options to reduce palette to 256 colors
                GifOptions gifOptions = new GifOptions
                {
                    DoPaletteCorrection = true,   // Analyze source colors and build optimal palette
                    ColorResolution = 7           // 2^ (7+1) = 256 colors
                };

                // Save as GIF with the specified options
                apngImage.Save(outputPath, gifOptions);
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
 * 1. When a web developer needs to convert animated PNG (APNG) assets to GIF for older browsers that only support GIF, while ensuring the animation stays within the 256‑color limit.
 * 2. When a mobile app team wants to generate lightweight GIF previews from high‑color APNG stickers to reduce bandwidth and storage on devices.
 * 3. When an e‑learning platform must batch‑process course illustrations stored as APNG and export them as GIFs compatible with legacy LMS viewers that cannot handle true‑color palettes.
 * 4. When a marketing automation script creates animated email banners from APNG files and must down‑sample the colors to 256 to meet email client GIF restrictions.
 * 5. When a game developer needs to embed animated UI icons originally authored as APNG into a Unity project that only accepts GIF textures, requiring palette correction to avoid color distortion.
 */