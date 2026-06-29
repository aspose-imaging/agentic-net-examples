using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.djvu";
        string outputDirectory = "Output";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load DjVu document
            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                int pageIndex = 0;
                foreach (Image page in djvuImage.Pages)
                {
                    // Build output path for each page
                    string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.gif");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure GIF options with interlacing enabled
                    GifOptions gifOptions = new GifOptions
                    {
                        Interlaced = true
                    };

                    // Save the page as a GIF image
                    page.Save(outputPath, gifOptions);

                    pageIndex++;
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and save them as interlaced GIFs for faster progressive loading on web pages.
 * 2. When an archival system must convert scanned DjVu files into GIF format while preserving page order and enabling interlacing to reduce perceived loading time in browsers.
 * 3. When a digital publishing workflow requires batch processing of DjVu e‑books into GIF images with interlaced encoding for compatibility with legacy image viewers.
 * 4. When a C# application has to validate the existence of a DjVu source file, create an output folder, and programmatically generate GIF thumbnails of each page with Aspose.Imaging.
 * 5. When a developer wants to automate the conversion of DjVu pages to GIF files with custom GifOptions, such as enabling interlacing, to integrate into a document‑to‑image conversion pipeline.
 */