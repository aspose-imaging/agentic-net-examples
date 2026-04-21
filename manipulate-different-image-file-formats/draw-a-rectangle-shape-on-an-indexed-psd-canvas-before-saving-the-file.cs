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
        // Hardcoded paths
        string outputPath = @"C:\Temp\output.psd";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Define canvas size
        int width = 400;
        int height = 300;

        // Create a source for the PSD file
        Source source = new FileCreateSource(outputPath, false);

        // Configure PSD options for an indexed image
        PsdOptions psdOptions = new PsdOptions
        {
            Source = source,
            ColorMode = ColorModes.Indexed,
            CompressionMethod = CompressionMethod.RLE,
            Version = 6,
            ChannelsCount = (short)1,
            ChannelBitsCount = (short)8,
            Palette = new ColorPalette(new Color[] { Color.Black, Color.White })
        };

        // Create the PSD canvas
        using (RasterImage canvas = (RasterImage)Image.Create(psdOptions, width, height))
        {
            // Draw a rectangle on the canvas
            Graphics graphics = new Graphics(canvas);
            Pen pen = new Pen(Color.Black, 3);
            graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 150));

            // Save the bound image
            canvas.Save();
        }
    }
}