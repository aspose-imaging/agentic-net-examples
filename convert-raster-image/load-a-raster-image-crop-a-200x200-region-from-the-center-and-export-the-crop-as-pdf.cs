// HOW-TO: Crop Center 200x200 Region from Image and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.pdf";

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
                // Determine the top-left corner of the 200x200 crop region centered in the image
                int cropWidth = 200;
                int cropHeight = 200;
                int left = (image.Width - cropWidth) / 2;
                int top = (image.Height - cropHeight) / 2;

                // Create the cropping rectangle
                Rectangle cropArea = new Rectangle(left, top, cropWidth, cropHeight);

                // Perform the crop
                image.Crop(cropArea);

                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the cropped image as PDF
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
 * 1. When you need to generate a PDF thumbnail of the central part of a photo for a product catalog.
 * 2. When an application must extract a fixed‑size preview from user‑uploaded images before archiving them as PDFs.
 * 3. When a reporting tool requires a centered 200 px square snapshot of scanned documents to embed in PDF reports.
 * 4. When you want to automate creation of PDF certificates that contain only the central logo area of a JPEG logo file.
 * 5. When a web service needs to crop the middle of an image to meet a specific layout and deliver the result as a PDF file.
 */
