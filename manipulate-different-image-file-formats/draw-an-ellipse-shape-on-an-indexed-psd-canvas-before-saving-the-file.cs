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
            // Output file path (hardcoded)
            string outputPath = "output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Configure PSD options for an indexed canvas
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.CompressionMethod = CompressionMethod.RLE;
            psdOptions.ChannelBitsCount = 8;      // 8 bits per channel
            psdOptions.ChannelsCount = 1;        // Indexed mode uses a single channel
            psdOptions.Version = 6;              // PSD version
            psdOptions.Palette = new ColorPalette(new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.White,
                Color.Black
            });

            int width = 500;
            int height = 400;

            // Create the PSD canvas
            using (Image image = Image.Create(psdOptions, width, height))
            {
                // Draw on the canvas
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Blue, 3);
                graphics.DrawEllipse(pen, new Rectangle(50, 50, 300, 200));

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
 * 1. When a developer needs to generate a PSD file with an indexed color palette and overlay a vector ellipse for use in a web‑based design preview.
 * 2. When an automated asset pipeline must create thumbnail PSDs with a blue ellipse annotation to indicate a region of interest in a batch of product images.
 * 3. When a C# application has to produce a Photoshop‑compatible indexed image for a game UI and draw a selectable elliptical button shape before saving.
 * 4. When a reporting tool has to embed a simple ellipse graphic into an indexed PSD document that will later be edited by designers using Photoshop.
 * 5. When a server‑side service must programmatically add a highlighted elliptical outline to a PSD canvas with a limited color palette for branding purposes.
 */