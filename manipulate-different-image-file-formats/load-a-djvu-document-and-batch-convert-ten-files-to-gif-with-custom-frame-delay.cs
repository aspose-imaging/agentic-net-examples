using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            string[] files = Directory.GetFiles(inputDirectory, "*.djvu");
            int filesToProcess = Math.Min(10, files.Length);

            Directory.CreateDirectory(outputDirectory);

            for (int i = 0; i < filesToProcess; i++)
            {
                string inputPath = files[i];
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".gif");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
                {
                    var gifOptions = new GifOptions();
                    djvuImage.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to convert a collection of scanned DjVu documents into animated GIFs for web preview, they can use this batch conversion code to process up to ten files at a time.
 * 2. When an archival system stores multi‑page DjVu files and the UI requires lightweight GIF thumbnails with custom frame delays, the code provides a quick C# solution to generate those GIFs in bulk.
 * 3. When a digital publishing workflow must transform DjVu e‑books into GIF animations for mobile devices, the example shows how to load each DjVu image and save it as a GIF using Aspose.Imaging.
 * 4. When a content‑management script has to automate the migration of legacy DjVu graphics to GIF format for compatibility with older browsers, this snippet handles the file‑system operations and image conversion in a loop.
 * 5. When a developer is building a batch‑processing tool that reads DjVu files from an input folder, creates GIF output with specific options, and limits the run to the first ten files, the provided code demonstrates the required C# logic.
 */