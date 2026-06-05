using System;
using System.IO;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
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

            // Define the rectangular regions to extract (example values)
            Aspose.Imaging.Rectangle[] regions = new Aspose.Imaging.Rectangle[]
            {
                new Aspose.Imaging.Rectangle(0, 0, 500, 500),
                new Aspose.Imaging.Rectangle(100, 100, 300, 300)
            };

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                using (FileStream stream = File.OpenRead(inputPath))
                {
                    using (DjvuImage djvu = new DjvuImage(stream))
                    {
                        string baseName = Path.GetFileNameWithoutExtension(inputPath);

                        for (int i = 0; i < regions.Length; i++)
                        {
                            Aspose.Imaging.Rectangle rect = regions[i];
                            string outputPath = Path.Combine(outputDirectory, $"{baseName}_region{i}.png");

                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            PngOptions pngOptions = new PngOptions();
                            pngOptions.MultiPageOptions = new DjvuMultiPageOptions(0, rect); // page index 0

                            djvu.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to extract specific pages or sections from a collection of scanned DjVu documents and save them as high‑resolution PNG thumbnails for a web preview gallery.
 * 2. When an archival system must automate the conversion of selected rectangular regions of multiple DjVu files into PNG images for OCR preprocessing.
 * 3. When a digital publishing workflow requires batch extraction of logo or watermark areas from DjVu source files and exporting them as PNG assets for reuse in marketing materials.
 * 4. When a document management application wants to generate PNG snapshots of defined diagram regions across many DjVu engineering drawings for quick reference in a mobile app.
 * 5. When a data‑migration script has to process a folder of DjVu files, crop out predefined rectangles, and store the results as PNG files to integrate with a legacy image database.
 */