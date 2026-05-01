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
            // Hardcoded input and output paths
            string inputPath = "input.odg";
            string outputPath = "output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Configure SVG rasterization options; setting PageSize defines the viewBox
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = odgImage.Size
                };

                // Create SVG options and assign rasterization settings
                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as SVG
                odgImage.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}