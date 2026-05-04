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
                // Configure rasterization options for OTG to preserve page size
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure SVG options with proper viewBox via PageSize
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    }
                };

                // Assign OTG rasterization options to the save options (required for vector formats)
                svgOptions.VectorRasterizationOptions = otgRasterOptions as VectorRasterizationOptions ?? svgOptions.VectorRasterizationOptions;

                // Save as SVG; viewBox will be set based on PageSize
                image.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}