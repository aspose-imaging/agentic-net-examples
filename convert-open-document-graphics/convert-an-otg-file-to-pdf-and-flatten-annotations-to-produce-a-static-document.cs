using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Data\input.otg";
            string outputPath = @"C:\Data\output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for OTG
                OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                {
                    // Preserve original page size
                    PageSize = image.Size,
                    // Optional: set a white background to flatten any transparent areas
                    BackgroundColor = Color.White
                };

                // Configure PDF save options and attach rasterization options
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as a flattened PDF
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
 * 1. When a medical imaging system stores annotated scans in OTG format and needs to generate a read‑only PDF report for clinicians, this code can convert and flatten the annotations into a static document.
 * 2. When an engineering firm archives CAD drawings saved as OTG files and wants to share them with clients who only have PDF viewers, the snippet rasterizes the vector data and produces a portable PDF.
 * 3. When a document management workflow receives OTG files with layered comments and must create a non‑editable PDF for compliance audits, the code flattens all annotations into a single page.
 * 4. When a cloud‑based image processing service receives user‑uploaded OTG files and must deliver a downloadable PDF without requiring the client to install additional viewers, this C# routine performs the conversion and rasterization.
 * 5. When a legal e‑discovery platform needs to preserve the visual appearance of OTG evidence files while removing interactive elements, the example converts the files to a flattened PDF for secure archiving.
 */