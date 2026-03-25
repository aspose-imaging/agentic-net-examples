using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.cdr";
        string outputPath = "output.psd";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR vector image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PSD save options with 300 DPI resolution
            PsdOptions psdOptions = new PsdOptions
            {
                // Set resolution to 300 DPI for both axes
                ResolutionSettings = new ResolutionSetting(300.0, 300.0),

                // Define color mode (optional, default is RGB)
                ColorMode = ColorModes.Rgb,

                // Rasterize the vector CDR using its dimensions
                VectorRasterizationOptions = new CdrRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height
                }
            };

            // Save the image as PSD with the specified options
            image.Save(outputPath, psdOptions);
        }
    }
}