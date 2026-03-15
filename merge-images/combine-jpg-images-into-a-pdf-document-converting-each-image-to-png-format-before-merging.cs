using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class JpgToPdfConverter
{
    // Converts an array of JPG file paths into a single PDF file.
    // Each JPG is first saved as a PNG (required by the task) and then merged.
    public static void ConvertJpgsToPdf(string[] jpgFilePaths, string outputPdfPath)
    {
        // List to hold temporary PNG file paths
        var pngFilePaths = new List<string>();

        try
        {
            // Step 1: Convert each JPG to PNG and store the PNG path
            foreach (var jpgPath in jpgFilePaths)
            {
                // Load the JPG image
                using (Image jpgImage = Image.Load(jpgPath))
                {
                    // Determine a temporary PNG file name (same folder, same base name)
                    string pngPath = Path.ChangeExtension(jpgPath, ".png");
                    // Save the image as PNG using default PNG options
                    jpgImage.Save(pngPath, new PngOptions());
                    pngFilePaths.Add(pngPath);
                }
            }

            // Step 2: Create a multipage image from the PNG files
            // Image.Create(string[]) creates a multipage image (e.g., PDF) from the supplied files
            using (Image pdfImage = Image.Create(pngFilePaths.ToArray()))
            {
                // Save the multipage image as PDF. The format is inferred from the file extension.
                pdfImage.Save(outputPdfPath);
            }
        }
        finally
        {
            // Clean up temporary PNG files
            foreach (var pngPath in pngFilePaths)
            {
                if (File.Exists(pngPath))
                {
                    try { File.Delete(pngPath); } catch { /* ignore cleanup errors */ }
                }
            }
        }
    }

    // Example usage
    static void Main()
    {
        // Array of source JPG files
        string[] jpgFiles = new string[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // Destination PDF file
        string outputPdf = @"C:\Images\Combined.pdf";

        ConvertJpgsToPdf(jpgFiles, outputPdf);

        Console.WriteLine("PDF created successfully at: " + outputPdf);
    }
}