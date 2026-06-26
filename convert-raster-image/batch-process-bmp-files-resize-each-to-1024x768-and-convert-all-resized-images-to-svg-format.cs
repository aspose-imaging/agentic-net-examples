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

            // Get all BMP files in the input folder
            string[] bmpFiles = Directory.GetFiles(inputFolder, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Resize to 1024x768 using the default resampling method
                    image.Resize(1024, 768);

                    // Prepare output SVG path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".svg";
                    string outputPath = Path.Combine(outputFolder, outputFileName);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Set up SVG save options
                    SvgOptions svgOptions = new SvgOptions();

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
 * 1. When a developer needs to migrate a legacy collection of BMP screenshots to scalable SVG graphics for a web portal, resizing them to a uniform 1024x768 resolution.
 * 2. When an automated build pipeline must generate optimized SVG assets from a folder of BMP icons, ensuring each icon fits a 1024x768 canvas before deployment.
 * 3. When a desktop application must batch‑process user‑uploaded BMP photos, resize them to a standard size, and store them as SVG files for vector‑based printing.
 * 4. When a content management system requires converting archived BMP diagrams into SVG format while normalizing their dimensions to 1024x768 for consistent display across devices.
 * 5. When a data‑migration script needs to read BMP files from a network share, resize them to 1024x768, and save them as SVG files in a new directory using Aspose.Imaging for .NET.
 */