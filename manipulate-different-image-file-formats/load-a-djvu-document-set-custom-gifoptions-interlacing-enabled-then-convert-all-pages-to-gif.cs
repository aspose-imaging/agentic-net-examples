// HOW-TO: Convert DjVu Pages to Interlaced GIF Images in C# (Aspose.Imaging for .NET)
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
        string inputPath = @"C:\temp\sample.djvu";
        string outputDir = @"C:\temp\output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the DjVu document from a file stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(inputStream))
            {
                // Iterate through each page and save as an interlaced GIF
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    string outputPath = Path.Combine(outputDir, $"page{page.PageNumber}.gif");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure GIF options with interlacing enabled
                    GifOptions gifOptions = new GifOptions
                    {
                        Interlaced = true
                    };

                    // Save the current page as a GIF file
                    page.Save(outputPath, gifOptions);
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
 * 1. When you need to extract each page of a multi‑page DjVu document and save them as web‑friendly interlaced GIFs for faster progressive loading.
 * 2. When generating thumbnail previews of DjVu files for a web gallery that requires GIF format with interlacing to improve perceived load time.
 * 3. When converting scanned archival DjVu files into GIF images for legacy applications that only support GIF and benefit from interlaced rendering.
 * 4. When creating a batch process that reads DjVu reports and outputs each page as an interlaced GIF to be embedded in email newsletters.
 * 5. When preparing DjVu e‑books for platforms that accept only GIF images, ensuring each page is saved with interlacing to reduce bandwidth usage.
 */
