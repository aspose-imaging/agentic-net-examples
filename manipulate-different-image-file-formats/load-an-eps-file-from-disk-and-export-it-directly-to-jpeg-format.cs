using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.eps";
        string outputPath = @"C:\Images\sample.jpg";

        try
        {
            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EPS image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare JPEG export options (default settings)
                var jpegOptions = new JpegOptions();

                // Save the image as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer must convert a vector EPS file stored on disk into a web‑ready JPEG image using C# and Aspose.Imaging for quick preview or publishing.
 * 2. When an automated build script needs to batch‑process EPS logos from a source directory and generate JPEG thumbnails for a content management system.
 * 3. When a desktop application requires on‑the‑fly conversion of user‑uploaded EPS graphics to JPEG format to display them in a Windows Forms UI.
 * 4. When a server‑side service validates the existence of an EPS asset, creates the necessary output folder, and saves the image as JPEG for downstream image‑processing pipelines.
 * 5. When a troubleshooting tool logs errors while loading an EPS file and attempts to export it to JPEG to verify that the Aspose.Imaging conversion pipeline is functioning correctly.
 */