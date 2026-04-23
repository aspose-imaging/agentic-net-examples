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
            string outputPath = "output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Configure PSD options for an indexed image
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.CompressionMethod = CompressionMethod.RLE;
            psdOptions.ChannelBitsCount = 8; // 8 bits per channel
            psdOptions.ChannelsCount = 1;    // Indexed mode uses a single channel

            // Define a simple palette (must contain at least one color)
            psdOptions.Palette = new ColorPalette(new Color[]
            {
                Color.Black,
                Color.White,
                Color.Red,
                Color.Green,
                Color.Blue
            });

            int width = 500;
            int height = 500;

            // Create the PSD canvas bound to the output file
            using (Image canvas = Image.Create(psdOptions, width, height))
            {
                // Create graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Clear background with the first palette color
                graphics.Clear(Color.Black);

                // Draw an ellipse using a red pen
                graphics.DrawEllipse(new Pen(Color.Red, 5), new Rectangle(50, 50, 400, 300));

                // Save the image (output file already bound via FileCreateSource)
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}