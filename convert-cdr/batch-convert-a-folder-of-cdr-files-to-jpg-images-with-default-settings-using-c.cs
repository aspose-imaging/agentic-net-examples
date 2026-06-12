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
        string inputFolder = @"C:\InputCdr";
        string outputFolder = @"C:\OutputJpg";

        try
        {
            // Get all CDR files in the input folder
            string[] cdrFiles = Directory.GetFiles(inputFolder, "*.cdr");

            foreach (string inputPath in cdrFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output JPG file path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".jpg";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the CDR image and save it as JPG using default options
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    JpegOptions jpegOptions = new JpegOptions(); // default settings
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
 * 1. When a graphic design studio needs to automatically convert a large collection of CorelDRAW (CDR) source files into web‑ready JPEG images for client review, they can use this C# batch conversion code.
 * 2. When a document management system must archive legacy CDR drawings as compressed JPG thumbnails without manually opening each file, the Aspose.Imaging C# routine provides a fast, default‑settings conversion.
 * 3. When an e‑learning platform wants to generate JPEG slides from a folder of CDR lesson assets to embed in HTML courses, the code automates the C# file‑system iteration and image saving.
 * 4. When a print shop receives batch orders containing CDR artwork and needs to preview them as JPEGs on a Windows server, this C# script processes the entire input directory in one go.
 * 5. When a migration tool needs to move design assets from CorelDRAW format to a universally supported image format before uploading to a cloud storage service, the Aspose.Imaging C# example handles the bulk conversion with minimal configuration.
 */