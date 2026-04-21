using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input PSD files
            string[] inputPaths = {
                @"C:\temp\page1.psd",
                @"C:\temp\page2.psd",
                @"C:\temp\page3.psd"
            };

            // Hardcoded output PDF file
            string outputPath = @"C:\temp\combined.pdf";

            // Verify each input file exists
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load each PSD image
            var loadedImages = new List<Image>();
            foreach (var inputPath in inputPaths)
            {
                loadedImages.Add(Image.Load(inputPath));
            }

            // Create a multipage image (PDF) from the loaded PSD images.
            // The overload with 'disposeImages' set to true will dispose the source images after creation.
            using (Image multipagePdf = Image.Create(loadedImages.ToArray(), true))
            {
                // PDF save options (default settings)
                var pdfOptions = new PdfOptions();

                // Save the combined PDF
                multipagePdf.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}