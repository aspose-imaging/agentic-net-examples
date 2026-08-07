using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

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
 * 1. When a C# developer uses Aspose.Imaging to convert multi‑layer Photoshop PSD files into high‑resolution PDF documents for print‑ready production while preserving vector quality.
 * 2. When an application must generate client‑ready PDFs from design assets and ensure smooth edges and crisp text by configuring smoothing mode and text rendering hints with Aspose.Imaging for .NET.
 * 3. When a web service automates archival of graphic assets by transforming PSD files into searchable PDF files with optimal rendering settings using Aspose.Imaging in C#.
 * 4. When a desktop tool batch‑processes PSD files into PDFs for legal documentation, requiring consistent page dimensions and anti‑aliasing for accurate visual representation via Aspose.Imaging.
 * 5. When an e‑learning platform converts PSD‑based course illustrations into PDFs that retain color fidelity and clear typography across devices by applying smoothing mode and text rendering hints in Aspose.Imaging for .NET.
 */