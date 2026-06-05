using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input DjVu file path
            string inputPath = @"C:\Temp\sample.djvu";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the DjVu file stream
            using (Stream inputStream = File.OpenRead(inputPath))
            {
                // Load DjVu image from the stream
                using (DjvuImage djvuImage = new DjvuImage(inputStream))
                {
                    int pageNumber = 1;
                    foreach (var page in djvuImage.Pages)
                    {
                        // Construct output path for each page
                        string outputPath = $@"C:\Temp\output_page_{pageNumber}.gif";

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Configure GIF options with interlacing enabled
                        GifOptions gifOptions = new GifOptions
                        {
                            Interlaced = true
                        };

                        // Save the current page as a GIF file
                        page.Save(outputPath, gifOptions);

                        pageNumber++;
                    }
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and create web‑friendly interlaced GIFs for faster progressive loading in browsers.
 * 2. When an archival system must convert scanned DjVu files into GIF animations while preserving page order and ensuring the output files are stored in a specific folder structure.
 * 3. When a document‑management application requires on‑the‑fly conversion of DjVu pages to interlaced GIFs to generate thumbnails that load incrementally for low‑bandwidth users.
 * 4. When a batch‑processing tool has to read DjVu streams, apply custom GifOptions such as Interlaced = true, and save each page as a separate GIF for downstream image‑processing pipelines.
 * 5. When a C# service needs to validate the existence of a DjVu source file, load it via Aspose.Imaging, and produce interlaced GIFs per page to meet client‑side animation standards.
 */