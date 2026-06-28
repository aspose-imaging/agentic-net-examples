using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

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

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Resize to 640x480
                    image.Resize(640, 480);
                    // Apply sharpening filter
                    image.Filter(image.Bounds, new SharpenFilterOptions());

                    // Save as PDF
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        pdfOptions.Source = new FileCreateSource(outputPath, false);
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
 * 1. When a developer uses Aspose.Imaging for .NET to batch convert a folder of high‑resolution PNG screenshots into 640×480 PDFs with a sharpening filter for email distribution.
 * 2. When an e‑commerce site needs to generate product catalog PDFs from PNG images, automatically resizing each to 640×480 and applying Aspose.Imaging’s SharpenFilterOptions to enhance detail.
 * 3. When a document management workflow requires automated processing of scanned PNG pages, scaling them to 640×480, sharpening them with Aspose.Imaging, and saving the results as PDF files.
 * 4. When a marketing team wants to create a printable PDF brochure from a collection of PNG assets, using Aspose.Imaging to resize each image to 640×480 and apply a sharpening filter for crisp visuals.
 * 5. When a desktop application must prepare PNG graphics for inclusion in a PDF user manual, employing Aspose.Imaging’s batch resize and sharpen operations before saving each image as a PDF page.
 */