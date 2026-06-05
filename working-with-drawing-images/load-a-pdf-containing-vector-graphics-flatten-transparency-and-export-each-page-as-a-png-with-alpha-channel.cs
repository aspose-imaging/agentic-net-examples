using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.pdf";
            string outputDirectory = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (Image pdfImage = Image.Load(inputPath))
            {
                int pageCount = 1;
                if (pdfImage is IMultipageImage multipage)
                {
                    pageCount = multipage.PageCount;
                }

                for (int i = 0; i < pageCount; i++)
                {
                    using (PngOptions pngOptions = new PngOptions())
                    {
                        pngOptions.ColorType = PngColorType.TruecolorWithAlpha;

                        if (pdfImage is VectorImage)
                        {
                            var vectorOptions = new VectorRasterizationOptions();
                            vectorOptions.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
                            vectorOptions.SmoothingMode = SmoothingMode.None;
                            pngOptions.VectorRasterizationOptions = vectorOptions;
                        }

                        pngOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));

                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        pdfImage.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to display each page of a PDF brochure as a transparent PNG thumbnail while preserving vector sharpness, it can use this code to rasterize and export the pages.
 * 2. When an e‑learning platform wants to convert PDF slide decks containing vector diagrams into PNG images with an alpha channel for overlay on interactive backgrounds, this snippet handles the conversion.
 * 3. When a desktop publishing tool must flatten PDF transparency and generate high‑quality PNG assets for print‑ready PDFs that include vector graphics, the code provides the necessary rasterization.
 * 4. When a mobile app requires on‑device preview of multi‑page PDF invoices as PNGs with transparent backgrounds for custom UI composition, developers can employ this routine.
 * 5. When an automated CI/CD pipeline processes design PDFs to produce per‑page PNG sprites with preserved vector detail and alpha transparency for game development pipelines, this example performs the task.
 */