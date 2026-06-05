using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string outputPath = @"C:\Images\sample.svg";

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
                // Configure SVG export options
                var svgOptions = new SvgOptions
                {
                    // Preserve original layer names and other metadata
                    KeepMetadata = true,
                    // Set rasterization options for OTG source
                    VectorRasterizationOptions = new OtgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}