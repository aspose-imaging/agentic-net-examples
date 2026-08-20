// HOW-TO: Batch Resize BMP Images to 1024x768 and Convert to SVG in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all BMP files in the input folder
            string[] bmpFiles = Directory.GetFiles(inputFolder, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Resize to 1024x768 using the default resampling method
                    image.Resize(1024, 768);

                    // Prepare the output SVG file path
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".svg");

                    // Ensure the output directory exists (unconditional as required)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Set up SVG rasterization options based on the resized image size
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Configure SVG save options
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Save the resized image as SVG
                    image.Save(outputPath, svgOptions);
                }
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
 * 1. When you need to prepare a large collection of legacy BMP graphics for web display by resizing them to a standard 1024x768 resolution and converting them to lightweight SVG files.
 * 2. When an application must automatically generate scalable vector versions of scanned BMP assets for responsive UI components without manual editing.
 * 3. When a migration script has to process thousands of BMP files in a folder, normalize their dimensions, and output SVGs for use in modern design tools.
 * 4. When a reporting tool requires all input bitmap charts to be resized and stored as SVG to ensure crisp rendering at any zoom level.
 * 5. When a CI/CD pipeline needs to validate image assets by batch converting BMPs to SVG after resizing them to a fixed size for quality checks.
 */
