using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

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
            // Prepare SVG save options
            SvgOptions svgOptions = new SvgOptions
            {
                // Render text as shapes to preserve appearance
                TextAsShapes = true
            };

            // Configure rasterization options specific to CMX
            CmxRasterizationOptions rasterOptions = new CmxRasterizationOptions
            {
                // Use the original image size for the SVG page
                PageSize = cmxImage.Size
            };

            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save the image as SVG
            cmxImage.Save(outputPath, svgOptions);
        }
    }
}