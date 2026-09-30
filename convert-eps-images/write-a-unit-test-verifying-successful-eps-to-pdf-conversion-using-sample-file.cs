// HOW-TO: How To Unit Test EPS To PDF Conversion In C# With Aspose.Imaging (Aspose.Imaging for .NET)
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
            string baseDir = Directory.GetCurrentDirectory();
            string inputPath = Path.Combine(baseDir, "Input", "sample.eps");
            string outputPath = Path.Combine(baseDir, "Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Eps.EpsImage epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                PdfOptions options = new PdfOptions();
                epsImage.Save(outputPath, options);
            }

            if (File.Exists(outputPath))
            {
                Console.WriteLine("EPS to PDF conversion succeeded.");
            }
            else
            {
                Console.Error.WriteLine("Conversion failed: output file not created.");
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
 * 1. When you need to automatically verify that EPS artwork is correctly rendered as PDF in a CI pipeline.
 * 2. When your application must batch‑convert vector EPS files to PDF and ensure each conversion succeeds before publishing.
 * 3. When you are building a document generation service that accepts EPS uploads and you want to test the conversion logic with sample files.
 * 4. When you want to validate that the Aspose.Imaging PDF options produce a PDF file that can be opened by standard viewers.
 * 5. When you are migrating legacy EPS assets to PDF and need a repeatable test to confirm the conversion does not corrupt the graphics.
 */
