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

            // Ensure the output directory exists (rule for each output path will also call this)
            Directory.CreateDirectory(outputFolder);

            // Get all EMF files in the input folder
            string[] emfFiles = Directory.GetFiles(inputFolder, "*.emf");

            foreach (string inputPath in emfFiles)
            {
                // Verify the input file exists (rule)
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the corresponding PDF output path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure the output directory exists (rule)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EMF image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as PDF using PdfOptions
                    image.Save(outputPath, new PdfOptions());
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
 * 1. When a developer needs to batch convert a folder of Windows Metafile (EMF) diagrams created by a reporting engine into separate PDF documents for easy sharing and archival using C# and Aspose.Imaging.
 * 2. When a software solution must automatically transform vector‑based EMF assets from a design repository into PDF files for inclusion in client‑facing PDFs or print‑ready packages.
 * 3. When an application has to process incoming EMF files from a scanner or export routine and generate individual PDF files for compliance reporting without manual intervention.
 * 4. When a migration tool must convert legacy EMF icons stored on a server into PDF format to integrate with a modern web portal that only supports PDF rendering.
 * 5. When a background service needs to monitor a directory, load each EMF image, and save it as a PDF using Aspose.Imaging’s PdfOptions to support document management workflows.
 */