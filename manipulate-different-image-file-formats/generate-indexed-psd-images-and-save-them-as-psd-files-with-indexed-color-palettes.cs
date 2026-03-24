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
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output_indexed.psd";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for palette generation
            RasterImage raster = (RasterImage)image;

            // Generate a palette with the closest 256 colors
            IColorPalette palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256);

            // Configure PSD options for indexed color mode
            PsdOptions psdOptions = new PsdOptions
            {
                ColorMode = ColorModes.Indexed,
                ChannelBitsCount = 8,
                ChannelsCount = 1,
                Palette = palette
            };

            // Save the image as an indexed PSD
            image.Save(outputPath, psdOptions);
        }

        // Create a new indexed PSD image from scratch
        string outputPath2 = "output_created_indexed.psd";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath2));

        // Build a simple grayscale palette (256 shades)
        Color[] colors = new Color[256];
        for (int i = 0; i < 256; i++)
        {
            colors[i] = Color.FromArgb(255, i, i, i);
        }
        IColorPalette simplePalette = new ColorPalette(colors);

        // Set up creation options with indexed mode and the palette
        PsdOptions createOptions = new PsdOptions
        {
            Source = new FileCreateSource(outputPath2, false),
            ColorMode = ColorModes.Indexed,
            ChannelBitsCount = 8,
            ChannelsCount = 1,
            Palette = simplePalette
        };

        // Create a 100x100 canvas; the file is already bound via FileCreateSource
        using (Image canvas = Image.Create(createOptions, 100, 100))
        {
            // No drawing needed; just save the bound image
            canvas.Save();
        }
    }
}