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
 * 1. When a document management system needs to display individual pages of a multi‑page DjVu archive as PNG thumbnails for web preview, a developer can use this code to extract and save each page as a separate PNG file.
 * 2. When an archival workflow requires converting scanned DjVu files into lossless PNG images for long‑term preservation or further processing in image‑editing tools, this snippet provides the necessary page‑by‑page conversion.
 * 3. When a batch‑processing service must generate printable PNG assets from DjVu manuals so that downstream printing pipelines that only accept PNG can consume them, the code can be integrated to automate the conversion.
 * 4. When a mobile app backend has to serve DjVu content as PNG images to devices that lack DjVu rendering support, developers can employ this routine to pre‑render each page into PNG files.
 * 5. When a data‑extraction pipeline needs to run OCR on each page of a DjVu document, the developer can first convert every page to PNG using this code, then feed the PNGs into an OCR engine.
 */