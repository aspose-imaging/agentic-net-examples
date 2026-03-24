using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Desired dimensions for the resized image
            int newWidth = 200;
            int newHeight = 200;

            // Resize the SVG image (vector resize)
            image.Resize(newWidth, newHeight);

            // Prepare APNG save options with rasterization settings
            var apngOptions = new ApngOptions
            {
                // Set default frame duration (e.g., 500 ms)
                DefaultFrameTime = 500,
                // Configure vector rasterization so the SVG is rasterized to PNG frames
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = new Size(newWidth, newHeight)
                }
            };

            // Save the resized image as an animated PNG (APNG)
            image.Save(outputPath, apngOptions);
        }
    }
}