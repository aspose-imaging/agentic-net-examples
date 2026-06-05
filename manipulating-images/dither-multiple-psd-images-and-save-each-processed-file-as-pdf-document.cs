using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded list of PSD files to process
            string[] inputFiles = new string[]
            {
                @"C:\Images\input1.psd",
                @"C:\Images\input2.psd"
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path (same folder, same name, .pdf extension)
                string outputPath = Path.ChangeExtension(inputPath, ".pdf");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PSD image
                using (Image image = Image.Load(inputPath))
                {
                    // Apply dithering if the image is raster based
                    if (image is RasterImage rasterImage)
                    {
                        // Floyd‑Steinberg dithering with a 1‑bit palette (black & white)
                        rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 1);
                    }

                    // Prepare PDF save options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Save the processed image as a PDF document
                    image.Save(outputPath, pdfOptions);
                }
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
 * 1. When a graphic design studio needs to batch‑convert layered Photoshop PSD files into printable PDF documents while preserving visual fidelity by applying Floyd‑Steinberg dithering for black‑and‑white output.
 * 2. When an e‑learning platform automatically generates PDF handouts from PSD slide assets and wants to ensure crisp monochrome rendering on low‑resolution printers.
 * 3. When a document management system ingests multiple PSD artwork files and stores them as searchable PDF files, using C# and Aspose.Imaging to dither the images to a 1‑bit palette for reduced file size.
 * 4. When a marketing automation tool processes a list of PSD banners overnight, applying dithering to meet PDF/A compliance before archiving the PDFs in a corporate repository.
 * 5. When a Windows service monitors a folder of PSD files, converts each to a PDF with Floyd‑Steinberg dithering, and saves the results to the same directory for downstream workflow integration.
 */