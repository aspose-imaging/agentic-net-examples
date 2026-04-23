using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Temp\sample.odg";
        string outputPath = @"C:\Temp\sample.svg";

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
            // Prepare SVG export options with rasterization settings
            var rasterizationOptions = new SvgRasterizationOptions
            {
                // Use the original image size for the SVG page
                PageSize = image.Size,
                // Optional: set background to white to avoid transparency issues
                BackgroundColor = Color.White
            };

            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions,
                // Compress = false (default) keeps the SVG as plain XML, which is already minimal
                Compress = false
            };

            // Save the image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}