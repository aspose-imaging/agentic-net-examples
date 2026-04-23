using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cmx";
            string outputPath = "output/output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX vector image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                // Configure rasterization options with desired DPI (e.g., 96 DPI for web)
                CmxRasterizationOptions rasterOptions = new CmxRasterizationOptions
                {
                    ResolutionSettings = new ResolutionSetting(96, 96)
                };

                // Set PNG save options and attach rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as PNG
                cmx.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}