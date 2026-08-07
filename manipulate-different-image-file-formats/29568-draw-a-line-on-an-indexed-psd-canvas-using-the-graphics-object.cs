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
            // Output PSD file path (hardcoded)
            string outputPath = @"C:\temp\output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Canvas size
            int width = 300;
            int height = 300;

            // Configure PSD options for an indexed image
            PsdOptions options = new PsdOptions();
            options.Source = new FileCreateSource(outputPath, false);
            options.ColorMode = ColorModes.Indexed;
            options.CompressionMethod = CompressionMethod.RLE;
            options.ChannelBitsCount = (short)8;   // 8 bits per channel
            options.ChannelsCount = (short)1;      // Indexed uses a single channel
            // Define a simple palette
            options.Palette = new ColorPalette(new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.White,
                Color.Black
            });

            // Create the PSD image canvas
            using (Image image = Image.Create(options, width, height))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Draw a black line from (10,10) to (200,200) with thickness 2
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(10, 10), new Point(200, 200));

                // Save the image (output path already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a simple vector annotation, such as a black line, on an indexed‑color Photoshop PSD file for a thumbnail preview in a digital asset management system.
 * 2. When creating a low‑file‑size PSD template that uses a limited palette, for example a logo mock‑up that includes a straight guide line drawn programmatically in C#.
 * 3. When automating the production of printable line‑art overlays, like measurement guides, on indexed PSD layers for a batch‑processing workflow in a printing pipeline.
 * 4. When building a web service that returns a PSD image with a diagnostic line (e.g., from point A to point B) to visualize image‑processing results while keeping the file size small using RLE compression.
 * 5. When integrating Aspose.Imaging into a Windows desktop application that needs to draw a simple line on an indexed PSD canvas as part of a custom UI component for design‑review annotations.
 */