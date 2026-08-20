// HOW-TO: Convert PDF Vector Pages to Separate PNG Images with Transparency Flattening in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.pdf";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDirectory = "output";

            using (Image image = Image.Load(inputPath))
            {
                IMultipageImage multipage = image as IMultipageImage;
                int pageCount = multipage?.PageCount ?? 1;

                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PngOptions pngOptions = new PngOptions();

                    if (image is VectorImage)
                    {
                        pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        };
                    }

                    pngOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));

                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate high‑resolution PNG thumbnails of each page in a PDF that contains vector graphics for web preview.
 * 2. When you must preserve the visual appearance of PDF artwork while removing transparency by rasterizing onto a white background for printing workflows.
 * 3. When an application has to batch‑process multi‑page PDF reports and save each page as an individual PNG file for downstream image analysis.
 * 4. When you want to extract vector‑based PDF pages as PNGs with an alpha channel to overlay them on other graphics in a C# desktop application.
 * 5. When you are building a document conversion service that requires converting PDF pages to PNG format while ensuring consistent color rendering across all pages.
 */
