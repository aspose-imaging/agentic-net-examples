using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class JpgToPdfViaBmp
{
    static void Main()
    {
        // List of source JPG files to be merged into a single PDF
        string[] jpgFiles = { "image1.jpg", "image2.jpg", "image3.jpg" };

        // Destination PDF file
        string pdfPath = "merged.pdf";

        // Prepare PDF options – use automatic compression
        var pdfOptions = new PdfOptions
        {
            Compression = PdfImageCompressionOptions.Auto,
            // Append = true enables adding subsequent pages to the same PDF file
            Append = true
        };

        // Process each JPG file
        foreach (string jpgPath in jpgFiles)
        {
            // Load the JPG image (lifecycle rule: use Image.Load)
            using (Image jpgImage = Image.Load(jpgPath))
            {
                // Convert the JPG to BMP and keep it in a memory stream
                using (var bmpStream = new MemoryStream())
                {
                    // Save the loaded image as BMP (lifecycle rule: use Image.Save with BmpOptions)
                    jpgImage.Save(bmpStream, new BmpOptions());

                    // Reset stream position for reading
                    bmpStream.Position = 0;

                    // Load the BMP image from the memory stream
                    using (Image bmpImage = Image.Load(bmpStream))
                    {
                        // Save (or append) the BMP image as a PDF page
                        // The first iteration creates the PDF, subsequent iterations append pages
                        bmpImage.Save(pdfPath, pdfOptions);
                    }
                }
            }
        }

        Console.WriteLine($"Successfully merged {jpgFiles.Length} JPG images into '{pdfPath}'.");
    }
}