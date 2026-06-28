using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\sample.cdr";
        string outputPath = @"C:\temp\sample.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CorelDRAW file
            using (Image image = Image.Load(inputPath))
            {
                // Use default PNG options
                var pngOptions = new PngOptions();

                // Save the image as PNG
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a CorelDRAW (CDR) design into a web‑friendly PNG thumbnail for an e‑commerce product catalog using Aspose.Imaging in C#.
 * 2. When an automated build script must generate PNG previews of CDR files to embed in documentation or release notes without manual editing.
 * 3. When a desktop application imports user‑provided CorelDRAW artwork and saves it as a PNG image for printing or sharing via email.
 * 4. When a server‑side API receives a CDR file upload and must return a PNG version for display in a browser, leveraging Aspose.Imaging’s default PNG options.
 * 5. When a migration tool processes legacy CorelDRAW assets and converts them to PNG format for storage in a cloud‑based image repository.
 */