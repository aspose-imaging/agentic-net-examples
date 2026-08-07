using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\input\sample.cdr";
        string outputPath = @"C:\output\sample.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Ensure the document has at least one page
                if (cdrImage.PageCount == 0)
                {
                    Console.Error.WriteLine("The CDR file contains no pages.");
                    return;
                }

                // Get the first (single) page
                CdrImagePage page = (CdrImagePage)cdrImage.Pages[0];
                page.CacheData(); // optional caching for performance

                // Set high‑quality JPEG options
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 100 // maximum quality
                };

                // Save the page as JPEG
                page.Save(outputPath, jpegOptions);
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
 * 1. When a design studio needs to generate a high‑resolution preview image of a single‑page CorelDRAW (CDR) artwork for a web gallery, they can use this C# code to load the CDR file and export it as a 100‑quality JPEG.
 * 2. When an e‑commerce platform receives product illustrations in CDR format and must display them as JPEG thumbnails on product pages, the code converts the first page of the CDR to a high‑quality JPEG automatically.
 * 3. When a document management system archives legacy CDR drawings and requires a JPEG snapshot for quick visual search, developers can employ this snippet to read the CDR and save the first page as a high‑quality JPEG image.
 * 4. When a marketing automation tool needs to embed a CorelDRAW logo into email campaigns, the code loads the single‑page CDR and outputs a lossless‑quality JPEG ready for email clients.
 * 5. When a desktop application offers an “Export as JPEG” feature for users working with single‑page CDR files, this C# example provides the exact steps to load the file, set JPEG quality to 100, and save the result.
 */