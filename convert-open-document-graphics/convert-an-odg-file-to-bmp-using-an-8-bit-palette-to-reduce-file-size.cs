using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample_8bit.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG vector image
        using (Image odgImage = Image.Load(inputPath))
        {
            // Configure rasterization options for the ODG source
            var rasterOptions = new OdgRasterizationOptions
            {
                // White background to avoid transparency issues
                BackgroundColor = Color.White,
                // Preserve the original size of the source image
                PageSize = odgImage.Size
            };

            // Prepare BMP save options with an 8‑bit palette
            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 8,
                // Attach the rasterization options so the vector ODG is rasterized during save
                VectorRasterizationOptions = rasterOptions
            };

            // Generate a palette that best matches the rasterized image.
            // First, rasterize the image to a temporary raster image using the same options.
            using (RasterImage tempRaster = (RasterImage)odgImage)
            {
                // Obtain a palette covering up to 256 colors.
                bmpOptions.Palette = ColorPaletteHelper.GetCloseImagePalette(tempRaster, 256);
            }

            // Save the rasterized ODG as an 8‑bit BMP file
            odgImage.Save(outputPath, bmpOptions);
        }
    }
}