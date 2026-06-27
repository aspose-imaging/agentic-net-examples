using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample_resized.png";

        // Ensure any runtime exception is reported without crashing
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

            // Load the CorelDRAW (CDR) file
            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                // Resize to 1024x768 pixels (default NearestNeighbourResample)
                image.Resize(1024, 768);

                // Save as PNG using default PNG options
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert a CorelDRAW CDR design into a 1024 × 768 PNG thumbnail for quick preview on a web portal.
 * 2. When an e‑commerce platform must automatically resize uploaded CDR product illustrations to a standard PNG size for consistent catalog display.
 * 3. When a marketing automation script generates PNG assets from CDR files at a fixed resolution to embed in email campaigns.
 * 4. When a desktop application batch‑processes CDR artwork, resizing each to 1024 × 768 pixels and saving as PNG for use in print‑ready PDFs.
 * 5. When a cloud service provides on‑the‑fly conversion of user‑submitted CorelDRAW files to PNG images with a predefined 1024 × 768 resolution for API consumers.
 */