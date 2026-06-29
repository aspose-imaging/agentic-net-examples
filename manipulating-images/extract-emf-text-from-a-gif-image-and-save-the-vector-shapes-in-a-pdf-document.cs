using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define relative input and output paths
            string inputPath = Path.Combine("Input", "sample.gif");
            string emfPath = Path.Combine("Output", "temp.emf");
            string pdfPath = Path.Combine("Output", "result.pdf");

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(emfPath));
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

            // Load GIF image and convert to EMF (vector representation)
            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                // Configure EMF rasterization options
                EmfRasterizationOptions emfRasterOptions = new EmfRasterizationOptions
                {
                    PageSize = gif.Size,
                    BackgroundColor = Color.White
                };

                // Set up EMF save options
                EmfOptions emfOptions = new EmfOptions
                {
                    VectorRasterizationOptions = emfRasterOptions
                };

                // Save as EMF
                gif.Save(emfPath, emfOptions);
            }

            // Load the generated EMF and save as PDF
            using (EmfImage emf = (EmfImage)Image.Load(emfPath))
            {
                PdfOptions pdfOptions = new PdfOptions();
                emf.Save(pdfPath, pdfOptions);
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
 * 1. When a developer needs to convert GIF logos into scalable PDF reports for high‑quality printing, they can use Aspose.Imaging for .NET to extract the EMF vector shapes and save them as a PDF.
 * 2. When an application must archive legacy GIF diagrams as searchable PDF documents while preserving the original text as vector graphics, this code extracts the EMF text and creates a PDF.
 * 3. When generating compliance documentation that requires high‑resolution vector output from GIF screenshots, developers can rasterize the GIF to EMF and then export it to a PDF using C#.
 * 4. When a web service provides downloadable PDFs of user‑uploaded GIF icons without losing quality, the code converts the GIF to an EMF vector representation and saves it as a PDF file.
 * 5. When automating batch processing of marketing assets to create print‑ready PDFs from GIF banners, the code extracts the EMF vector shapes and stores them in a PDF using Aspose.Imaging.
 */