using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputPaths = new[]
        {
            @"C:\Images\photo1.jpg",
            @"C:\Images\photo2.jpg",
            @"C:\Images\photo3.jpg"
        };

        // Hardcoded output PDF file
        string outputPath = @"C:\Images\CombinedOutput.pdf";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Prepare a list to hold PNG images (in memory)
        List<Image> pngImages = new List<Image>();

        // Convert each JPG to PNG and keep the PNG image in memory
        foreach (string inputPath in inputPaths)
        {
            // Load the JPG image
            using (Image jpgImage = Image.Load(inputPath))
            {
                // Save JPG image to a memory stream as PNG
                using (MemoryStream pngStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    jpgImage.Save(pngStream, pngOptions);
                    pngStream.Position = 0; // Reset stream position for reading

                    // Load the PNG image from the memory stream
                    Image pngImage = Image.Load(pngStream);
                    pngImages.Add(pngImage);
                }
            }
        }

        // Create a multipage image from the PNG images, disposing them automatically after use
        using (Image multipagePdf = Image.Create(pngImages.ToArray(), true))
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare PDF export options (default settings)
            var pdfOptions = new PdfOptions();

            // Save the multipage image as a PDF document
            multipagePdf.Save(outputPath, pdfOptions);
        }

        // At this point all resources are disposed
    }
}