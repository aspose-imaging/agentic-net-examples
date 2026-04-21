using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded relative input and output paths
        string inputPath = Path.Combine("Input", "sample.odg");
        string outputPath = Path.Combine("Output", "sample.bmp");

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG vector image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Configure BMP save options for 8‑bit palette
            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 8,
                // Use a standard 8‑bit grayscale palette (suitable for size reduction)
                Palette = Aspose.Imaging.ColorPaletteHelper.Create8BitGrayscale(false),
                Compression = BitmapCompression.Rgb,
                ResolutionSettings = new Aspose.Imaging.ResolutionSetting(96.0, 96.0),
                // Rasterize the vector image onto a bitmap
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                }
            };

            // Save the rasterized BMP image
            image.Save(outputPath, bmpOptions);
        }
    }
}