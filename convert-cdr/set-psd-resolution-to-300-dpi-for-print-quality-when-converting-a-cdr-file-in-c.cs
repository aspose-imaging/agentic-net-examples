using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.cdr";
        string outputPath = "output.psd";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR file
        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
        {
            // Prepare PSD save options
            PsdOptions psdOptions = new PsdOptions();

            // Set resolution to 300 DPI for print quality
            psdOptions.ResolutionSettings = new ResolutionSetting(300.0, 300.0);

            // For vector images, define rasterization options
            if (cdrImage is VectorImage)
            {
                // Use default vector rasterization options with white background
                psdOptions.VectorRasterizationOptions = (VectorRasterizationOptions)cdrImage.GetDefaultOptions(
                    new object[] { Color.White, cdrImage.Width, cdrImage.Height });
            }

            // Save as PSD with the specified options
            cdrImage.Save(outputPath, psdOptions);
        }
    }
}