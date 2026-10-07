// HOW-TO: Convert EMF Image to PDF from Memory Stream in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "input.emf");
            string outputPath = Path.Combine("Output", "output.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            byte[] data = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(data))
            {
                using (Image image = Image.Load(ms))
                {
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        };
                        image.Save(outputPath, pdfOptions);
                    }
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
 * 1. When you need to embed a Windows Metafile (EMF) into a PDF report without writing the file to disk first.
 * 2. When a web service receives EMF data as a byte array and must return a PDF document to the client.
 * 3. When automating batch conversion of EMF icons stored in a database to searchable PDF files.
 * 4. When generating printable PDFs from dynamically created vector graphics in a C# application.
 * 5. When preserving the original dimensions and white background of an EMF while converting it to PDF for archival purposes.
 */
