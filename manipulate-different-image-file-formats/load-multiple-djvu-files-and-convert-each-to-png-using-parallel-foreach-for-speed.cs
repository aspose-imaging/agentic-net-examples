// HOW-TO: Convert Multiple DjVu Files to PNG in Parallel with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

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

            Parallel.ForEach(files, filePath =>
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DjvuImage djvuImage = (DjvuImage)Image.Load(filePath))
                {
                    using (PngOptions pngOptions = new PngOptions())
                    {
                        djvuImage.Save(outputPath, pngOptions);
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
 * 1. When you need to batch‑convert a large collection of scanned DjVu documents into PNG images for web preview, this code speeds up the process by using parallel execution.
 * 2. When a document‑management system stores pages as DjVu files and requires PNG thumbnails for UI thumbnails, the example shows how to generate them concurrently.
 * 3. When migrating legacy DjVu archives to a more widely supported format, you can run this routine to transform all files at once without blocking the main thread.
 * 4. When building a server‑side service that receives multiple DjVu uploads and must return PNG versions quickly, Parallel.ForEach provides the necessary scalability.
 * 5. When automating a nightly job that extracts images from DjVu ebooks and saves them as PNG for further analysis, this code handles the batch conversion efficiently.
 */
