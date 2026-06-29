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
            string inputDir = "Input";
            string outputDir = "Output";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add SVG files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] files = Directory.GetFiles(inputDir, "*.svg");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        var vectorOptions = new VectorRasterizationOptions();
                        vectorOptions.BackgroundColor = Color.White;
                        vectorOptions.PageSize = image.Size;

                        pdfOptions.VectorRasterizationOptions = vectorOptions;

                        image.Save(outputPath, pdfOptions);
                    }
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
 * 1. When a developer needs to batch‑convert a folder of SVG icons into PDF files while preserving each icon as a scalable vector object for high‑resolution printing.
 * 2. When an application must automate the creation of printable PDF catalogs from SVG assets, ensuring the icons remain vector‑based for crisp output at any size.
 * 3. When a CI/CD pipeline should verify that all SVG UI symbols are correctly rasterized into PDF documents with a white background for compliance documentation.
 * 4. When a design‑to‑production workflow requires converting multiple SVG logos into PDF format so the output can be imported into layout software without losing vector fidelity.
 * 5. When a .NET service needs to export user‑uploaded SVG illustrations as PDF files for archival or e‑signature purposes, using Aspose.Imaging to keep the graphics editable at any scale.
 */