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
            string outputPath = @"C:\temp\output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define canvas size
            int width = 500;
            int height = 400;

            // Create PSD options for an indexed image
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.CompressionMethod = CompressionMethod.RLE;
            psdOptions.ChannelBitsCount = (short)8;   // 8 bits per channel
            psdOptions.ChannelsCount = (short)1;      // Indexed images have 1 channel
            psdOptions.Version = 6;                  // Default PSD version

            // Define a simple palette (must contain at least one color)
            psdOptions.Palette = new ColorPalette(new Color[]
            {
                Color.Black,
                Color.White,
                Color.Red,
                Color.Green,
                Color.Blue
            });

            // Create the PSD canvas
            using (Image psdImage = Image.Create(psdOptions, width, height))
            {
                // Draw a rectangle on the canvas
                Graphics graphics = new Graphics(psdImage);
                Pen pen = new Pen(Color.Black, 3);
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 150));

                // Save the PSD file (output path already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a thumbnail preview of a design in an indexed PSD file with a limited color palette for quick web display.
 * 2. When an automated asset pipeline must add a bounding box rectangle to an indexed PSD canvas to indicate crop areas for a print‑ready workflow.
 * 3. When a game‑engine tool creates level maps as indexed PSD images and draws rectangular zones to mark collision boundaries.
 * 4. When a reporting system programmatically creates PSD charts using indexed colors and draws rectangles to highlight specific data ranges.
 * 5. When a batch‑processing script adds a watermark rectangle to indexed PSD files before they are uploaded to a digital asset management system.
 */