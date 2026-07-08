using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.emf";
            string outputPath = @"C:\Images\output\log.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image image = Image.Load(inputPath))
            {
                EmfImage emf = image as EmfImage;
                if (emf == null)
                {
                    Console.Error.WriteLine("The loaded file is not an EMF image.");
                    return;
                }

                // Retrieve dimensions
                int width = emf.Width;
                int height = emf.Height;

                // Log dimensions to console
                Console.WriteLine($"Width: {width}");
                Console.WriteLine($"Height: {height}");

                // Optionally write dimensions to an output file
                File.WriteAllText(outputPath, $"Width: {width}{Environment.NewLine}Height: {height}");
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
 * 1. When a desktop publishing application needs to verify that an imported EMF logo fits within a predefined layout, it can use this code to read the image’s width and height and log the values for further layout calculations.
 * 2. When a batch conversion tool processes a folder of EMF diagrams and must decide whether to rasterize or keep them vector, it can retrieve the dimensions to determine if the image exceeds the target resolution limits.
 * 3. When a reporting system generates PDF reports that embed EMF charts, it can extract the dimensions to scale the chart appropriately and record the size in a log file for audit purposes.
 * 4. When a quality‑control script checks incoming EMF assets from a design team, it can read the width and height to ensure they meet the company’s size standards and write the results to a text file for review.
 * 5. When an automated build pipeline validates UI assets, it can load each EMF file, obtain its dimensions, and log them to verify that icons and illustrations conform to the required pixel dimensions before deployment.
 */