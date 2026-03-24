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
        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
        {
            // Prepare PNG save options with rasterization settings for vector conversion
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new CmxRasterizationOptions
                {
                    // Optional: set background color and preserve aspect ratio
                    BackgroundColor = Color.White,
                    PageWidth = 0,
                    PageHeight = 0
                }
            };

            // Save the image in the desired format
            cmxImage.Save(outputPath, pngOptions);
        }
    }
}