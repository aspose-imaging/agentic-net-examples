using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.bmp";
            string outputPath = @"C:\temp\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image, adjust contrast, and save as SVG
            using (BmpImage bmp = new BmpImage(inputPath))
            {
                // Increase contrast by 15%
                bmp.AdjustContrast(15f);

                // Save the processed image as SVG using SvgOptions
                SvgOptions svgOptions = new SvgOptions();
                bmp.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop application needs to convert legacy BMP screenshots into scalable SVG graphics while boosting visual clarity by increasing contrast 15%.
 * 2. When an e‑learning platform wants to preprocess scanned BMP diagrams, enhance their contrast, and embed them as resolution‑independent SVGs in HTML lessons.
 * 3. When a reporting tool generates BMP charts that must be resized for print, a developer can adjust contrast and export them as SVG to maintain quality at any size.
 * 4. When a GIS system receives BMP map tiles, a developer can improve their contrast for better readability and convert them to SVG for overlay on web maps.
 * 5. When a branding workflow requires converting BMP logos to SVG format with a slight contrast boost to match brand guidelines, this C# code automates the process.
 */