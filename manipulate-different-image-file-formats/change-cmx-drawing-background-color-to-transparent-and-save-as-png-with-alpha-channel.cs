using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to CmxImage to access specific properties
            CmxImage cmxImage = (CmxImage)image;

            // Set background to fully transparent
            cmxImage.HasBackgroundColor = true;
            cmxImage.BackgroundColor = Aspose.Imaging.Color.Transparent;

            // Prepare PNG save options with rasterization settings
            var pngOptions = new PngOptions();
            var cmxRasterOptions = new CmxRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.Transparent
            };
            pngOptions.VectorRasterizationOptions = cmxRasterOptions;

            // Save as PNG preserving the alpha channel
            cmxImage.Save(outputPath, pngOptions);
        }
    }
}