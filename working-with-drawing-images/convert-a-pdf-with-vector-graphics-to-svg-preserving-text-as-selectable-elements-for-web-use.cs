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
        string inputPath = @"C:\Input\sample.pdf";
        string outputPath = @"C:\Output\sample.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PDF document
        using (Image image = Image.Load(inputPath))
        {
            // Configure SVG export options
            SvgOptions svgOptions = new SvgOptions
            {
                // Preserve text as selectable text (not converted to shapes)
                TextAsShapes = false,
                // Set rasterization options with the source page size
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                }
            };

            // Save the PDF as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}