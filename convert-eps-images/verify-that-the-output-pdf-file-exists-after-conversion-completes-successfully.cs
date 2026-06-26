using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.jpg";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
            }

            if (File.Exists(outputPath))
                Console.WriteLine("PDF file created successfully.");
            else
                Console.Error.WriteLine("Failed to create PDF file.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert user‑uploaded JPEG photos to PDF documents for archival or printing, and must verify that the PDF file was created successfully.
 * 2. When an automated batch‑processing service transforms image assets from a folder into PDF reports and needs to confirm each output file exists before moving to the next step.
 * 3. When integrating Aspose.Imaging into a C# web API that receives image paths, converts them to PDF, and returns a success response only after the PDF file is confirmed on disk.
 * 4. When building a desktop utility that lets non‑technical staff select a picture and generate a PDF, the code checks the file system to ensure the PDF was generated before displaying a confirmation message.
 * 5. When writing unit tests for image‑to‑PDF conversion logic, the test script runs the conversion and asserts that the expected PDF file exists in the output directory.
 */