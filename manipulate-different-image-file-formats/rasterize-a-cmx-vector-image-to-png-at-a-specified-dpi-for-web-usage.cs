using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.cmx";
        string outputPath = "output.png";

        // Verify that the input CMX file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX vector image
        using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
        {
            // Configure rasterization options with the desired DPI (e.g., 96 DPI)
            var rasterOptions = new CmxRasterizationOptions
            {
                ResolutionSettings = new ResolutionSetting(96, 96)
            };

            // Set PNG save options and attach the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save the rasterized image as PNG
            cmx.Save(outputPath, pngOptions);
        }
    }
}