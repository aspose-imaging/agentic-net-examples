using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.jpg";
            string outputPath = "Output\\sample.pdf";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions();
                image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to generate a PDF report from a single JPEG photograph for easy sharing or printing, they can use this code to load the image with Aspose.Imaging and save it as a PDF.
 * 2. When an application must archive scanned documents stored as JPEG files into a PDF format for compliance or storage efficiency, this snippet demonstrates the conversion using C# and Aspose.Imaging.
 * 3. When a web service receives user‑uploaded JPEG images and must return a downloadable PDF version, the code shows how to perform the transformation on the server side.
 * 4. When a desktop utility needs to batch‑process individual JPEG files into PDFs without altering image quality, this example provides the core logic for loading and saving each file with PdfOptions.
 * 5. When integrating Aspose.Imaging into a .NET workflow that converts image assets to PDF for inclusion in electronic catalogs, this snippet illustrates the essential steps of loading a JPEG and exporting it as a PDF document.
 */