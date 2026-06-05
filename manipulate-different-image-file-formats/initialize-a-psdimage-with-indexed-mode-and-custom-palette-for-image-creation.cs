using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path (hard‑coded)
            string outputPath = "Output/IndexedImage.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create custom palette (example with three colors)
            Color[] paletteColors = new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Blue
            };
            var customPalette = new ColorPalette(paletteColors);

            // Configure PSD creation options for indexed mode
            PsdOptions createOptions = new PsdOptions();
            createOptions.Source = new FileCreateSource(outputPath, false);
            createOptions.ColorMode = ColorModes.Indexed;                     // Indexed color mode
            createOptions.Palette = customPalette;                           // Assign custom palette
            createOptions.CompressionMethod = CompressionMethod.RLE;         // Use RLE compression
            createOptions.Version = 6;                                       // PSD version
            createOptions.ChannelBitsCount = (short)8;                       // 8 bits per channel
            createOptions.ChannelsCount = (short)1;                          // Single channel for indexed images

            // Define canvas size
            int width = 200;
            int height = 200;

            // Create the PSD image bound to the output file
            using (Image psdImage = Image.Create(createOptions, width, height))
            {
                // No additional drawing required; the image is ready
                // Save the image (bound to the FileCreateSource, so no path needed)
                psdImage.Save();
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
 * 1. When a developer needs to generate a lightweight Photoshop PSD file for web assets that uses an indexed color mode with a custom palette to reduce file size.
 * 2. When creating batch‑processed thumbnail previews of large image collections where each thumbnail must be saved as a PSD with a limited set of brand colors.
 * 3. When exporting game sprite sheets to PSD format while preserving a predefined palette for consistent color mapping across levels.
 * 4. When building an automated report generator that embeds charts as indexed‑color PSD images to ensure compatibility with older Photoshop versions.
 * 5. When developing a digital asset pipeline that converts vector graphics into PSD files with a custom palette for print‑ready color separation.
 */