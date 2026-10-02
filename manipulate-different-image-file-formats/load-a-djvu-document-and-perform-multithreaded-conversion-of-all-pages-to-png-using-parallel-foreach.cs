// HOW-TO: Convert DjVu Document Pages to PNG in Parallel with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.djvu";
        string outputDir = "output";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(outputDir);

        try
        {
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvu.Pages.Length;
                Parallel.ForEach(Enumerable.Range(0, pageCount), i =>
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    using (RasterImage page = (RasterImage)djvu.Pages[i])
                    {
                        PngOptions options = new PngOptions();
                        page.Save(outputPath, options);
                    }
                });
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
 * 1. When you need to extract every page of a multi‑page DjVu file and save them as high‑quality PNG images for web preview, this code performs the conversion quickly using parallel processing.
 * 2. When a document‑management system must generate thumbnail PNGs from large DjVu archives on a server, the multithreaded approach reduces CPU time and speeds up batch jobs.
 * 3. When integrating Aspose.Imaging into a C# application that processes scanned books stored as DjVu, you can use this pattern to convert each page to PNG for OCR or further image analysis.
 * 4. When automating the migration of legacy DjVu manuals to a modern PNG‑based asset pipeline, the code creates individual PNG files for each page while taking advantage of all CPU cores.
 * 5. When building a cloud service that receives DjVu uploads and returns separate PNG pages for client‑side rendering, Parallel.ForEach ensures the conversion scales efficiently with large documents.
 */
