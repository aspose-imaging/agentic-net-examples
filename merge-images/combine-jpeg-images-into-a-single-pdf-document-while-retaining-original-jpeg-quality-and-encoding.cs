using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hard‑coded list of JPEG files to combine
        string[] inputPaths = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Hard‑coded output PDF path
        string outputPath = @"C:\Images\Combined.pdf";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a multipage image from the JPEG files (uses the provided Create(string[]) rule)
        using (Image pdfImage = Image.Create(inputPaths))
        {
            // Save the multipage image as a PDF.
            // The default save behavior embeds the original JPEG streams, preserving their quality.
            pdfImage.Save(outputPath);
        }
    }
}