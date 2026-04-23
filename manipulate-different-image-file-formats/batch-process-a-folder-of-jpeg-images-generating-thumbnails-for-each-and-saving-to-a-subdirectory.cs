using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output\\Thumbnails";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all JPEG files (both .jpg and .jpeg) in the input directory
            string[] allFiles = Directory.GetFiles(inputDirectory, "*.*")
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (string inputPath in allFiles)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output file path (same name with _thumb suffix)
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + "_thumb.jpg");

                // Ensure the output subdirectory exists (redundant but satisfies rule)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, resize to thumbnail size, and save
                using (Image image = Image.Load(inputPath))
                {
                    // Resize to 150x150 pixels thumbnail
                    image.Resize(150, 150);
                    // Save the thumbnail as JPEG
                    image.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}