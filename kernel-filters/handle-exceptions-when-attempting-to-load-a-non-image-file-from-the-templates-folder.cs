using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"templates/sample.txt";          // non‑image file for testing
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

            // Attempt to load the file as an image
            try
            {
                using (Image image = Image.Load(inputPath))
                {
                    // If loading succeeds, save the image to the output path
                    image.Save(outputPath);
                    Console.WriteLine($"Image saved to {outputPath}");
                }
            }
            catch (ImageLoadException ile)
            {
                // Specific handling for non‑image files
                Console.Error.WriteLine($"Unable to load image: {ile.Message}");
            }
            catch (Exception ex)
            {
                // General loading errors
                Console.Error.WriteLine($"Error loading image: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            // Catch any unexpected runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application processes user‑uploaded files from a “templates” folder and must ensure each file is a valid image before converting it to PNG, this code catches ImageLoadException for unsupported formats like .txt.
 * 2. When an automated batch job scans template resources on a shared drive and needs to skip non‑image documents without crashing the service, the nested try‑catch gracefully handles .txt or .pdf files.
 * 3. When a desktop utility generates thumbnails from a set of template assets and wants to log a clear error if a resource is a plain text file rather than a JPEG or BMP, this pattern provides specific exception handling.
 * 4. When a CI/CD pipeline validates that all assets in the “templates” directory are proper image files before publishing a product, the code detects and reports non‑image files such as .txt to prevent build failures.
 * 5. When a cloud‑based image conversion API reads configuration files from a templates folder and must return a user‑friendly error when the file is not an image, the ImageLoadException catch block supplies the necessary feedback.
 */