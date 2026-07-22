using System;
using System.IO;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.djvu";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDirectory = "Output";

            Directory.CreateDirectory(outputDirectory);

            using (Stream stream = File.OpenRead(inputPath))
            {
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    for (int i = 0; i < djvuImage.Pages.Length; i++)
                    {
                        using (DjvuPage page = (DjvuPage)djvuImage.Pages[i])
                        {
                            string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.png");

                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            PngOptions pngOptions = new PngOptions
                            {
                                FilterType = PngFilterType.Sub
                            };

                            page.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to extract each page of a multi‑page DjVu file and generate high‑quality PNG images for web preview, they can use this code to load the DjVu document, apply a Sub filter, and save each page as a separate PNG file.
 * 2. When an archival system requires converting scanned DjVu documents into lossless PNGs for long‑term storage while controlling compression via PngOptions.FilterType, this snippet provides the necessary C# workflow.
 * 3. When a mobile app must display DjVu content as PNG thumbnails on devices that do not support DjVu, the code can read the DjVu stream, iterate through pages, and output PNGs with a custom filter for faster rendering.
 * 4. When a batch processing pipeline needs to automate the conversion of a folder of DjVu files into page‑by‑page PNG assets for OCR processing, the example shows how to read, filter, and save each page programmatically.
 * 5. When a developer is building a document‑to‑image service that offers downloadable PNG versions of each DjVu page with optimized filtering for reduced file size, this code demonstrates the required steps in .NET.
 */