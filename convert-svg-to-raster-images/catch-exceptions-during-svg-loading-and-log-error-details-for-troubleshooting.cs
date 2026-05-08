using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions;
using Aspose.Imaging.CoreExceptions.ImageFormats;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG and handle specific loading exceptions
            try
            {
                using (SvgImage svgImage = new SvgImage(inputPath))
                {
                    // Set up rasterization options for PNG output
                    var rasterOptions = new SvgRasterizationOptions();
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save rasterized image
                    svgImage.Save(outputPath, pngOptions);
                }
            }
            catch (SvgImageException ex)
            {
                Console.Error.WriteLine($"SVG loading error: {ex.Message}");
            }
            catch (ImageLoadException ex)
            {
                Console.Error.WriteLine($"Image load error: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}