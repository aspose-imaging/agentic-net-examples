using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input DjVu file path
        string inputPath = @"c:\temp\sample.djvu";
        // Hardcoded output directory for PNG files
        string outputDir = @"c:\temp\output\";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load the DjVu image from the stream
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Iterate through each page in the DjVu document
                    foreach (DjvuPage djvuPage in djvuImage.Pages)
                    {
                        // Build the output file path for the current page
                        string outputPath = Path.Combine(outputDir, $"sample.{djvuPage.PageNumber}.png");

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as a PNG image
                        djvuPage.Save(outputPath, new PngOptions());
                    }
                }
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and store them as separate PNG files for web preview or thumbnail generation.
 * 2. When an archival system must convert scanned DjVu files into lossless PNG images to preserve visual fidelity while enabling downstream image processing.
 * 3. When a document‑management application requires batch conversion of DjVu reports into PNG format so that non‑DjVu‑aware clients can view individual pages.
 * 4. When a C# service automates the creation of printable PNG assets from DjVu manuals, ensuring each page is saved to a designated output folder.
 * 5. When a migration tool needs to read DjVu streams, iterate through pages, and export them as PNG images for integration with other image‑processing pipelines.
 */