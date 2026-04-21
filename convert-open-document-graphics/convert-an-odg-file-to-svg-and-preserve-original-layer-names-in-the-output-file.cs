using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Data\sample.odg";
        string outputPath = @"C:\Data\sample.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image odgImage = Image.Load(inputPath))
        {
            // Prepare SVG export options
            var svgOptions = new SvgOptions
            {
                // Vector rasterization options are required for SVG export
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    // Preserve the original page size
                    PageSize = odgImage.Size,
                    // Preserve layer (group) names – Aspose.Imaging keeps them by default
                    // No additional configuration is needed
                }
            };

            // Save as SVG; layer names are retained in the generated SVG
            odgImage.Save(outputPath, svgOptions);
        }
    }
}