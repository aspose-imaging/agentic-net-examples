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
                    // Build output file name with timestamp
                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string baseName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, $"{baseName}_{timestamp}.jpg");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as JPEG
                    JpegOptions jpegOptions = new JpegOptions();
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
 * 1. When a graphic design studio needs to archive dozens of CorelDRAW (CDR) illustrations as JPEG thumbnails with unique timestamps for version tracking, they can use this C# batch conversion code.
 * 2. When an e‑commerce platform must automatically generate web‑ready JPEG product images from a folder of CDR files and ensure each file name includes a timestamp to avoid cache conflicts, this script provides the solution.
 * 3. When a document management system requires periodic conversion of submitted CDR artwork into JPEG format for previewing in browsers, and wants each preview file to be uniquely named with the original name plus a timestamp, the code handles it.
 * 4. When a marketing team wants to create a time‑stamped backup of all CDR assets by converting them to JPEGs in a single operation using C# and Aspose.Imaging, this example automates the process.
 * 5. When a cloud‑based image processing pipeline needs to ingest a batch of CDR files, convert them to JPEG, and store them with timestamped filenames to prevent overwriting, the provided code can be integrated.
 */