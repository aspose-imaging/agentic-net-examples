using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories relative to the current directory
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all JPEG files in the input directory
        string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg");
        if (jpegFiles.Length == 0)
        {
            Console.WriteLine("No JPEG files found in the input directory.");
            return;
        }

        // Prepare a list to hold temporary JPEG2000 files
        List<string> jp2TempFiles = new List<string>();

        // Convert each JPEG to JPEG2000 and store temporarily
        foreach (string jpegPath in jpegFiles)
        {
            if (!File.Exists(jpegPath))
            {
                Console.Error.WriteLine($"File not found: {jpegPath}");
                return;
            }

            string tempJp2Path = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(jpegPath) + ".jp2");
            Directory.CreateDirectory(Path.GetDirectoryName(tempJp2Path));

            using (Image jpegImage = Image.Load(jpegPath))
            {
                Jpeg2000Options jp2Options = new Jpeg2000Options
                {
                    Irreversible = true // Use lossy compression for smaller size
                };
                jpegImage.Save(tempJp2Path, jp2Options);
            }

            jp2TempFiles.Add(tempJp2Path);
        }

        // Create PDF options with JPEG2000 compression (using Jpeg2000Options via ImageOptions)
        PdfOptions pdfOptions = new PdfOptions();

        // The PdfOptions does not expose a direct JPEG2000 compression enum,
        // but we can embed JPEG2000 images directly by adding them as pages.
        // We'll create a multi-page PDF by saving each JPEG2000 image sequentially.

        string outputPdfPath = Path.Combine(outputDirectory, "Combined.pdf");
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

        // Initialize the PDF document with the first image
        using (Image firstImage = Image.Load(jp2TempFiles[0]))
        {
            firstImage.Save(outputPdfPath, pdfOptions);
        }

        // Append remaining images to the PDF
        for (int i = 1; i < jp2TempFiles.Count; i++)
        {
            using (Image img = Image.Load(jp2TempFiles[i]))
            {
                // Append the image as a new page
                img.Save(outputPdfPath, pdfOptions);
            }
        }

        // Cleanup temporary JPEG2000 files
        foreach (string tempFile in jp2TempFiles)
        {
            try
            {
                File.Delete(tempFile);
            }
            catch
            {
                // Ignore any errors during cleanup
            }
        }

        Console.WriteLine($"PDF created at: {outputPdfPath}");
    }
}