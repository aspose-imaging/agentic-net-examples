using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.cdr");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    PdfOptions pdfOptions = new PdfOptions();
                    CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };
                    pdfOptions.VectorRasterizationOptions = rasterOptions;
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
 * 1. When a design studio needs to batch‑convert a folder of CorelDRAW (.cdr) drawings into searchable PDF documents for client delivery using C# and Aspose.Imaging.
 * 2. When an automated build pipeline must generate PDF archives of all CDR assets in a repository to ensure version‑controlled documentation.
 * 3. When a web service processes user‑uploaded CDR files and returns PDF previews without manual intervention, leveraging Image.Load and PdfOptions in .NET.
 * 4. When a migration tool moves legacy CDR artwork to a PDF‑based workflow, looping through the input directory to preserve file names and folder structure.
 * 5. When a desktop utility needs to rasterize multiple CDR files with default vector‑to‑raster settings and save them as PDFs for printing or electronic distribution.
 */