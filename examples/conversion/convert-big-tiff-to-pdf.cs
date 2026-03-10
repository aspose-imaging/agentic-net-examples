using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.BigTiff;

namespace ProgramNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input and output file paths as command‑line arguments.
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: Program <inputBigTiffPath> <outputPdfPath>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Validate that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the BigTIFF image.
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF export options.
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    // Save the loaded image as a PDF document.
                    image.Save(outputPath, pdfOptions);
                }
            }

            Console.WriteLine($"Conversion completed: {outputPath}");
        }
    }
}