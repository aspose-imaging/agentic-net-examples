using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.otg";
        string outputPath = @"C:\temp\output_8bit.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access pixel data for palette generation
            RasterImage rasterImage = (RasterImage)image;

            // Configure BMP save options for 8‑bit palette
            BmpOptions saveOptions = new BmpOptions
            {
                BitsPerPixel = 8,
                // Generate a palette that best matches the source image (max 256 colors)
                Palette = ColorPaletteHelper.GetCloseImagePalette(rasterImage, 256),
                Compression = BitmapCompression.Rgb,
                ResolutionSettings = new ResolutionSetting(96.0, 96.0)
            };

            // Set OTG rasterization options so the vector content is rasterized correctly
            OtgRasterizationOptions otgRasterization = new OtgRasterizationOptions
            {
                PageSize = image.Size
            };
            saveOptions.VectorRasterizationOptions = otgRasterization;

            // Save the image as an 8‑bit BMP
            image.Save(outputPath, saveOptions);
        }
    }
}