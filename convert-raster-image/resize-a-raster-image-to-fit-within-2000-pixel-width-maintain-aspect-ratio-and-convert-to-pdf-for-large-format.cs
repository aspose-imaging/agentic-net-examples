// HOW-TO: Resize Image for Large Format Printing and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\source.jpg";
        string outputPath = @"C:\Images\result.pdf";

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
                // Determine target dimensions while preserving aspect ratio
                const int maxWidth = 2000;
                int targetWidth = image.Width;
                int targetHeight = image.Height;

                if (image.Width > maxWidth)
                {
                    targetWidth = maxWidth;
                    targetHeight = (int)(image.Height * (maxWidth / (double)image.Width));
                }

                // Resize only if needed
                if (targetWidth != image.Width || targetHeight != image.Height)
                {
                    image.Resize(targetWidth, targetHeight);
                }

                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the image as a PDF
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
 * 1. When a developer needs to shrink high‑resolution photos to a printable width of 2000 px while preserving aspect ratio before embedding them in a PDF brochure.
 * 2. When an application must automatically generate PDF files from user‑uploaded JPEGs for large‑format posters without distorting the original image.
 * 3. When a batch‑processing tool has to ensure all images fit within a maximum width limit for consistent printing results and then export them as PDFs.
 * 4. When a web service converts product images to PDF catalogs, resizing them to meet printer specifications and reducing file size.
 * 5. When a desktop utility prepares artwork files for a print shop by resizing them to 2000 px wide and saving them directly as PDF documents.
 */
