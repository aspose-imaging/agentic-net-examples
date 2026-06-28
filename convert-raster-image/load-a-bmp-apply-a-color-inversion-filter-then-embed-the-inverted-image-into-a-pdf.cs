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
            string outputPath = "output\\output.pdf";

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
                        var inverted = Color.FromArgb(
                            pixel.A,
                            255 - pixel.R,
                            255 - pixel.G,
                            255 - pixel.B);
                        bmp.SetPixel(x, y, inverted);
                    }
                }

                // Save the inverted image as a PDF (image embedded in a PDF page)
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
 * 1. When a developer needs to convert legacy BMP graphics into printable PDF documents while applying a negative‑film effect for visual emphasis.
 * 2. When an application must generate PDF reports that include scanned BMP images with colors inverted to improve contrast for accessibility compliance.
 * 3. When a batch‑processing tool has to prepare marketing assets by turning product photos stored as BMP files into PDF handouts with a stylized inverted color scheme.
 * 4. When a document‑management system requires embedding security‑enhanced BMP images—where colors are inverted to obscure details—directly into PDF files for archival.
 * 5. When a C# utility must programmatically read a BMP, perform per‑pixel color inversion using Aspose.Imaging, and output a PDF for downstream workflows such as e‑signing or printing.
 */