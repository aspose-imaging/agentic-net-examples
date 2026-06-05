using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.djvu";
        string outputDirectory = "output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the DjVu document from a file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
            {
                int pageIndex = 0;
                // Iterate through each page and save it as a GIF
                foreach (var djvuPage in djvuImage.Pages)
                {
                    pageIndex++;
                    string outputPath = Path.Combine(outputDirectory, $"page{pageIndex}.gif");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page using default GIF options (default animation settings)
                    djvuPage.Save(outputPath, new GifOptions());
                }
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu e‑book and create animated GIF previews for a web catalog.
 * 2. When an archival system must convert scanned DjVu documents into lightweight GIF files for quick thumbnail generation in a C# application.
 * 3. When a document‑management workflow requires batch processing of DjVu reports into GIF animations to embed in email newsletters.
 * 4. When a mobile app backend has to serve DjVu lecture slides as GIFs to devices that only support GIF animation.
 * 5. When a content‑migration tool needs to read DjVu files and output each page as a GIF with default animation settings for compatibility with legacy image viewers.
 */