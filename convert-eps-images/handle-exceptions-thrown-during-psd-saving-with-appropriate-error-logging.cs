// HOW-TO: How To Convert JPEG To PSD With Error Handling In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace PsdsaveExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output paths
                string inputPath = "input.jpg";
                string outputPath = "output.psd";

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare PSD options
                    var psdOptions = new PsdOptions();

                    // Save as PSD with error handling
                    try
                    {
                        image.Save(outputPath, psdOptions);
                    }
                    catch (Exception saveEx)
                    {
                        Console.Error.WriteLine($"Error saving PSD: {saveEx.Message}");
                        return;
                    }
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
 * 1. When you need to programmatically transform user‑uploaded JPEG photos into layered PSD files while ensuring missing files are reported.
 * 2. When an automated batch job must save images as Photoshop files and log any failures without crashing the service.
 * 3. When a web API receives image paths and must create PSD output, creating the target folder if it does not exist.
 * 4. When integrating Aspose.Imaging into a desktop application that requires graceful handling of save errors to display meaningful messages to users.
 * 5. When building a migration tool that converts legacy JPEG assets to PSD format and needs robust exception handling for file‑system and library errors.
 */
