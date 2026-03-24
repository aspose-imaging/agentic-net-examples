using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PNG save options, including the desired bit depth
            PngOptions pngOptions = new PngOptions
            {
                // Set bit depth (valid values: 1,2,4,8,16 depending on color type)
                BitDepth = 8,

                // Example settings – adjust as needed
                ColorType = PngColorType.TruecolorWithAlpha,
                CompressionLevel = 9,
                Progressive = true
            };

            // Save the image using the configured PNG options
            image.Save(outputPath, pngOptions);
        }
    }
}