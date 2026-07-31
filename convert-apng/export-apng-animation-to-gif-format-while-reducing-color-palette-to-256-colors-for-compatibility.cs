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
            string outputPath = "output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the APNG animation
            using (Image apngImage = Image.Load(inputPath))
            {
                // Configure GIF options for 256‑color palette
                GifOptions gifOptions = new GifOptions
                {
                    // 8 bits per color channel (7 + 1) = 256 colors
                    ColorResolution = 7,
                    // Build the best matching palette from source colors
                    DoPaletteCorrection = true,
                    // Optional: ensure full frames for compatibility
                    FullFrame = true
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
 * 1. When a developer needs to convert an animated PNG (APNG) into a legacy‑compatible GIF for email newsletters while limiting the palette to 256 colors.
 * 2. When a C# application must transform user‑uploaded APNG files into GIF animations for mobile apps that only support the GIF format and require reduced color depth.
 * 3. When a batch‑processing tool has to export APNG assets to GIF with a 256‑color palette to satisfy social media size limits that reject PNG animations.
 * 4. When an image‑processing pipeline must preserve the frame timing of an APNG while saving it as a GIF for PDF reports that only accept GIF images.
 * 5. When a developer wants to ensure an APNG animation can be displayed on older Windows systems by converting it to a GIF with full‑frame rendering and palette correction.
 */