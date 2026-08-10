// HOW-TO: Crop Center 400x400 From PNG and Save As SVG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Determine the central 400x400 rectangle
                int cropWidth = 400;
                int cropHeight = 400;
                int x = (image.Width - cropWidth) / 2;
                int y = (image.Height - cropHeight) / 2;

                // Crop the image to the central region
                image.Crop(new Rectangle(x, y, cropWidth, cropHeight));

                // Prepare SVG save options
                SvgOptions svgOptions = new SvgOptions();

                // Save the cropped image as SVG
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to extract a 400 × 400 thumbnail from the middle of a PNG logo and embed it as scalable SVG in a web page.
 * 2. When generating vector‑based icons from raster screenshots by cropping the focal area before conversion to SVG for responsive UI design.
 * 3. When preparing print‑ready artwork that requires a centered raster segment of a PNG to be transformed into an editable SVG format.
 * 4. When automating batch processing to isolate the central portion of product images and store them as SVG files for lightweight storage.
 * 5. When creating diagram components by trimming the core area of a PNG diagram and converting it to SVG for seamless scaling in documentation.
 */
