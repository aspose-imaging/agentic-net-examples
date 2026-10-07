// HOW-TO: Rotate DjVu Pages 90 Degrees and Convert to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.djvu";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                for (int i = 0; i < djvu.Pages.Length; i++)
                {
                    using (RasterImage page = (RasterImage)djvu.Pages[i])
                    {
                        page.Rotate(90f, true, Color.White);

                        string outputPath = Path.Combine(outputDirectory, $"page_{i}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        using (PngOptions options = new PngOptions())
                        {
                            options.Source = new FileCreateSource(outputPath, false);
                            page.Save(outputPath, options);
                        }
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
 * 1. When you need to display scanned DjVu documents correctly on a web page that only supports PNG images, you can rotate each page and convert them to PNG files.
 * 2. When processing multi‑page DjVu files from a legacy archive and the pages are stored sideways, you can programmatically rotate them 90° before saving as PNG for further analysis.
 * 3. When creating thumbnails for a document viewer that requires PNG format, rotating the DjVu pages ensures the thumbnails have the proper orientation.
 * 4. When automating batch conversion of DjVu manuals into PNG images for printing, applying a rotation fixes orientation issues caused by scanned pages.
 * 5. When integrating Aspose.Imaging into a C# workflow to extract each page of a DjVu file, rotate it, and store it as a lossless PNG for archival purposes.
 */
