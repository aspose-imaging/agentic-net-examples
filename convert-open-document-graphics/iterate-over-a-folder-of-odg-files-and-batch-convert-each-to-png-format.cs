// HOW-TO: Batch Convert ODG Files to PNG in C# with Aspose Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OdgBatchConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output folder paths
                string inputFolder = @"C:\OdgInput";
                string outputFolder = @"C:\PngOutput";

                // Ensure the output folder exists
                Directory.CreateDirectory(outputFolder);

                // Get all ODG files in the input folder
                string[] odgFiles = Directory.GetFiles(inputFolder, "*.odg");

                foreach (string inputPath in odgFiles)
                {
                    // Verify the input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Determine the output PNG path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                    string outputPath = Path.Combine(outputFolder, outputFileName);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load the ODG image and save as PNG
                    using (Image image = Image.Load(inputPath))
                    {
                        var pngOptions = new PngOptions();
                        image.Save(outputPath, pngOptions);
                    }

                    Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically transform a collection of OpenDocument graphics (ODG) drawings into web‑friendly PNG images for a website or documentation portal.
 * 2. When you want to migrate legacy ODG assets stored in a shared folder to PNG format for use in mobile apps that only support raster images.
 * 3. When a batch processing job must generate PNG thumbnails from ODG files before uploading them to a cloud storage service.
 * 4. When an integration script has to convert user‑submitted ODG diagrams to PNG on the server side for preview in a .NET web application.
 * 5. When you are building a migration tool that consolidates design files by converting all ODG files in a directory to PNG for archival purposes.
 */
