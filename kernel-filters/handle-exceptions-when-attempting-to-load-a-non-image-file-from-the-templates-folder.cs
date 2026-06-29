using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"templates/nonimage.txt";
        string outputPath = @"output/result.png";

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

            // Check if the file can be loaded as an image
            if (!Image.CanLoad(inputPath))
            {
                Console.Error.WriteLine($"Cannot load image: {inputPath}");
                return;
            }

            // Attempt to load the image and handle load exceptions
            try
            {
                using (Image image = Image.Load(inputPath))
                {
                    // Perform any desired processing here (none in this example)

                    // Save the image to the output path
                    image.Save(outputPath);
                }
            }
            catch (ImageLoadException ile)
            {
                Console.Error.WriteLine($"Image load error: {ile.Message}");
                return;
            }
            catch (ImageException ie) // Catch other Aspose.Imaging related exceptions
            {
                Console.Error.WriteLine($"Aspose.Imaging error: {ie.Message}");
                return;
            }
        }
        catch (Exception ex)
        {
            // Catch any unexpected exceptions
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to validate user‑uploaded files in a C# web application and ensure only supported image formats (e.g., JPEG, PNG, BMP) are processed, this code detects non‑image files in the templates folder and logs a clear error.
 * 2. When building an automated batch‑conversion tool that reads files from a templates directory and saves them as PNG, the code prevents runtime crashes by checking Image.CanLoad before attempting to load unsupported text or PDF files.
 * 3. When integrating Aspose.Imaging into a Windows service that monitors a folder for new assets, the example shows how to gracefully handle ImageLoadException if a stray non‑image file appears, keeping the service running.
 * 4. When creating a desktop utility that allows users to select a source file and generate a thumbnail, the code demonstrates how to verify the file exists, confirm it is an image, and catch any Aspose.Imaging‑specific errors before saving the result.
 * 5. When developing a CI/CD pipeline that validates image resources in a repository, this snippet can be used to programmatically reject non‑image files in the templates folder and provide actionable error messages for developers.
 */