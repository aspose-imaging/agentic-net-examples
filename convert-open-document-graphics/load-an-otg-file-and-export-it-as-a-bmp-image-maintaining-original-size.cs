using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.otg";
            string outputPath = "output.bmp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare BMP save options with OTG rasterization settings
                var bmpOptions = new BmpOptions();
                var otgRasterizationOptions = new OtgRasterizationOptions
                {
                    // Preserve the original size of the OTG image
                    PageSize = image.Size
                };
                bmpOptions.VectorRasterizationOptions = otgRasterizationOptions;

                // Save the image as BMP
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}