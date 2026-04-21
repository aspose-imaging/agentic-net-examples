using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\sample.svg";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare SVG export options
            var svgOptions = new SvgOptions();

            // If the source is a vector image, set rasterization options (optional but recommended)
            if (image is VectorImage)
            {
                svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };
            }

            // Save the image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}