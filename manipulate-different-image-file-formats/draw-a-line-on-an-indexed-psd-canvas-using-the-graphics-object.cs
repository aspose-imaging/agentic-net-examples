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
            // Output PSD file path
            string outputPath = "output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Configure PSD options for an indexed image
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.CompressionMethod = CompressionMethod.RLE;
            psdOptions.Version = 5;
            psdOptions.ChannelBitsCount = (short)8; // 8 bits per channel
            psdOptions.ChannelsCount = (short)1;    // Indexed uses a single channel

            // Define a simple palette
            Color[] paletteColors = new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.White,
                Color.Black
            };
            psdOptions.Palette = new ColorPalette(paletteColors);

            int width = 500;
            int height = 500;

            // Create the PSD canvas
            using (Image image = Image.Create(psdOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Draw a black line from (50,50) to (450,450)
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(50, 50), new Point(450, 450));

                // Save the image (output is already bound to the file)
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
 * 1. When creating a lightweight PSD file with a limited color palette for a web‑based mockup and needing to programmatically add a diagonal guide line using Aspose.Imaging for .NET.
 * 2. When generating indexed‑color Photoshop documents for printing proofs and you must draw precise vector lines (e.g., crop marks) directly onto the canvas via the Graphics object.
 * 3. When automating the production of PSD assets for a game UI where memory constraints require an 8‑bit indexed image and you need to overlay a simple line to indicate alignment or boundaries.
 * 4. When building a batch conversion tool that creates PSD files from scratch, sets a custom palette, and draws diagnostic lines to verify coordinate transformations in C#.
 * 5. When developing a server‑side image processing service that outputs PSD files with RLE compression and includes a black line as a watermark or annotation on an indexed image.
 */