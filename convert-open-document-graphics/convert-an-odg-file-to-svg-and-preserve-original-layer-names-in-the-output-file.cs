using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.odg";
        string outputPath = "sample.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare SVG export options
            var svgOptions = new SvgOptions
            {
                // Set rasterization options to match the source image size
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                }
            };

            // Save the image as SVG; layer names are preserved by default
            image.Save(outputPath, svgOptions);
        }
    }
}