using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputCdr";
        string outputDirectory = @"C:\OutputJpg";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all CDR files in the input directory
            string[] cdrFiles = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (string inputPath in cdrFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Cache all pages to avoid repeated loading
                    cdrImage.CacheData();
                    foreach (CdrImagePage page in cdrImage.Pages)
                    {
                        page.CacheData();
                    }

                    // Determine base filename without extension
                    string baseFileName = Path.GetFileNameWithoutExtension(inputPath);

                    // Timestamp for unique naming
                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                    // Construct output file path
                    string outputPath = Path.Combine(outputDirectory, $"{baseFileName}_{timestamp}.jpg");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Set JPEG save options
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 90
                    };

                    // Save the first page (or the whole image if single-page) as JPEG
                    // If the CDR has multiple pages, each will be saved as a separate JPEG with the same timestamp
                    // Here we save the whole image; Aspose.Imaging will rasterize the vector content.
                    cdrImage.Save(outputPath, jpegOptions);
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
 * 1. When a design studio needs to archive multiple CorelDRAW (.cdr) illustrations as JPEG thumbnails for quick preview in a web gallery, they can use this code to batch convert and timestamp each file.
 * 2. When an automated build pipeline must generate JPEG assets from CDR source files for inclusion in a mobile app, the script provides a C# solution that processes all files in a folder and creates uniquely named images.
 * 3. When a document management system requires versioned image exports of CDR drawings to preserve the exact time of conversion, developers can employ this code to add a timestamp to each JPEG filename.
 * 4. When a marketing team wants to bulk export client‑provided CDR logos into web‑ready JPEGs while ensuring no filename collisions, the batch converter in C# handles the conversion and timestamp naming automatically.
 * 5. When a cloud‑based image processing service needs to ingest a batch of CDR files and store them as JPEGs with traceable timestamps for audit logs, this code offers a straightforward way to perform the conversion in .NET.
 */