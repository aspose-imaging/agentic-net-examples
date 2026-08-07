using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\InputCdrFolder";
        string outputFolder = @"C:\OutputJpgFolder";

        try
        {
            // Get all CDR files in the input folder
            foreach (string cdrFilePath in Directory.GetFiles(inputFolder, "*.cdr"))
            {
                // Verify the input file exists
                if (!File.Exists(cdrFilePath))
                {
                    Console.Error.WriteLine($"File not found: {cdrFilePath}");
                    return;
                }

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(cdrFilePath))
                {
                    int pageIndex = 0;

                    // Iterate through each page of the CDR document
                    foreach (CdrImagePage page in cdrImage.Pages)
                    {
                        // Build the output JPG file path
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(cdrFilePath)}_page{pageIndex}.jpg";
                        string outputPath = Path.Combine(outputFolder, outputFileName);

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as JPG with default options
                        JpegOptions jpegOptions = new JpegOptions(); // default settings
                        page.Save(outputPath, jpegOptions);

                        pageIndex++;
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
 * 1. When a design studio needs to archive legacy CorelDRAW (.cdr) artwork as JPEG thumbnails for quick preview in a web gallery, they can use this code to batch convert each page of the CDR files to JPG images.
 * 2. When an e‑learning platform receives course materials in CDR format and must generate JPEG slides for inclusion in HTML5 presentations, the script automates the conversion of all files in a folder.
 * 3. When a print shop wants to create low‑resolution JPEG proofs of multi‑page CDR documents for client email review, the program iterates through each page and saves them with default JPEG settings.
 * 4. When a document management system needs to index visual content from CDR files by storing JPEG renditions alongside the originals, this C# routine processes the input directory and outputs JPEG files ready for indexing.
 * 5. When a migration project moves assets from CorelDRAW to a cloud‑based image repository that only supports JPG, the code batch converts every CDR file in a directory to JPEG using Aspose.Imaging’s default options.
 */