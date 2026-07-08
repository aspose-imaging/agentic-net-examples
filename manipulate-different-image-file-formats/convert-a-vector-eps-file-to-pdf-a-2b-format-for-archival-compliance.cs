using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = (EpsImage)Image.Load(inputPath))
            {
                var options = new PdfOptions();
                image.Save(outputPath, options);
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
 * 1. When a developer needs to archive legacy vector artwork stored in EPS format by converting it to PDF/A‑2b for long‑term preservation and compliance with ISO standards.
 * 2. When a C# application must generate searchable, print‑ready PDF/A documents from EPS logos or illustrations for inclusion in regulatory reports.
 * 3. When an automated workflow processes incoming EPS files from designers and must output PDF/A‑2b files to satisfy document management system requirements.
 * 4. When a .NET service needs to ensure that vector graphics are stored in a self‑contained, platform‑independent format that preserves colors and fonts for future retrieval.
 * 5. When a developer is building a batch conversion tool that reads EPS images, applies PdfOptions, and saves them as PDF/A‑2b files to reduce storage costs and improve compatibility.
 */