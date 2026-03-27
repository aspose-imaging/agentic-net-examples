using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.dng";
        string outputPath = @"C:\Images\sample_converted.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access palette and dithering features
            RasterImage raster = (RasterImage)image;

            // Generate a 256‑color palette that best fits the image
            IColorPalette palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256);

            // Optional: apply dithering to improve visual quality after palette reduction
            raster.Dither(DitheringMethod.FloydSteinbergDithering, 8);

            // Prepare GIF save options with the custom palette
            GifOptions gifOptions = new GifOptions
            {
                Palette = palette,
                DoPaletteCorrection = false   // palette already provided
            };

            // Save the image as GIF using the specified options
            image.Save(outputPath, gifOptions);
        }
    }
}