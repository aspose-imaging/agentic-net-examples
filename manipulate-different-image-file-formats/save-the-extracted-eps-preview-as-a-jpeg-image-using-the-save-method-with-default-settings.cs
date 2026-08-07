using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.eps";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load EPS image
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                // Retrieve the preview image (default format)
                using (var preview = epsImage.GetPreviewImage())
                {
                    if (preview == null)
                    {
                        Console.Error.WriteLine("No preview image found in the EPS file.");
                        return;
                    }

                    // Save preview as JPEG with default settings
                    preview.Save(outputPath);
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
 * 1. When a web application needs to display a thumbnail of an uploaded EPS logo without rendering the full vector, a developer can extract the EPS preview and save it as a JPEG for fast browser rendering.
 * 2. When generating product catalogs that include vector artwork, a developer can convert the EPS preview to JPEG to embed low‑resolution images in PDF or HTML pages.
 * 3. When building an automated email system that attaches a preview of a designer's EPS file, a developer can use this code to create a JPEG attachment that most email clients can display.
 * 4. When migrating legacy design assets to a content management system that only accepts raster formats, a developer can extract the EPS preview and store it as a JPEG for indexing and search.
 * 5. When creating a batch processing script that validates incoming EPS files by checking their preview images, a developer can save the preview as JPEG to compare against expected visual standards.
 */