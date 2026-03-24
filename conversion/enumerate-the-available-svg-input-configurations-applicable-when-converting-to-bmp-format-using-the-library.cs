using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.svg";
        string outputDir = @"C:\Images\BmpOutputs";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        // Load the SVG image
        using (Image svgImage = Image.Load(inputPath))
        {
            // 1. Default conversion (no special options)
            SaveBmp(svgImage, Path.Combine(outputDir, "default.bmp"), null);

            // 2. Conversion with explicit VectorRasterizationOptions (page size from source)
            var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
            var bmpOptions1 = new BmpOptions { VectorRasterizationOptions = rasterOptions };
            SaveBmp(svgImage, Path.Combine(outputDir, "withRasterOptions.bmp"), bmpOptions1);

            // 3. Conversion with 8 bits per pixel and a grayscale palette
            var bmpOptions2 = new BmpOptions
            {
                BitsPerPixel = 8,
                Palette = Aspose.Imaging.ColorPaletteHelper.Create8BitGrayscale(false),
                VectorRasterizationOptions = rasterOptions
            };
            SaveBmp(svgImage, Path.Combine(outputDir, "8bpp_grayscale.bmp"), bmpOptions2);

            // 4. Conversion with compression (RLE-8) and 8 bpp
            var bmpOptions3 = new BmpOptions
            {
                BitsPerPixel = 8,
                Compression = Aspose.Imaging.FileFormats.Bmp.BitmapCompression.Rle8,
                Palette = Aspose.Imaging.ColorPaletteHelper.GetCloseImagePalette((RasterImage)svgImage, 256),
                VectorRasterizationOptions = rasterOptions
            };
            SaveBmp(svgImage, Path.Combine(outputDir, "8bpp_rle.bmp"), bmpOptions3);

            // 5. Conversion with higher resolution settings (300 DPI)
            var bmpOptions4 = new BmpOptions
            {
                ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                VectorRasterizationOptions = rasterOptions
            };
            SaveBmp(svgImage, Path.Combine(outputDir, "highDpi.bmp"), bmpOptions4);
        }
    }

    // Helper method to save BMP with optional BmpOptions
    static void SaveBmp(Image image, string outputPath, BmpOptions options)
    {
        // Ensure the directory for the output file exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        if (options == null)
        {
            // Use default BMP options
            image.Save(outputPath, new BmpOptions());
        }
        else
        {
            image.Save(outputPath, options);
        }

        Console.WriteLine($"Saved: {outputPath}");
    }
}