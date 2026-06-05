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
            // Output path for the indexed PSD file
            string outputPath = "output/output.psd";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PSD options for an indexed color image
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.CompressionMethod = CompressionMethod.RLE;
            psdOptions.ChannelsCount = (short)1;          // Indexed images have one channel
            psdOptions.ChannelBitsCount = (short)8;      // 8 bits per channel
            psdOptions.Palette = ColorPaletteHelper.Create8BitGrayscale(false); // 256‑color palette
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.Version = 6; // Default PSD version

            int width = 200;
            int height = 200;

            // Create the PSD image bound to the output file
            using (Image image = Image.Create(psdOptions, width, height))
            {
                // Fill the image with a solid color using Graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.LightGray);

                // Save the bound image
                image.Save();
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
 * 1. When a developer needs to generate a lightweight PSD file with a limited 256‑color grayscale palette for web preview or thumbnail generation.
 * 2. When converting high‑resolution images to an indexed color PSD to reduce file size while preserving compatibility with Photoshop version 6.
 * 3. When creating programmatic PSD assets for a design pipeline that require a single 8‑bit channel and RLE compression for faster loading.
 * 4. When building a C# application that must export graphics as indexed PSD files for legacy systems that only support 256 colors.
 * 5. When automating the production of PSD mock‑ups with a fixed grayscale palette to ensure consistent color mapping across multiple documents.
 */