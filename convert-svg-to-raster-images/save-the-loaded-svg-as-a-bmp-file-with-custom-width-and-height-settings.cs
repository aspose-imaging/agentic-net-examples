using System;
using System.IO;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.bmp";

        // Ensure any runtime exception is reported without crashing
        try
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Create the output directory (if needed) before saving
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image from the specified file
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Desired dimensions for the rasterized image
                int customWidth = 800;   // example width
                int customHeight = 600;  // example height

                // Resize the SVG to the custom dimensions
                svgImage.Resize(customWidth, customHeight);

                // Save the rasterized image as BMP; format is inferred from the file extension
                svgImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}