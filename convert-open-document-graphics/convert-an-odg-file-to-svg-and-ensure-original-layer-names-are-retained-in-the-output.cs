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
        string inputPath = @"C:\temp\sample.odg";
        string outputPath = @"C:\temp\sample.svg";

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
            // Configure SVG export options
            SvgOptions svgOptions = new SvgOptions
            {
                // Preserve original metadata (including layer names)
                KeepMetadata = true,
                // Set rasterization options based on the source image size
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size,
                    BackgroundColor = Color.Transparent
                }
            };

            // Save the image as SVG while retaining layer information
            image.Save(outputPath, svgOptions);
        }
    }
}