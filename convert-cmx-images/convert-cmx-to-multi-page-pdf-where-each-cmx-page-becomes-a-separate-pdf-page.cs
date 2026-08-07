using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.cmx";
            string outputPath = "Output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmx = (CmxImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageWidth = cmx.Width,
                        PageHeight = cmx.Height,
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = Aspose.Imaging.SmoothingMode.None
                    }
                };

                cmx.Save(outputPath, pdfOptions);
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
 * 1. When an engineering firm needs to archive multi‑page CorelDRAW CMX drawings as PDF documents that preserve each original page layout for long‑term storage.
 * 2. When a printing service must convert client‑submitted CMX files into PDF pages with exact dimensions and white background before sending them to a raster image processor.
 * 3. When a document management system integrates Aspose.Imaging in C# to transform CMX design files into multi‑page PDFs for easy viewing in web browsers without requiring CorelDRAW.
 * 4. When a batch‑processing tool automatically reads CMX files from a directory and generates PDF files where each CMX page becomes a separate PDF page using specific vector rasterization options.
 * 5. When a software application needs to programmatically rasterize CMX vector graphics to PDF pages while controlling rendering settings such as TextRenderingHint and SmoothingMode.
 */