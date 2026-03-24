using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.wmf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure WMF rasterization options using the source image size
            var rasterOptions = new WmfRasterizationOptions
            {
                PageSize = image.Size
            };

            // Set up WMF save options with the rasterization options
            var wmfOptions = new WmfOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the image as WMF
            image.Save(outputPath, wmfOptions);
        }
    }
}