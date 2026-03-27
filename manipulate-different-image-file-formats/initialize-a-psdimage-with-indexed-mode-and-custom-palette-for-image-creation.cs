using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\source.png";
        string outputPath = @"C:\temp\output.psd";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load source image to obtain dimensions
        using (Image sourceImage = Image.Load(inputPath))
        {
            int width = sourceImage.Width;
            int height = sourceImage.Height;

            // Create a custom palette (red and green)
            Aspose.Imaging.Color[] paletteColors = new Aspose.Imaging.Color[]
            {
                Aspose.Imaging.Color.Red,
                Aspose.Imaging.Color.Green
            };
            IColorPalette customPalette = new ColorPalette(paletteColors);

            // Configure PSD options for indexed-like image
            PsdOptions psdOptions = new PsdOptions
            {
                // Set the source to create the file
                Source = new FileCreateSource(outputPath, false),

                // Use 8 bits per channel and 3 channels (RGB)
                ChannelBitsCount = 8,
                ChannelsCount = 3,

                // Set color mode to RGB (palette will be applied)
                ColorMode = ColorModes.Rgb,

                // Assign the custom palette
                Palette = customPalette,

                // Use RLE compression (optional)
                CompressionMethod = CompressionMethod.RLE,

                // Default PSD version
                Version = 6
            };

            // Create a new PSD image with the specified options
            using (Image psdImage = Image.Create(psdOptions, width, height))
            {
                // Fill the image with a simple gradient using the custom palette colors
                Graphics graphics = new Graphics(psdImage);
                LinearGradientBrush gradientBrush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(width, height),
                    Aspose.Imaging.Color.Red,
                    Aspose.Imaging.Color.Green);
                graphics.FillRectangle(gradientBrush, psdImage.Bounds);

                // Save the PSD image
                psdImage.Save();
            }
        }
    }
}