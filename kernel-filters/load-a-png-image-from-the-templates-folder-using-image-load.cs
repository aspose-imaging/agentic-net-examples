using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "templates/sample.png";
            string outputPath = "output/sample_copy.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Save the loaded image to the output path
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
 * 1. When a web application needs to duplicate a product badge PNG from a templates directory to a user‑specific output folder before adding dynamic text.
 * 2. When an automated build script copies a logo PNG from the shared templates folder to the deployment package to ensure the correct image version is included.
 * 3. When a desktop utility loads a placeholder PNG template, validates its existence, and saves a backup copy in an output folder for later editing.
 * 4. When a reporting tool reads a PNG chart template, loads it with Aspose.Imaging, and writes a copy to a temporary directory for further chart rendering.
 * 5. When a batch process verifies that a PNG watermark file exists in the templates folder, loads it, and saves a duplicate in the output folder to be applied to multiple documents.
 */