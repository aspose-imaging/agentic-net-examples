// HOW-TO: Batch Convert ODG and OTG Files to PDF with Uniform Page Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input directory containing ODG and OTG files
            string inputDirectory = @"C:\Images\Input";
            // Hardcoded output directory for generated PDFs
            string outputDirectory = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all .odg and .otg files in the input directory
            string[] odgFiles = Directory.GetFiles(inputDirectory, "*.odg");
            string[] otgFiles = Directory.GetFiles(inputDirectory, "*.otg");

            // Process ODG files
            foreach (string inputPath in odgFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Configure rasterization options for ODG
                    OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
                    {
                        // Use the source image size as the page size for uniformity
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    };

                    // Set up PDF save options
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save as PDF
                    image.Save(outputPath, pdfOptions);
                }
            }

            // Process OTG files
            foreach (string inputPath in otgFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Configure rasterization options for OTG
                    OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                    {
                        // Use the source image size as the page size for uniformity
                        PageSize = image.Size,
                        BackgroundColor = Color.White
                    };

                    // Set up PDF save options
                    PdfOptions pdfOptions = new PdfOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };

                    // Save as PDF
                    image.Save(outputPath, pdfOptions);
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
 * 1. When a design team needs to archive multiple OpenDocument Graphics (ODG) and OpenDocument Templates (OTG) drawings as PDFs with consistent page dimensions for legal compliance.
 * 2. When an automated build pipeline must generate PDF documentation from a folder of ODG/OTG assets without manual intervention.
 * 3. When a web service receives mixed ODG and OTG uploads and must convert them to PDF for previewing in browsers that only support PDF.
 * 4. When a desktop application processes a batch of engineering schematics stored as ODG/OTG files and creates printable PDFs with a uniform page size for batch printing.
 * 5. When a migration script moves legacy ODG and OTG files to a PDF‑based archive, ensuring each PDF matches the original image size to preserve layout fidelity.
 */
