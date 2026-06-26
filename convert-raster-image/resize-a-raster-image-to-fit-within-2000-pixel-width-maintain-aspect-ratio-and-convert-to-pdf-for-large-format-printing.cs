using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\input\large_image.jpg";
        string outputPath = @"C:\output\large_image.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                const int maxWidth = 2000;

                // Resize if width exceeds the maximum, preserving aspect ratio
                if (image.Width > maxWidth)
                {
                    int newWidth = maxWidth;
                    int newHeight = (int)((double)image.Height * maxWidth / image.Width);
                    image.Resize(newWidth, newHeight, ResizeType.BilinearResample);
                }

                // Prepare PDF export options
                var pdfOptions = new PdfOptions();

                // Save the image as PDF
                image.Save(outputPath, pdfOptions);
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
 * 1. When a printing service needs to take a high‑resolution JPEG photograph, shrink it to a maximum width of 2000 pixels while keeping the aspect ratio, and output a PDF ready for large‑format printers, a developer can use this C# Aspose.Imaging code.
 * 2. When an e‑commerce platform automatically generates printable product catalogs, it can resize uploaded product images to fit within 2000 px width and convert them to PDF files using the shown C# image processing workflow.
 * 3. When a digital signage system must prepare banner graphics for PDF‑based roll‑up displays, the code resizes the raster image to the required width and preserves proportions before saving as a PDF with Aspose.Imaging in C#.
 * 4. When a corporate compliance tool archives scanned documents, it can limit each scanned JPEG to 2000 pixels wide, maintain the original aspect ratio, and store the result as a PDF for easy printing and filing.
 * 5. When a mobile app backend receives user‑uploaded photos and needs to create print‑ready PDFs for on‑demand posters, the C# snippet resizes the image to the maximum width, keeps the aspect ratio, and converts it to a PDF using Aspose.Imaging.
 */