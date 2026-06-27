using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"C:\Temp\indexed_output.psd";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a custom palette (red, green, blue)
            Aspose.Imaging.Color[] paletteColors = new Aspose.Imaging.Color[]
            {
                Aspose.Imaging.Color.Red,
                Aspose.Imaging.Color.Green,
                Aspose.Imaging.Color.Blue
            };
            IColorPalette customPalette = new Aspose.Imaging.ColorPalette(paletteColors);

            // Configure PSD options for indexed mode
            PsdOptions psdOptions = new PsdOptions
            {
                // Destination file
                Source = new FileCreateSource(outputPath, false),

                // 8 bits per pixel (256 possible indices)
                ChannelBitsCount = 8,
                ChannelsCount = 1,

                // Assign the custom palette
                Palette = customPalette,

                // Indexed color mode (fallback to Bitmap if not supported)
                ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Indexed,

                // No compression
                CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.Raw,

                // PSD version 6 (default)
                Version = 6
            };

            // Create a 100 × 100 indexed PSD image
            using (Image image = Image.Create(psdOptions, 100, 100))
            {
                // The image is initially filled with the first palette entry (red)
                // Save writes the image to the path defined in Source
                image.Save();
            }

            Console.WriteLine($"Indexed PSD image created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a PSD file with a limited color set for a web‑based design tool, they can use this code to create a 100 × 100 indexed‑mode image with a custom red‑green‑blue palette.
 * 2. When exporting thumbnail previews from a graphics pipeline that must be compatible with Photoshop’s older version 6 PSD format, this snippet creates an indexed PSD with no compression for fast loading.
 * 3. When building a batch process that programmatically produces color‑indexed Photoshop layers for printing proofs, the code demonstrates how to set ChannelBitsCount, ChannelsCount, and a custom palette in C#.
 * 4. When integrating Aspose.Imaging into a C# application that needs to store image data in a small‑size PSD file for archival, the example shows how to use FileCreateSource and raw compression to keep the file lightweight.
 * 5. When testing image‑processing algorithms that rely on palette‑based color mapping, developers can use this example to create a controlled PSD image where each pixel initially uses the first palette entry (red).
 */