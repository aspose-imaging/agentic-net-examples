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

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PSD options for an indexed image
            PsdOptions psdOptions = new PsdOptions
            {
                // Indexed color mode
                ColorMode = ColorModes.Indexed,
                // Use RLE compression (optional)
                CompressionMethod = CompressionMethod.RLE,
                // Bits per channel (8 bits)
                ChannelBitsCount = 8,
                // One channel for indexed palette
                ChannelsCount = 1,
                // Define a simple palette
                Palette = new ColorPalette(new[]
                {
                    Color.Black,
                    Color.White,
                    Color.Red,
                    Color.Green,
                    Color.Blue
                }),
                // Bind the output file
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new PSD image (e.g., 300x300 pixels)
            using (Image image = Image.Create(psdOptions, 300, 300))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Draw a black line from (10,10) to (200,200) with thickness 2
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(10, 10), new Point(200, 200));

                // Save the image (output is already bound via FileCreateSource)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}