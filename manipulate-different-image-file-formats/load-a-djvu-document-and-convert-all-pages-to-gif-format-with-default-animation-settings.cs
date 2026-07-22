using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.djvu";
        string outputDirectory = @"C:\temp\output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (CreateDirectory works even if the directory already exists)
            Directory.CreateDirectory(outputDirectory);

            // Load the DjVu document from the file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
            {
                // Iterate through each page and save as GIF
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDirectory, $"sample.{page.PageNumber}.gif");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page using default GIF options
                    page.Save(outputPath, new GifOptions());
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and generate lightweight GIF images for web preview or thumbnail galleries.
 * 2. When an application must batch‑process scanned archival DjVu files and produce animated GIFs that can be displayed in browsers without requiring DjVu plugins.
 * 3. When a document management system requires converting DjVu pages to GIF format to embed them in email newsletters or social media posts.
 * 4. When a digital publishing workflow needs to create GIF assets from DjVu source files for inclusion in e‑learning modules that only support GIF images.
 * 5. When a developer wants to automate the conversion of DjVu pages to GIFs on a server using C# streams and default GifOptions for consistent image quality.
 */