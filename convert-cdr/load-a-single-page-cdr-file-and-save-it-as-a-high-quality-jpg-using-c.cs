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
            string outputPath = @"C:\Images\output.jpg";

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
                // Cache the whole image data
                cdrImage.CacheData();

                // Access the first (and only) page
                var page = (Aspose.Imaging.FileFormats.Cdr.CdrImagePage)cdrImage.Pages[0];
                page.CacheData();

                // Set high‑quality JPEG options
                var jpegOptions = new JpegOptions
                {
                    Quality = 100
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
 * 1. When a developer needs to convert a CorelDRAW (CDR) illustration into a high‑resolution JPEG for web preview or email attachment, they can use this code to load the single‑page CDR and save it with maximum quality.
 * 2. When integrating a document management system that stores design assets in CDR format, the code enables automatic generation of JPEG thumbnails for quick browsing.
 * 3. When building a batch‑processing tool that extracts the first page of a CDR file and creates a print‑ready JPEG for marketing material, this snippet provides the necessary loading and saving steps.
 * 4. When a legacy graphics workflow requires converting legacy CDR files to a universally supported JPEG format for archival in a .NET application, the example shows how to perform the conversion with Aspose.Imaging.
 * 5. When a desktop application must validate that a CDR file can be rendered correctly by converting it to a high‑quality JPEG before further processing, this code demonstrates the required C# operations.
 */