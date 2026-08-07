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
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] files = Directory.GetFiles(inputDir, "*.*", SearchOption.TopDirectoryOnly);
            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
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
 * 1. When a design studio needs to automatically convert a folder of SVG or EPS illustrations into PDF files that preserve the original typography by embedding fonts and comply with PDF 1.6 for client delivery.
 * 2. When an e‑learning platform must generate printable PDF handouts from a batch of vector diagrams stored in AI or WMF format, ensuring the PDFs are version‑compatible with older viewers.
 * 3. When a legal document automation system has to transform vector‑based court exhibits into searchable PDFs with embedded fonts to meet filing standards and maintain visual fidelity.
 * 4. When a marketing department wants to mass‑export brand assets such as icons and logos from various vector formats to PDF for inclusion in brochures, while guaranteeing the PDFs use PDF 1.6 and contain all required fonts.
 * 5. When a cloud‑based image processing service offers an API that receives a zip of vector files and returns PDFs with embedded fonts, using C# and Aspose.Imaging to process the batch efficiently.
 */