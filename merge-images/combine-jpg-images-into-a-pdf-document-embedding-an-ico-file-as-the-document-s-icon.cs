using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hard‑coded input JPG files
        string[] jpgPaths = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Hard‑coded input ICO file (will be used as the document icon)
        string icoPath = @"C:\Images\icon.ico";

        // Hard‑coded output PDF file
        string outputPdfPath = @"C:\Output\combined.pdf";

        // Verify that every JPG exists
        foreach (string path in jpgPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Verify that the ICO exists
        if (!File.Exists(icoPath))
        {
            Console.Error.WriteLine($"File not found: {icoPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

        // Load all images (JPGs + ICO) into a list
        List<Image> loadedImages = new List<Image>();
        try
        {
            // Load JPG images
            foreach (string jpgPath in jpgPaths)
            {
                loadedImages.Add(Image.Load(jpgPath));
            }

            // Load the ICO image
            loadedImages.Add(Image.Load(icoPath));

            // Create a multipage image from the loaded pages
            using (Image multipageImage = Image.Create(loadedImages.ToArray()))
            {
                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions
                {
                    // Optional: set compression (auto selects the best method)
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        Compression = PdfImageCompressionOptions.Auto
                    }
                };

                // Save the multipage image as a PDF
                multipageImage.Save(outputPdfPath, pdfOptions);
            }
        }
        finally
        {
            // Dispose all loaded images
            foreach (Image img in loadedImages)
            {
                img.Dispose();
            }
        }
    }
}