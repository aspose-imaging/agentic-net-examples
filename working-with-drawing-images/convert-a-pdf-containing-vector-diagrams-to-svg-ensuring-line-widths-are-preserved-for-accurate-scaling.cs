using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = Path.Combine("Input", "diagram.pdf");
        string outputPath = Path.Combine("Output", "diagram.svg");

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PDF document
        using (Image image = Image.Load(inputPath))
        {
            // Configure SVG export options
            using (SvgOptions svgOptions = new SvgOptions())
            {
                // Set vector rasterization options to preserve original size
                svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }
        }
    }
}