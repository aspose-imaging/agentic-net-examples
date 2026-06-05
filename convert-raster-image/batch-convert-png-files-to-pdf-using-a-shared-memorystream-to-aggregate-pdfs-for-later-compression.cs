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
            // Hard‑coded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all PNG files in the input directory
            string[] pngFiles = Directory.GetFiles(inputDir, "*.png");

            // Shared memory stream that will hold all generated PDFs
            using (MemoryStream sharedPdfStream = new MemoryStream())
            {
                foreach (string inputPath in pngFiles)
                {
                    // Verify the input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Build the output PDF path
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".pdf");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load the PNG image
                    using (Image image = Image.Load(inputPath))
                    {
                        // Prepare PDF export options (default settings)
                        PdfOptions pdfOptions = new PdfOptions();

                        // Save the PDF into the shared memory stream (appended)
                        image.Save(sharedPdfStream, pdfOptions);

                        // Also save the PDF to an individual file
                        image.Save(outputPath, pdfOptions);
                    }
                }

                // Optionally write the aggregated PDF stream to a single file
                string aggregatedPath = Path.Combine(outputDir, "Aggregated.pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(aggregatedPath));
                // Reset stream position before writing
                sharedPdfStream.Position = 0;
                using (FileStream file = new FileStream(aggregatedPath, FileMode.Create, FileAccess.Write))
                {
                    sharedPdfStream.CopyTo(file);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}