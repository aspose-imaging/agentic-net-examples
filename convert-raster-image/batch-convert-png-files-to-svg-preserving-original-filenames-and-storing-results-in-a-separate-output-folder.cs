using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input and output folders
        string inputFolder = @"C:\InputPngs";
        string outputFolder = @"C:\OutputSvgs";

        try
        {
            // Retrieve all PNG files from the input folder
            string[] pngFiles = Directory.GetFiles(inputFolder, "*.png");

            foreach (string inputPath in pngFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output SVG file path, preserving the original filename
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".svg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure rasterization options for SVG conversion
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Set up SVG save options
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = rasterOptions,
                        Compress = false
                    };

                    // Save the image as SVG
                    image.Save(outputPath, svgOptions);
                }
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}