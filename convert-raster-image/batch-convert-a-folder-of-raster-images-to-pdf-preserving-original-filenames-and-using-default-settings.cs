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
            // Hardcoded input and output folders
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Get all files in the input folder
            string[] files = Directory.GetFiles(inputFolder);

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PDF path preserving the original filename
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the raster image
                using (Image image = Image.Load(inputPath))
                {
                    // Use default PDF options
                    var pdfOptions = new PdfOptions();

                    // Save the image as PDF
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
 * 1. When a developer needs to generate printable PDF catalogs from a folder of JPEG or PNG photos for an e‑commerce website.
 * 2. When an organization wants to archive scanned TIFF documents into PDF files while preserving the original filenames for easy retrieval.
 * 3. When a desktop application must convert user‑uploaded BMP screenshots into PDF reports in bulk without custom rendering options.
 * 4. When a migration script has to transform legacy image assets into PDF format for a document management system, keeping the naming conventions intact.
 * 5. When an automated build process must create PDF versions of design mockups (PNG, GIF) for distribution to stakeholders using default Aspose.Imaging settings.
 */