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

            // Hardcoded output directory for GIF files
            string outputDir = @"C:\Temp\GifOutput";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Open the DjVu file as a stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                // Load the DjVu document
                using (DjvuImage djvuImage = new DjvuImage(inputStream))
                {
                    // Iterate through each page in the DjVu document
                    foreach (DjvuPage djvuPage in djvuImage.Pages)
                    {
                        // Build the output file path for the current page
                        string outputPath = Path.Combine(outputDir, $"page_{djvuPage.PageNumber}.gif");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Configure GIF options with interlacing enabled
                        GifOptions gifOptions = new GifOptions
                        {
                            Interlaced = true
                        };

                        // Save the current page as a GIF using the specified options
                        djvuPage.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu document and create web‑friendly interlaced GIFs for faster progressive loading on browsers.
 * 2. When an archival system must convert scanned DjVu files into animated‑compatible GIFs while preserving page order for downstream processing.
 * 3. When a document‑management application wants to generate thumbnail previews of DjVu pages as interlaced GIFs to reduce bandwidth on mobile devices.
 * 4. When a batch‑processing script has to automate the transformation of legacy DjVu manuals into GIF images that support interlacing for smoother display in legacy software.
 * 5. When a digital publishing workflow requires converting DjVu e‑books into individual GIF pages with interlaced encoding to improve visual quality during incremental download.
 */