using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        try
        {
            // Get all BMP files in the input folder
            string[] bmpFiles = Directory.GetFiles(inputFolder, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PNG path preserving the original filename
                string outputPath = Path.Combine(
                    outputFolder,
                    Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image and save it as PNG
                using (Image image = Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to migrate a legacy collection of BMP assets to PNG for web delivery while keeping the original filenames, this batch conversion code can automate the process.
 * 2. When an automated build pipeline must generate PNG thumbnails from BMP source files stored in a folder, the script provides a C# solution using Aspose.Imaging.
 * 3. When a desktop application must replace BMP images with lossless PNG equivalents to reduce file size and improve compatibility across browsers, the code performs the required conversion.
 * 4. When a migration tool has to process dozens of BMP files in a directory and output PNG files to a separate folder without manual intervention, this example shows how to achieve it with Aspose.Imaging.ImageOptions.
 * 5. When a server‑side service needs to validate that each BMP file exists before converting it to PNG and preserving the original name, the provided C# routine handles the verification and saving steps.
 */