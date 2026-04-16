using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

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

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure BMP save options with vector rasterization
            var bmpOptions = new BmpOptions();
            var vectorOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = image.Width,
                PageHeight = image.Height
            };
            bmpOptions.VectorRasterizationOptions = vectorOptions;

            // Save as BMP
            image.Save(outputPath, bmpOptions);
        }
    }
}