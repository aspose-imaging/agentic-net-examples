using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.cmx";
        string outputPath = "Output/sample.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Log conversion parameters
        Console.WriteLine("Starting CMX to PNG conversion");
        Console.WriteLine($"Input Path : {inputPath}");
        Console.WriteLine($"Output Path: {outputPath}");

        // Load CMX image and convert to PNG
        using (CmxImage cmxImage = (CmxImage)Aspose.Imaging.Image.Load(inputPath))
        {
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = cmxImage.Width,
                    PageHeight = cmxImage.Height,
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None
                }
            };

            cmxImage.Save(outputPath, pngOptions);
        }

        Console.WriteLine("Conversion completed successfully");
    }
}