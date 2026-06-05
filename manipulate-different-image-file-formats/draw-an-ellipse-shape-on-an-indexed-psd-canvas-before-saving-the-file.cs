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
            // Output path (hard‑coded)
            string outputPath = @"C:\temp\output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure PSD options for an indexed canvas
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.ChannelBitsCount = 8;      // 8 bits per channel
            psdOptions.ChannelsCount = 1;        // Indexed images have a single channel

            // Define a simple palette (black, white, red, green, blue)
            Aspose.Imaging.Color[] paletteColors = new Aspose.Imaging.Color[]
            {
                Aspose.Imaging.Color.Black,
                Aspose.Imaging.Color.White,
                Aspose.Imaging.Color.Red,
                Aspose.Imaging.Color.Green,
                Aspose.Imaging.Color.Blue
            };
            psdOptions.Palette = new ColorPalette(paletteColors);

            // Create the PSD canvas (500x500 pixels)
            using (Image image = Image.Create(psdOptions, 500, 500))
            {
                // Draw an ellipse on the canvas
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);
                graphics.DrawEllipse(
                    new Pen(Aspose.Imaging.Color.Black, 2),
                    new Rectangle(100, 100, 300, 200));

                // Save the PSD file (output is already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a lightweight Photoshop PSD file with a limited color palette for web‑based mockups, they can use this code to draw an ellipse on an indexed canvas and save it as a 8‑bit PSD.
 * 2. When creating automated thumbnails for a digital asset management system that must retain PSD compatibility while using minimal file size, the code lets you render an ellipse on a 500×500 indexed PSD.
 * 3. When building a batch‑processing tool that adds vector‑style shapes to legacy PSD files that only support indexed colors, this example shows how to draw an ellipse and preserve the custom palette.
 * 4. When producing printable design assets where the color palette is pre‑defined (e.g., brand colors) and the artwork includes simple geometric shapes, the code demonstrates drawing an ellipse on an indexed PSD before saving.
 * 5. When integrating Aspose.Imaging into a C# application that generates PSD templates for UI prototyping, the snippet provides a way to add an ellipse to an indexed canvas with a custom palette and export it directly to disk.
 */