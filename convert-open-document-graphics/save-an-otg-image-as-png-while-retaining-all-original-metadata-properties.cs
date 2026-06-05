using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.otg";
            string outputPath = "Output/sample.png";

            // Verify input file exists
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
                using (PngOptions pngOptions = new PngOptions())
                {
                    pngOptions.KeepMetadata = true;

                    // Set vector rasterization options for OTG conversion
                    OtgRasterizationOptions otgRasterizationOptions = new OtgRasterizationOptions
                    {
                        PageSize = image.Size
                    };
                    pngOptions.VectorRasterizationOptions = otgRasterizationOptions;

                    // Save as PNG
                    image.Save(outputPath, pngOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}