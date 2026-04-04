using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input CDR files
        string[] inputPaths = new string[]
        {
            @"C:\temp\file1.cdr",
            @"C:\temp\file2.cdr",
            @"C:\temp\file3.cdr"
        };

        // Hardcoded output PDF file
        string outputPath = @"C:\temp\output.pdf";

        // Validate each input file
        foreach (var inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load each CDR file and collect its first page as an Image
        List<Image> pageImages = new List<Image>();
        foreach (var inputPath in inputPaths)
        {
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Ensure the document has at least one page
                if (cdr.Pages != null && cdr.Pages.Length > 0)
                {
                    // Retrieve the first page
                    Image page = cdr.Pages[0];
                    // Cache data to avoid lazy loading after the source is disposed
                    page.CacheData();
                    pageImages.Add(page);
                }
            }
        }

        // Create a multipage image from the collected pages
        Image multipageImage = Image.Create(pageImages.ToArray());

        // Prepare PDF export options
        PdfOptions pdfOptions = new PdfOptions();

        // Save the multipage image as a PDF
        multipageImage.Save(outputPath, pdfOptions);

        // Clean up
        multipageImage.Dispose();
    }
}