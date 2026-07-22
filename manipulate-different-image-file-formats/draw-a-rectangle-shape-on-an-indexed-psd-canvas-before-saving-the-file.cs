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
            // Hardcoded output path
            string outputPath = @"C:\temp\output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define canvas size
            int width = 400;
            int height = 300;

            // Create a source bound to the output file
            Source source = new FileCreateSource(outputPath, false);

            // Configure PSD options for an indexed color mode
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = source;
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.CompressionMethod = CompressionMethod.RLE;
            psdOptions.Version = 6;
            psdOptions.ChannelBitsCount = (short)8;
            psdOptions.ChannelsCount = (short)1;
            // Simple palette with a few colors
            psdOptions.Palette = new ColorPalette(new Color[]
            {
                Color.Black,
                Color.White,
                Color.Red,
                Color.Green,
                Color.Blue
            });

            // Create the PSD canvas (output file is already bound)
            using (Image canvas = Image.Create(psdOptions, width, height))
            {
                // Draw a rectangle on the canvas
                Graphics graphics = new Graphics(canvas);
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 150));

                // Save the bound image
                canvas.Save();
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
 * 1. When a developer needs to generate a PSD file with an indexed color palette and overlay a simple rectangle for a thumbnail or placeholder image in a C# application.
 * 2. When creating automated mock‑ups of print layouts where the PSD must use RLE compression and a limited palette, and a rectangle marks the safe‑area boundaries.
 * 3. When building a batch‑processing tool that adds a border rectangle to existing indexed PSD files before they are handed off to a Photoshop workflow.
 * 4. When implementing a server‑side image service that programmatically creates PSD canvases in ColorModes.Indexed and draws vector shapes such as rectangles for UI icons.
 * 5. When testing Aspose.Imaging for .NET’s support for indexed PSD creation, compression, and graphics drawing by drawing a rectangle on a newly created canvas.
 */