using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main(string[] args)
    {
        // Define relative input and output paths
        string inputPath = Path.Combine("Input", "sample.otg");
        string outputPath = Path.Combine("Output", "sample.png");

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PNG save options to keep metadata
            PngOptions pngOptions = new PngOptions
            {
                KeepMetadata = true,
                VectorRasterizationOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                }
            };

            // Save as PNG while preserving metadata
            image.Save(outputPath, pngOptions);
        }
    }
}