// HOW-TO: Convert Up to 50 DjVu Files to PNG in Parallel with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
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

            string[] allFiles = Directory.GetFiles(inputDirectory, "*.djvu");
            var files = allFiles.Take(50).ToArray();

            Parallel.ForEach(files, file =>
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DjvuImage djvu = (DjvuImage)Image.Load(file))
                {
                    using (var pngOptions = new PngOptions())
                    {
                        pngOptions.Source = new FileCreateSource(outputPath, false);
                        pngOptions.MultiPageOptions = new DjvuMultiPageOptions(0);
                        djvu.Save(outputPath, pngOptions);
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
 * 1. When you need to quickly generate PNG previews of a large set of DjVu documents for a web gallery.
 * 2. When a document management system must batch‑process DjVu files into PNG for OCR or indexing.
 * 3. When you want to speed up conversion of scanned DjVu pages to PNG using multi‑core CPUs in a C# service.
 * 4. When an automated pipeline has to limit conversion to the first 50 DjVu files in a folder to control resource usage.
 * 5. When you need to save each DjVu page as a separate PNG file while preserving the original file names in a .NET application.
 */
