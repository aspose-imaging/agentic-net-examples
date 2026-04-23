using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.svg";
        string outputPath = "Output/sample.bmp";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure BMP save options with indexed palette
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 8,
                Palette = ColorPaletteHelper.Create8BitGrayscale(false),
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                }
            };

            // Save as BMP using the defined options
            image.Save(outputPath, bmpOptions);
        }
    }
}