using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output directories (relative paths)
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Get all DjVu files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.djvu");

            // Process up to fifteen files
            int count = Math.Min(15, files.Length);
            for (int i = 0; i < count; i++)
            {
                string inputPath = files[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load DjVu document
                using (Image image = Image.Load(inputPath))
                {
                    DjvuImage djvu = (DjvuImage)image;

                    // Process each page
                    foreach (DjvuPage page in djvu.Pages)
                    {
                        // Apply default dithering (Floyd‑Steinberg, 1‑bit)
                        page.Dither(DitheringMethod.FloydSteinbergDithering, 1);

                        // Build output BMP path
                        string outputPath = Path.Combine(
                            outputDirectory,
                            $"{Path.GetFileNameWithoutExtension(inputPath)}_page{page.PageNumber}.bmp");

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save page as BMP
                        page.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to extract up to fifteen pages from DjVu documents and convert each page to a 1‑bit BMP image with default Floyd‑Steinberg dithering for archival or printing purposes.
 * 2. When a batch‑processing tool must read DjVu files from a folder, apply dithering to improve contrast, and generate BMP files that can be opened by legacy Windows applications.
 * 3. When an automated workflow requires converting scanned DjVu manuals into BMP thumbnails for quick preview in a document management system.
 * 4. When a migration script has to transform DjVu graphics into BMP format while preserving page numbers in the file names for later indexing.
 * 5. When a C# application needs to process a limited set of DjVu pages, apply default dithering, and store the results in a designated output directory for further image analysis.
 */