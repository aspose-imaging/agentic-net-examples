using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.djvu");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
                {
                    int pageCount = djvuImage.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        Rectangle exportArea = new Rectangle(100, 100, 300, 300);
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{i}.png";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        using (PngOptions pngOptions = new PngOptions())
                        {
                            pngOptions.MultiPageOptions = new DjvuMultiPageOptions(i, exportArea);
                            djvuImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to extract specific rectangular regions from multiple DjVu documents and automatically generate PNG thumbnails for each page in a batch workflow.
 * 2. When an archival system must convert selected areas of scanned DjVu files into high‑resolution PNG images for web preview without manual file handling.
 * 3. When a document‑management application requires programmatically saving only a defined portion of each DjVu page as separate PNG files for downstream OCR processing.
 * 4. When a publishing pipeline needs to create page‑by‑page PNG assets from a collection of DjVu files, focusing on a particular region such as a logo or watermark.
 * 5. When a GIS or mapping tool must batch‑process DjVu maps, extracting a fixed viewport rectangle from each page and exporting it as PNG for integration into other .NET services.
 */