using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX vector image
        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
        {
            // Prepare PNG save options
            PngOptions pngOptions = new PngOptions();

            // Configure rasterization options with desired DPI (e.g., 300 DPI)
            CmxRasterizationOptions rasterOptions = new CmxRasterizationOptions
            {
                ResolutionSettings = new ResolutionSetting(300, 300)
            };

            // Assign rasterization options to PNG options
            pngOptions.VectorRasterizationOptions = rasterOptions;

            // Save the rasterized PNG image
            cmxImage.Save(outputPath, pngOptions);
        }
    }
}