using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.otg";
        string outputPath = "sample.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare BMP save options with OTG rasterization settings
            BmpOptions bmpOptions = new BmpOptions();

            // Set rasterization options to keep original size
            OtgRasterizationOptions otgRaster = new OtgRasterizationOptions
            {
                PageSize = image.Size // maintain original dimensions
            };

            bmpOptions.VectorRasterizationOptions = otgRaster;

            // Save as BMP
            image.Save(outputPath, bmpOptions);
        }
    }
}