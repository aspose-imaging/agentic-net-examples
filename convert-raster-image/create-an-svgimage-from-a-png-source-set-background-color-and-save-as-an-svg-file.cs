using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.png";
        string outputPath = @"C:\Images\result.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare SVG save options with a background color
                var svgOptions = new SvgOptions();
                var rasterOptions = new SvgRasterizationOptions
                {
                    // Set desired background color
                    BackgroundColor = Aspose.Imaging.Color.LightBlue,
                    // Preserve original size
                    PageSize = image.Size
                };
                svgOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}