using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = "input.svg";
            string outputPath = "output\\output.bmp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                // Configure rasterization options with anti‑aliasing
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias
                };

                // Set BMP save options and attach the rasterization options
                BmpOptions bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the rasterized image as BMP
                svgImage.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}