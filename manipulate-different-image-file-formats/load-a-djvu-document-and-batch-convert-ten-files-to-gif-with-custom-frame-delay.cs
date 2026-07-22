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

            Directory.CreateDirectory(outputDirectory);

            string[] djvuFiles = Directory.GetFiles(inputDirectory, "*.djvu");
            int filesToProcess = Math.Min(10, djvuFiles.Length);

            for (int i = 0; i < filesToProcess; i++)
            {
                string inputPath = djvuFiles[i];

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".gif";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    GifOptions gifOptions = new GifOptions();
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
 * 1. When a developer needs to automate the conversion of scanned multi‑page DjVu documents into animated GIFs for web preview, they can use this C# code with Aspose.Imaging to read each DjVu file and save it as a GIF.
 * 2. When an archival system must generate lightweight GIF thumbnails from a batch of DjVu files for quick indexing, the code provides a simple loop that processes up to ten files at a time.
 * 3. When a document‑management application requires server‑side conversion of user‑uploaded DjVu files to GIF format with configurable frame delay, the example shows how to open the DjVu stream and apply GifOptions before saving.
 * 4. When a migration tool needs to replace legacy DjVu assets with GIF equivalents for compatibility with older browsers, this snippet demonstrates the file‑system handling and image‑format conversion in C#.
 * 5. When a digital‑publishing workflow wants to batch‑process a limited set of DjVu illustrations into animated GIFs for inclusion in e‑books, the code illustrates how to create output directories, verify file existence, and perform the conversion using Aspose.Imaging.
 */