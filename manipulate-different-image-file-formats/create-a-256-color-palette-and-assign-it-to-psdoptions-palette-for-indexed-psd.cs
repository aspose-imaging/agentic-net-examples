using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.bmp";
        string outputPath = "output.psd";

        // Ensure any runtime exception is reported without crashing
        try
        {
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
                RasterImage rasterImage = (RasterImage)image;

                // Create PSD save options
                PsdOptions psdOptions = new PsdOptions();

                // Generate a 256‑color palette from the source image
                psdOptions.Palette = ColorPaletteHelper.GetCloseImagePalette(rasterImage, 256);

                // Optional: set color mode to indexed (Bitmap) for palettized PSD
                psdOptions.ColorMode = ColorModes.Bitmap;

                // Save the image as an indexed PSD using the generated palette
                image.Save(outputPath, psdOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}