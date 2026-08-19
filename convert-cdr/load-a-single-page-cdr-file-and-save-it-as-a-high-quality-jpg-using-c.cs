// HOW-TO: Convert Single‑Page CDR to High‑Quality JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\sample.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Cache data to avoid further stream reads
                cdrImage.CacheData();

                // Get the first (and only) page
                var page = (CdrImagePage)cdrImage.Pages[0];

                // Configure high‑quality JPEG options
                var jpegOptions = new JpegOptions
                {
                    Quality = 100 // maximum quality
                };

                // Save the page as a JPEG file
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
 * 1. When a developer needs to generate a high‑resolution JPEG preview of a CorelDRAW (CDR) design for web or print use.
 * 2. When an application must convert legacy single‑page CDR files to JPEG format for inclusion in a photo gallery or CMS.
 * 3. When a reporting system requires embedding a high‑quality image of a CDR page into PDF or Word documents.
 * 4. When a digital asset management workflow needs to create thumbnail JPEGs from single‑page CDR artwork automatically.
 * 5. When a client wants to export a CorelDRAW illustration as a maximum‑quality JPEG for marketing or presentation materials.
 */
