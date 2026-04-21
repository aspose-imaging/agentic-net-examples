using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.cmx";
        string outputPath = @"C:\temp\sample.svg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image
        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
        {
            // Configure SVG save options
            SvgOptions svgOptions = new SvgOptions
            {
                // Render text as vector shapes to preserve appearance
                TextAsShapes = true
            };

            // Set up CMX rasterization options
            CmxRasterizationOptions rasterOptions = new CmxRasterizationOptions
            {
                // Use the original image size for the SVG page
                PageSize = cmxImage.Size,
                // Optional: set a background color if needed
                BackgroundColor = Color.White
            };

            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save the image as SVG
            cmxImage.Save(outputPath, svgOptions);
        }
    }
}