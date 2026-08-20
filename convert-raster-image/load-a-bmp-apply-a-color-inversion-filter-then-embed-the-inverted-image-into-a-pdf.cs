// HOW-TO: Invert BMP Colors and Save as PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (BmpImage bmp = new BmpImage(inputPath))
            {
                // Invert colors pixel by pixel
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        var pixel = bmp.GetPixel(x, y);
                        var inverted = Aspose.Imaging.Color.FromArgb(
                            pixel.A,
                            255 - pixel.R,
                            255 - pixel.G,
                            255 - pixel.B);
                        bmp.SetPixel(x, y, inverted);
                    }
                }

                // Save the inverted image into a PDF file
                var pdfOptions = new PdfOptions();
                bmp.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a negative‑style preview of a BMP diagram and embed it directly into a PDF report.
 * 2. When an application must automatically convert scanned BMP assets into PDF files with inverted colors for printing on dark backgrounds.
 * 3. When a batch job processes legacy BMP icons, applies a color inversion filter, and stores the results as PDF documents for archival.
 * 4. When a web service receives BMP uploads, inverts the image colors for visual effect, and returns a PDF version to the client.
 * 5. When you want to create a PDF portfolio that contains BMP images with their colors reversed to meet branding guidelines.
 */
