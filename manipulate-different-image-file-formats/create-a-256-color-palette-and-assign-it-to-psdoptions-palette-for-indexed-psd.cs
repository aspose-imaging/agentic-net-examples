using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Temp\source.png";
        string outputPath = @"C:\Temp\result.psd";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to work with palettes
            RasterImage raster = (RasterImage)image;

            // Create PSD save options
            PsdOptions psdOptions = new PsdOptions();

            // Generate a 256‑color palette from the source image and assign it
            psdOptions.Palette = Aspose.Imaging.ColorPaletteHelper.GetCloseImagePalette(raster, 256);

            // Optional: set color mode (e.g., RGB) – not required for palette usage
            psdOptions.ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Rgb;

            // Save the image as a PSD file using the specified options
            image.Save(outputPath, psdOptions);
        }
    }
}