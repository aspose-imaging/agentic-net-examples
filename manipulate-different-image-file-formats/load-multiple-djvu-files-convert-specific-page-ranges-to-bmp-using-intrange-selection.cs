// HOW-TO: Convert Specific Page Range of Multiple DjVu Files to BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputFiles = {
                "Input\\sample1.djvu",
                "Input\\sample2.djvu"
            };

            int rangeStart = 1;
            int rangeEnd = 3;

            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) +
                                        $"_pages_{rangeStart}_{rangeEnd}.bmp";
                string outputPath = Path.Combine("Output", outputFileName);

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
                {
                    using (BmpOptions bmpOptions = new BmpOptions())
                    {
                        var range = new IntRange(rangeStart, rangeEnd);
                        bmpOptions.MultiPageOptions = new DjvuMultiPageOptions(range);
                        djvu.Save(outputPath, bmpOptions);
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
 * 1. When you need to extract the first three pages from several DjVu documents and save them as high‑resolution BMP images for printing or archival.
 * 2. When an application must batch‑process a collection of DjVu files, converting only a selected page interval to BMP to reduce processing time and file size.
 * 3. When you are building a document‑conversion service that offers users the ability to download specific pages of a DjVu ebook as BMP thumbnails.
 * 4. When integrating Aspose.Imaging into a C# workflow that requires preserving the original page order while exporting a subset of pages from DjVu to BMP for further analysis.
 * 5. When automating a quality‑control pipeline that validates the visual fidelity of particular DjVu pages by converting them to BMP for pixel‑by‑pixel comparison.
 */
