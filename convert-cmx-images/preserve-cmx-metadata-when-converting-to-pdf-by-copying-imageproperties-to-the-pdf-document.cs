using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cmx";
            string outputPath = "Output\\sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    KeepMetadata = true,
                    ExifData = cmx.ExifData,
                    XmpData = cmx.XmpData,
                    VectorRasterizationOptions = new CmxRasterizationOptions
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
 * 1. When a printing company needs to convert legacy CMX vector artwork to PDF for client delivery while retaining original EXIF and XMP metadata for traceability, this code ensures the metadata is preserved.
 * 2. When an engineering firm archives technical drawings stored as CMX files into searchable PDF documents, copying ImageProperties maintains the embedded metadata required for regulatory compliance.
 * 3. When a digital asset management system migrates CMX graphics to PDF format, preserving metadata allows the assets to be indexed and retrieved using existing metadata fields.
 * 4. When a legal department converts CMX schematics to PDF for evidence submission, retaining the original metadata validates the document’s authenticity and creation date.
 * 5. When a software vendor builds a C# batch‑processing tool that transforms multiple CMX files into PDFs, using this code guarantees that each PDF inherits the source image’s EXIF and XMP information for downstream workflows.
 */