// HOW-TO: Convert Multi-Page EMF to Separate PNG Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipage)
                {
                    int pageCount = multipage.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        string outputPath = Path.Combine("output", $"page_{i + 1}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        PngOptions options = new PngOptions
                        {
                            MultiPageOptions = new MultiPageOptions(new IntRange(i, 1))
                        };
                        image.Save(outputPath, options);
                    }
                }
                else
                {
                    string outputPath = Path.Combine("output", "page_1.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    PngOptions options = new PngOptions();
                    image.Save(outputPath, options);
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
 * 1. When you need to extract each page of a vector EMF report as individual PNG images for web preview.
 * 2. When you want to generate thumbnail PNGs from a multi-page EMF diagram to display in a file manager.
 * 3. When a reporting system stores charts as EMF and you must convert them to raster PNGs for email attachments.
 * 4. When you are building a document conversion service that splits a multi-page EMF into separate PNG pages for downstream processing.
 * 5. When you need to archive each page of an EMF blueprint as lossless PNG files for archival compliance.
 */
