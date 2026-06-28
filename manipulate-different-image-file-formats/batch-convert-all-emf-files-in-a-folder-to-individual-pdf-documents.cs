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
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputEmf";
            string outputFolder = @"C:\OutputPdf";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all EMF files in the input folder
            string[] emfFiles = Directory.GetFiles(inputFolder, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the corresponding PDF output path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image and save it as PDF
                using (Image image = Image.Load(inputPath))
                {
                    PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When a developer needs to migrate a legacy collection of Windows Metafile (EMF) graphics to PDF for easier distribution and printing, they can use this batch conversion code.
 * 2. When an automated build pipeline must generate PDF documentation from EMF diagrams stored in a source folder, the script can process all files in one step.
 * 3. When a web application must serve vector images as PDF downloads to clients without requiring client‑side rendering of EMF files, this code can pre‑convert the assets.
 * 4. When a company archives engineering schematics originally saved as EMF and wants to store them in a searchable PDF repository, the batch converter handles the bulk transformation.
 * 5. When a desktop utility needs to validate that every EMF file in a directory can be opened and saved as a PDF for quality‑assurance testing, the example provides a simple C# loop to perform the check.
 */