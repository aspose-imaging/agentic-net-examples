using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.otg";
        string outputPath = @"C:\temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare rasterization options for OTG
            OtgRasterizationOptions otgOptions = new OtgRasterizationOptions
            {
                // Use the original image size as the page size
                PageSize = image.Size
            };

            // Prepare PNG save options and attach the rasterization options
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = otgOptions
            };

            // Save the image as PNG using the specified options
            image.Save(outputPath, pngOptions);
        }
    }
}