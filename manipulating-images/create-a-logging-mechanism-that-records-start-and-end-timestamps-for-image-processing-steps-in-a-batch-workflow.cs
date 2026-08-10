// HOW-TO: Log Start and End Timestamps for Batch Image Conversion to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Simple logger that records timestamps for each step
    static void Log(string message)
    {
        Console.WriteLine($"{DateTime.Now:O} - {message}");
    }

    static void Main()
    {
        try
        {
            // Hardcoded input files (replace with actual existing files)
            string[] inputPaths = new string[]
            {
                @"C:\Images\input1.jpg",
                @"C:\Images\input2.png"
            };

            // Hardcoded output directory
            string outputDirectory = @"C:\Images\Processed";

            // Ensure the base output directory exists (rule 3)
            Directory.CreateDirectory(outputDirectory);

            foreach (string inputPath in inputPaths)
            {
                // Rule 2: verify input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Log($"Start processing {inputPath}");

                // Load the image using Aspose.Imaging (lifecycle rule)
                using (Image image = Image.Load(inputPath))
                {
                    // Determine output file path (convert to PNG)
                    string outputPath = Path.Combine(
                        outputDirectory,
                        Path.GetFileNameWithoutExtension(inputPath) + ".png");

                    // Rule 3: ensure output directory exists before saving
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image as PNG (lifecycle rule)
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
                }

                Log($"Finished processing {inputPath}");
            }
        }
        catch (Exception ex)
        {
            // Rule 4: catch any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to track how long each image takes to convert from JPEG or PNG to PNG in a batch process for performance monitoring.
 * 2. When you want to ensure that missing input files are detected early and logged before processing begins.
 * 3. When you require automatic creation of output folders so that saved PNG files are stored without manual directory setup.
 * 4. When you need a simple console logger that records precise ISO 8601 timestamps for debugging and audit trails in image pipelines.
 * 5. When you are building a .NET service that processes multiple images and must record start and finish times for each file to generate processing reports.
 */
