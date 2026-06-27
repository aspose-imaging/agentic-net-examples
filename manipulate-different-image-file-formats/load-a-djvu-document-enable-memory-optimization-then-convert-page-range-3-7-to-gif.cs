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
        string inputPath = "input.djvu";
        string outputFolder = "output";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputFolder);

        try
        {
            // Enable memory optimization via LoadOptions (e.g., 1 MB buffer)
            LoadOptions loadOptions = new LoadOptions
            {
                BufferSizeHint = 1 * 1024 * 1024 // 1 MB
            };

            // Open the DjVu file stream
            using (FileStream stream = File.OpenRead(inputPath))
            // Load DjVu image with memory optimization
            using (DjvuImage djvuImage = new DjvuImage(stream, loadOptions))
            {
                // Iterate through pages and convert pages 3‑7 to GIF
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    int pageNumber = page.PageNumber;
                    if (pageNumber >= 3 && pageNumber <= 7)
                    {
                        string outputPath = Path.Combine(outputFolder, $"page{pageNumber}.gif");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as GIF
                        page.Save(outputPath, new GifOptions());
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
 * 1. When a developer needs to extract a subset of pages (e.g., pages 3‑7) from a large DjVu document and save them as lightweight GIF images while keeping memory usage low.
 * 2. When an application processes scanned books in DjVu format and must generate static GIF previews for specific chapters without loading the entire file into memory.
 * 3. When a web service converts selected DjVu pages to GIF for thumbnail generation, using C# LoadOptions to limit buffer size and avoid out‑of‑memory errors.
 * 4. When a digital archiving tool needs to batch‑export a range of DjVu pages to GIF for compatibility with legacy systems, employing Aspose.Imaging’s memory‑optimized loading.
 * 5. When a desktop utility extracts pages 3‑7 from a multi‑page DjVu file and saves them as GIF files for easy sharing, while ensuring the process runs efficiently on low‑RAM machines.
 */