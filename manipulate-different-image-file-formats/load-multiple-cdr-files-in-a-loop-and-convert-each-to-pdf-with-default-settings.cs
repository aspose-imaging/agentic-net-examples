using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"c:\temp\cdr\";
            string outputDir = @"c:\temp\pdf\";

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDir);

            // List of CDR files to process (hardcoded paths)
            string[] cdrFiles = new string[]
            {
                Path.Combine(inputDir, "sample1.cdr"),
                Path.Combine(inputDir, "sample2.cdr")
                // Add more files as needed
            };

            foreach (string inputPath in cdrFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Cache all pages to avoid repeated loading
                    foreach (CdrImagePage page in cdrImage.Pages)
                    {
                        page.CacheData();
                    }

                    int pageIndex = 0;
                    foreach (CdrImagePage page in cdrImage.Pages)
                    {
                        // Build output PDF path for each page
                        string outputPath = Path.Combine(
                            outputDir,
                            $"{Path.GetFileNameWithoutExtension(inputPath)}.page{pageIndex}.pdf");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Set up PDF conversion options
                        PdfOptions pdfOptions = new PdfOptions();
                        CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                        {
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None,
                            PageWidth = page.Width,
                            PageHeight = page.Height
                        };
                        pdfOptions.VectorRasterizationOptions = rasterOptions;

                        // Save the page as PDF
                        page.Save(outputPath, pdfOptions);
                        pageIndex++;
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