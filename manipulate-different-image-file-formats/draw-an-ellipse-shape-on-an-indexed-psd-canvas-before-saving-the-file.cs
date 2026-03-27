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
        // Define output path
        string outputPath = @"C:\Temp\IndexedCanvas.psd";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Prepare PSD options for an indexed image
        PsdOptions psdOptions = new PsdOptions();
        psdOptions.Source = new FileCreateSource(outputPath, false);
        psdOptions.ColorMode = ColorModes.Indexed;
        psdOptions.CompressionMethod = CompressionMethod.RLE;
        psdOptions.Version = 6;
        psdOptions.ChannelBitsCount = (short)8;   // 8 bits per channel
        psdOptions.ChannelsCount = (short)1;     // single channel for indexed mode

        // Define a simple palette (black, white, red, green, blue)
        Color[] paletteColors = new Color[]
        {
            Color.Black,
            Color.White,
            Color.Red,
            Color.Green,
            Color.Blue
        };
        psdOptions.Palette = new ColorPalette(paletteColors);

        // Create a new PSD image with the specified options
        using (Image image = Image.Create(psdOptions, 500, 500))
        {
            // Draw on the image
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Pen for the ellipse
            Pen pen = new Pen(Color.Red, 5);
            graphics.DrawEllipse(pen, new Rectangle(50, 50, 400, 300));

            // Save the bound image (no need to pass options again)
            image.Save();
        }
    }
}