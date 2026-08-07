using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"templates\sample.txt";
        string outputPath = @"output\result.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Attempt to load the file as an image
            Image image;
            try
            {
                image = Image.Load(inputPath);
            }
            catch (ImageLoadException ile)
            {
                // Handle non‑image file scenario
                Console.Error.WriteLine($"Unable to load image: {ile.Message}");
                return;
            }

            // Save the loaded image to the output path (as PNG)
            image.Save(outputPath);
            image.Dispose();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application generates thumbnails from user‑uploaded files and must skip or log .txt files placed in the templates folder.
 * 2. When an automated report generator reads template assets and needs to gracefully handle accidental inclusion of non‑image documents such as PDFs or Word files.
 * 3. When a desktop utility converts batch images to PNG and must verify that each entry in the templates directory is a supported image format before processing.
 * 4. When a CI/CD pipeline validates image resources in a project and should capture ImageLoadException for any corrupted or unsupported image files.
 * 5. When a background service monitors a shared folder for new graphics and must prevent runtime crashes by catching errors when a plain text file is encountered.
 */