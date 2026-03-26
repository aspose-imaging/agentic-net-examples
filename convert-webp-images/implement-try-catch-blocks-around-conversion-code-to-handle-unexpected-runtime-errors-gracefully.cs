using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.png";
        string outputPath = "Output/sample.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare TIFF save options
                using (TiffOptions options = new TiffOptions(TiffExpectedFormat.Default))
                {
                    // Save the image as TIFF
                    image.Save(outputPath, options);
                }
            }
        }
        catch (Exception ex)
        {
            // Handle any unexpected errors
            Console.Error.WriteLine($"Error during conversion: {ex.Message}");
        }
    }
}