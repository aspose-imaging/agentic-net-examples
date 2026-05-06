using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Temp\sample.cmx";
            string outputPath = @"C:\Temp\sample.svg";

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
                // Prepare SVG save options
                SvgOptions saveOptions = new SvgOptions
                {
                    TextAsShapes = true // preserve text as vector shapes
                };

                // Configure rasterization options specific to CMX
                CmxRasterizationOptions rasterOptions = new CmxRasterizationOptions
                {
                    // Use the source image size as the page size
                    PageSize = cmxImage.Size,
                    // Optional: set background color if needed
                    BackgroundColor = Color.White
                };

                saveOptions.VectorRasterizationOptions = rasterOptions;

                // Save as SVG
                cmxImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}