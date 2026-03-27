using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\Temp\indexed_output.psd";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure PSD options with a custom 256‑color palette
        PsdOptions psdOptions = new PsdOptions
        {
            // Use a standard 8‑bit (256 colors) palette derived from the RGB space
            Palette = Aspose.Imaging.ColorPaletteHelper.Create8Bit(),
            // Set color mode to RGB (palette will be applied)
            ColorMode = ColorModes.Rgb,
            // Set bits per channel and channels count for a typical 8‑bit per channel RGBA image
            ChannelBitsCount = 8,
            ChannelsCount = 4,
            // No compression (RAW) for simplicity
            CompressionMethod = Aspose.Imaging.FileFormats.Psd.CompressionMethod.Raw,
            // Default PSD version (6)
            Version = 6
        };

        // Create a new PSD image of size 256x256 using the options above
        using (Image psdImage = Image.Create(psdOptions, 256, 256))
        {
            // Draw a simple gradient to visualize the palette
            Graphics graphics = new Graphics(psdImage);
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(psdImage.Width, psdImage.Height),
                Color.Red,
                Color.Blue);

            graphics.FillRectangle(gradientBrush, psdImage.Bounds);

            // Save the image to the specified path using the same options
            psdImage.Save(outputPath, psdOptions);
        }
    }
}