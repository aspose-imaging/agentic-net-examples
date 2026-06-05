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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.bmp";

            // Verify that the input SVG exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Configure BMP save options with an indexed (8‑bpp) palette
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 8, // indexed colour depth
                    Compression = Aspose.Imaging.FileFormats.Bmp.BitmapCompression.Rgb,
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0),

                    // Use a predefined 8‑bit grayscale palette (any indexed palette is acceptable)
                    Palette = Aspose.Imaging.ColorPaletteHelper.Create8BitGrayscale(false),

                    // Rasterization options required for converting vector SVG to raster BMP
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    }
                };

                // Save the SVG as a BMP using the defined options
                svgImage.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}