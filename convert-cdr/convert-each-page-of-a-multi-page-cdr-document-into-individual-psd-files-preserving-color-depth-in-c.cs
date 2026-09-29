// HOW-TO: Convert Multi‑Page CDR to Separate PSD Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cdr";
            string outputDir = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipage)
                {
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        var page = multipage.Pages[i] as Image;
                        if (page == null) continue;

                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.psd");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        using (var options = new PsdOptions())
                        {
                            page.Save(outputPath, options);
                        }
                    }
                }
                else
                {
                    string outputPath = Path.Combine(outputDir, "page_1.psd");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (var options = new PsdOptions())
                    {
                        image.Save(outputPath, options);
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
 * 1. When a designer needs to extract each page of a multi‑page CorelDRAW (CDR) file as an individual Photoshop (PSD) document for further editing.
 * 2. When an automated batch process must convert CDR files into separate PSD files while preserving the original color depth.
 * 3. When a publishing workflow requires splitting vector CDR artwork into raster PSD pages for print preparation.
 * 4. When a migration tool has to transform a portfolio of CDR pages into standalone PSD files to integrate with Photoshop‑based pipelines.
 * 5. When a cloud service processes user‑uploaded CDR files and needs to deliver each page as a separate PSD for downstream image analysis.
 */
