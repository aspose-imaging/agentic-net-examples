// HOW-TO: Convert Even‑Numbered DjVu Pages To PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "sample.djvu";
            string outputDirectory = "Output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the DjVu document
            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                // Iterate through pages
                for (int i = 0; i < djvuImage.Pages.Length; i++)
                {
                    // Process only even-numbered pages (0‑based index)
                    if (i % 2 == 0)
                    {
                        DjvuPage page = (DjvuPage)djvuImage.Pages[i];
                        string outputPath = Path.Combine(outputDirectory, $"page_{i}.png");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as PNG
                        page.Save(outputPath, new PngOptions());
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
 * 1. When you need to extract only the even pages from a multi‑page DjVu file and save them as separate PNG images for web preview.
 * 2. When an archival system stores scanned documents in DjVu format but the downstream application only processes PNG files from every second page.
 * 3. When generating thumbnails for a digital library and you want to skip odd pages to reduce processing time.
 * 4. When converting a DjVu comic book where only the left‑hand pages (even numbers) should be exported to PNG for printing.
 * 5. When automating a batch job that extracts even‑numbered pages from DjVu reports and stores them in a folder for further analysis.
 */
