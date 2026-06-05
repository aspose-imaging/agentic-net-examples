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
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\output.bmp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Prepare BMP save options with 8‑bit palette
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 8,
                    // Use a standard 8‑bit grayscale palette; replace with a closer palette if desired
                    Palette = Aspose.Imaging.ColorPaletteHelper.Create8BitGrayscale(false),
                    Compression = Aspose.Imaging.FileFormats.Bmp.BitmapCompression.Rgb,
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0)
                };

                // Save the image as an 8‑bit BMP
                odgImage.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}