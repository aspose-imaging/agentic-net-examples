// HOW-TO: Convert DjVu Pages 3 to 7 to GIF with Memory Optimization in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\document.djvu";
            string outputPath = "Output\\range3to7.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var loadOptions = new LoadOptions { BufferSizeHint = 1048576 };

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath, loadOptions))
            {
                var gifOptions = new GifOptions();
                gifOptions.MultiPageOptions = new DjvuMultiPageOptions(new IntRange(3, 7));

                djvu.Save(outputPath, gifOptions);
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
 * 1. When you need to extract a specific range of pages from a large DjVu document and create a lightweight animated GIF for web preview, this code handles the conversion efficiently.
 * 2. When processing high‑resolution DjVu files on a server with limited RAM, the BufferSizeHint setting reduces memory usage while converting selected pages to GIF.
 * 3. When building a document‑to‑image pipeline that only requires pages 3 through 7 of a multi‑page DjVu, this example shows how to isolate and save those pages as a single GIF file.
 * 4. When integrating Aspose.Imaging into a C# application to generate GIF thumbnails from a subset of DjVu pages for email attachments, the code demonstrates the necessary steps.
 * 5. When automating batch conversion of DjVu archives and you want to limit the output to a specific page range to save storage space, this snippet provides a ready‑to‑use solution.
 */
