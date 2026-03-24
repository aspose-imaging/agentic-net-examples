using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputFiles = new[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Hardcoded output PDF file
        string outputPdf = @"C:\Output\combined.pdf";

        // Verify each input file exists
        foreach (var inputPath in inputFiles)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdf));

        // List to hold EMF images created from JPGs
        List<Image> emfImages = new List<Image>();

        foreach (var inputPath in inputFiles)
        {
            // Load JPG image
            using (Image jpgImage = Image.Load(inputPath))
            {
                // Prepare EMF rasterization options matching the source size
                var emfRasterOptions = new EmfRasterizationOptions
                {
                    PageSize = jpgImage.Size
                };

                // Save JPG as EMF into a memory stream
                using (MemoryStream emfStream = new MemoryStream())
                {
                    jpgImage.Save(emfStream, new EmfOptions { VectorRasterizationOptions = emfRasterOptions });
                    emfStream.Position = 0; // Reset stream position for reading

                    // Load the EMF image from the memory stream
                    Image emfImage = Image.Load(emfStream);
                    emfImages.Add(emfImage); // Add to list (will be disposed later)
                }
            }
        }

        // Create a multipage image from the EMF pages
        using (Image multipage = Image.Create(emfImages.ToArray()))
        {
            // Save the multipage image as a PDF document
            var pdfOptions = new PdfOptions();
            multipage.Save(outputPdf, pdfOptions);
        }

        // Dispose all EMF images
        foreach (var img in emfImages)
        {
            img.Dispose();
        }

        Console.WriteLine("PDF created successfully at: " + outputPdf);
    }
}