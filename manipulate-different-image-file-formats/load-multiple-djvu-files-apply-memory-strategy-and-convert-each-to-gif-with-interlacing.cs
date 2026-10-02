// HOW-TO: Batch Convert DjVu Files to Interlaced GIFs with Memory Optimization in C# (Aspose.Imaging for .NET)
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

            string[] files = Directory.GetFiles(inputDirectory, "*.djvu", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath, new LoadOptions { BufferSizeHint = 1024 * 1024 }))
                {
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".gif");

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (GifOptions gifOptions = new GifOptions())
                    {
                        gifOptions.Interlaced = true;
                        djvu.Save(outputPath, gifOptions);
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
 * 1. When you need to generate web‑ready interlaced GIF previews from a collection of scanned DjVu documents while keeping memory usage low.
 * 2. When an archival system must automatically transform uploaded DjVu files into animated GIFs for compatibility with legacy browsers.
 * 3. When a desktop application processes large DjVu image batches and requires efficient loading using BufferSizeHint to avoid out‑of‑memory errors.
 * 4. When you want to create a folder of GIF assets from DjVu source files for use in email newsletters that require interlaced images for progressive rendering.
 * 5. When a server‑side service converts user‑submitted DjVu files to interlaced GIFs in bulk to reduce bandwidth and improve loading speed on mobile devices.
 */
