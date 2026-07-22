using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample_resized.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Load the CorelDRAW (CDR) file
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 1024x768 pixels using the default resampling method
                image.Resize(1024, 768);

                // Prepare PNG save options (default options are sufficient)
                var pngOptions = new PngOptions();

                // Save the resized image as PNG
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a CorelDRAW CDR design into a web‑friendly PNG thumbnail of 1024 × 768 pixels for preview in a browser.
 * 2. When an automated build script must batch‑process CDR files and generate uniformly sized PNG assets for a mobile app’s asset pipeline.
 * 3. When a content management system imports user‑uploaded CDR artwork and must resize it to a standard resolution before storing it as PNG for fast delivery.
 * 4. When a reporting tool extracts vector graphics from CorelDRAW files and creates PNG charts at 1024 × 768 to embed in PDF reports.
 * 5. When a cloud service receives CDR files via API and needs to resize and convert them to PNG on the fly for downstream image‑analysis workflows.
 */