// HOW-TO: Convert CMX to PNG or Any Format Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input CMX file path
            string inputPath = "sample.cmx";

            // Hardcoded output file path (extension determines format)
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image using default load options
            using (CmxImage image = (CmxImage)Image.Load(inputPath, new CmxLoadOptions()))
            {
                // Save the image; format is inferred from the output file extension
                image.Save(outputPath);
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
 * 1. When you need to batch‑convert legacy Corel CMX drawings to PNG for web display.
 * 2. When an automated build script must transform CMX assets into JPEG or BMP for mobile apps.
 * 3. When a migration tool extracts CMX diagrams and saves them in a format supported by modern editors.
 * 4. When a server‑side service receives a CMX file path and must deliver a thumbnail in PNG.
 * 5. When a desktop utility lets users choose an output format (PNG, TIFF, GIF) for a CMX source file.
 */
