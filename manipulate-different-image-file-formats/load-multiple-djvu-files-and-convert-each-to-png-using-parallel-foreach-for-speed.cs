using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

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

            System.Threading.Tasks.Parallel.ForEach(files, inputPath =>
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string baseFileName = Path.GetFileNameWithoutExtension(inputPath);
                using (Stream stream = File.OpenRead(inputPath))
                {
                    using (DjvuImage djvuImage = new DjvuImage(stream))
                    {
                        int pageIndex = 0;
                        foreach (DjvuPage page in djvuImage.Pages)
                        {
                            string outputPath = Path.Combine(outputDirectory, $"{baseFileName}_page{pageIndex}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            page.Save(outputPath, new PngOptions());
                            pageIndex++;
                        }
                    }
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑convert a library of scanned DjVu documents into individual PNG images for web preview, using C# and Aspose.Imaging to speed up processing with Parallel.ForEach.
 * 2. When an archival system must extract every page of multi‑page DjVu files and store them as PNG thumbnails for quick indexing, leveraging Aspose.Imaging’s DjvuImage and PngOptions classes.
 * 3. When a document‑management application requires automated conversion of incoming DjVu uploads into PNG files so they can be displayed in browsers that only support raster formats.
 * 4. When a background service has to process large volumes of DjVu files on a server and generate PNG assets concurrently to reduce CPU time and improve throughput.
 * 5. When a migration tool needs to read DjVu pages from a directory, convert each page to a lossless PNG, and save them in a structured output folder while handling missing files gracefully.
 */