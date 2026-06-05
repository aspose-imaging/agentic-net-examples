using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Default input and output paths
        string inputPath = "input.pdf";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Load the source image
            using (Image sourceImage = Image.Load(inputPath))
            {
                try
                {
                    // Attempt to create a Graphics object (may fail for unsupported formats)
                    Graphics graphics = new Graphics(sourceImage);
                    // Example drawing operation
                    graphics.Clear(Color.White);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Graphics creation failed: {ex.Message}");
                }

                // Save the image as PNG
                Source pngSource = new FileCreateSource(outputPath, false);
                PngOptions pngOptions = new PngOptions { Source = pngSource };
                sourceImage.Save(outputPath, pngOptions);
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
 * 1. When a web service receives user‑uploaded PDF files and must convert them to PNG thumbnails, the code ensures that unsupported image formats are caught before attempting to draw on the page.
 * 2. When an automated batch job processes a mixed folder of image and document files, the error handling prevents crashes if a file like a TIFF or BMP cannot be used to create a Graphics object.
 * 3. When a desktop application lets users edit scanned documents, the try‑catch around Graphics creation alerts the user if the scanned PDF cannot be rendered for drawing operations.
 * 4. When a cloud function generates preview images for email attachments, the code safely logs and skips files that Aspose.Imaging does not support for graphics manipulation.
 * 5. When a CI/CD pipeline validates image assets before deployment, the exception handling captures unsupported formats early, allowing the build to continue without interruption.
 */