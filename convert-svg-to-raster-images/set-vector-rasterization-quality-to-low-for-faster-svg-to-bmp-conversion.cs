using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = Path.Combine("Input", "sample.svg");
        string outputPath = Path.Combine("Output", "sample.bmp");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure low-quality rasterization options for faster processing
            var rasterOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = image.Width,
                PageHeight = image.Height,
                SmoothingMode = SmoothingMode.None,               // Disable anti-aliasing
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel // Low-quality text rendering
            };

            // Set up BMP save options with the rasterization settings
            using (BmpOptions bmpOptions = new BmpOptions())
            {
                bmpOptions.VectorRasterizationOptions = rasterOptions;

                // Save the rasterized image as BMP
                image.Save(outputPath, bmpOptions);
            }
        }
    }
}