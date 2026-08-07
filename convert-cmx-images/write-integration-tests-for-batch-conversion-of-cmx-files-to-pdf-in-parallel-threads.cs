using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure directories exist
            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            // Get all CMX files in the input directory
            string[] cmxFiles = Directory.GetFiles(inputDirectory, "*.cmx");

            // Process each file in parallel
            Parallel.ForEach(cmxFiles, cmxPath =>
            {
                // Verify input file exists
                if (!File.Exists(cmxPath))
                {
                    Console.Error.WriteLine($"File not found: {cmxPath}");
                    return;
                }

                // Prepare output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(cmxPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load CMX image and save as PDF
                using (Image image = Image.Load(cmxPath))
                {
                    var pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a large batch of legacy Corel Metafile (CMX) drawings into searchable PDF documents for archiving or distribution, they can use this parallel processing code to speed up the conversion.
 * 2. When an automated build or CI pipeline must generate PDF reports from CMX assets stored in a source folder, this code enables fast, thread‑safe conversion without manual intervention.
 * 3. When a web service receives multiple CMX uploads and must return PDF versions to clients, the parallel loop ensures high throughput while handling file existence checks and directory creation.
 * 4. When a migration project moves design files from a legacy CAD system to a modern document management system that only accepts PDF, developers can employ this code to batch‑process the files efficiently.
 * 5. When a desktop application offers a “Convert All” button to transform user‑selected CMX files into PDFs in the background, this snippet provides the necessary C# image loading, PdfOptions configuration, and parallel execution.
 */