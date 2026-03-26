using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "C:\\temp\\input.svg";
        string outputPath = "C:\\temp\\output.svgz";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load SVG image and ensure proper disposal
        using (SvgImage svgImage = new SvgImage(inputPath))
        {
            // Create SVG options and ensure proper disposal
            using (SvgOptions options = new SvgOptions())
            {
                // Enable compression for SVGZ output
                options.Compress = true;

                // Save the image with the specified options
                svgImage.Save(outputPath, options);
            }
        }
    }
}