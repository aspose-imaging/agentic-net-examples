using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Define input EMF files (relative paths)
        string[] inputPaths = new string[]
        {
            Path.Combine("Input", "file1.emf"),
            Path.Combine("Input", "file2.emf")
            // Add more files as needed
        };

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Define output PDF path
        string outputPath = Path.Combine("Output", "merged.pdf");
        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Prepare rasterization options for each EMF page
        List<VectorRasterizationOptions> pageOptions = new List<VectorRasterizationOptions>();
        foreach (string inputPath in inputPaths)
        {
            using (Image image = Image.Load(inputPath))
            {
                VectorRasterizationOptions vopt = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };
                pageOptions.Add(vopt);
            }
        }

        // Configure PDF options with multiple pages
        using (PdfOptions pdfOptions = new PdfOptions())
        {
            pdfOptions.MultiPageOptions = new MultiPageOptions
            {
                PageRasterizationOptions = pageOptions.ToArray()
            };

            // Load any image (first EMF) to invoke Save with PDF options
            using (Image dummy = Image.Load(inputPaths[0]))
            {
                dummy.Save(outputPath, pdfOptions);
            }
        }
    }
}