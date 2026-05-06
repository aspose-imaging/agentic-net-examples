using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of input CDR files
            string[] inputFiles = new string[]
            {
                @"C:\Input\file1.cdr",
                @"C:\Input\file2.cdr",
                @"C:\Input\file3.cdr"
            };

            // Hardcoded output directory
            string outputDir = @"C:\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the CDR image
                using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
                {
                    // Process each page in the CDR file
                    for (int i = 0; i < cdrImage.Pages.Length; i++)
                    {
                        // Cast the page to CdrImagePage
                        CdrImagePage page = (CdrImagePage)cdrImage.Pages[i];

                        // Build output PDF file name for the current page
                        string outputPath = Path.Combine(outputDir,
                            $"{Path.GetFileNameWithoutExtension(inputPath)}.page{i}.pdf");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Set up PDF conversion options with default rasterization settings
                        PdfOptions pdfOptions = new PdfOptions();
                        CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                        {
                            PageWidth = page.Width,
                            PageHeight = page.Height
                        };
                        pdfOptions.VectorRasterizationOptions = rasterOptions;

                        // Save the current page as a PDF file
                        page.Save(outputPath, pdfOptions);
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