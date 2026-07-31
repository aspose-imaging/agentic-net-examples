using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.pdf";
            string outputDir = "output";

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
                    Console.Error.WriteLine("The loaded document is not a multipage image.");
                    return;
                }

                for (int i = 0; i < multipage.PageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PngOptions pngOptions = new PngOptions();

                    if (pdfImage is VectorImage)
                    {
                        pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = pdfImage.Width,
                            PageHeight = pdfImage.Height
                        };
                    }

                    pngOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));

                    pdfImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert each page of a multi‑page PDF that contains vector graphics into separate PNG files with preserved transparency for web preview.
 * 2. When an application must flatten PDF transparency layers and export the pages as PNG images with an alpha channel for use in graphic design tools.
 * 3. When a reporting system generates PDF invoices with vector logos and requires high‑resolution PNG thumbnails for email attachments.
 * 4. When a document management workflow extracts individual pages from a scanned PDF and saves them as PNGs while maintaining the original page dimensions and background color.
 * 5. When a C# service automates the conversion of PDF brochures into PNG assets for mobile apps, ensuring each page retains its vector quality and transparent elements.
 */