using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\animation.apng";
        string outputPath = "Output\\animation.gif";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load APNG image
        using (Image apngImage = Image.Load(inputPath))
        {
            // Export APNG to GIF
            apngImage.Save(outputPath, new GifOptions());

            // Load the generated GIF for comparison
            using (Image gifImage = Image.Load(outputPath))
            {
                // Compare images using SSIM
                var compareOptions = new ImageComparisonOptions();
                var comparisonResult = apngImage.Compare(gifImage, compareOptions);

                // Output SSIM value
                Console.WriteLine($"SSIM between APNG and GIF: {comparisonResult.StructuralSimilarityIndex}");
            }
        }
    }
}