using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.otg";
            string outputPath = "output\\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare BMP save options with 8‑bit palette
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 8,
                    // Generate a palette that best matches the source image
                    Palette = ColorPaletteHelper.GetCloseImagePalette((RasterImage)image, 256)
                };

                // Set rasterization options for vector content
                OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };
                bmpOptions.VectorRasterizationOptions = rasterOptions;

                // Save the image as BMP
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}