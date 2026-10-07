// HOW-TO: Extract PDF Pages As EMF Vector Images Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.pdf");
            string outputDir = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image pdfImage = Image.Load(inputPath))
            {
                IMultipageImage multipage = pdfImage as IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("Input PDF does not support multiple pages.");
                    return;
                }

                int pageCount = multipage.PageCount;
                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.emf");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (EmfOptions options = new EmfOptions())
                    {
                        options.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = pdfImage.Width,
                            PageHeight = pdfImage.Height
                        };
                        options.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));
                        pdfImage.Save(outputPath, options);
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
 * 1. When you need to convert each page of a multi‑page PDF containing vector graphics into separate EMF files for high‑quality scaling in a Windows application.
 * 2. When generating printable vector assets from PDF reports to embed in Microsoft Office documents without loss of resolution.
 * 3. When automating the extraction of vector diagrams from engineering PDFs to reuse them in CAD or diagramming tools that accept EMF.
 * 4. When creating thumbnail previews of PDF pages as EMF to maintain crisp lines for web or desktop UI components.
 * 5. When processing batch PDF files on a server to produce EMF images for downstream workflows that require vector format compatibility.
 */
