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
            string outputPath = "output.psd";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Configure PSD options for an indexed color image
            PsdOptions options = new PsdOptions();
            options.Source = new FileCreateSource(outputPath, false);
            options.ColorMode = ColorModes.Indexed;
            options.ChannelBitsCount = (short)8;
            options.ChannelsCount = (short)1;
            // Simple palette with black and white entries
            options.Palette = new ColorPalette(new Color[] { Color.Black, Color.White });

            int width = 200;
            int height = 200;

            using (Image psdImage = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(psdImage);
                graphics.Clear(Color.White);
                // Draw a rectangle on the PSD canvas
                graphics.DrawRectangle(new Pen(Color.Black, 1), new Rectangle(50, 50, 100, 80));

                // Save the PSD (output is already bound to the file)
                psdImage.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}