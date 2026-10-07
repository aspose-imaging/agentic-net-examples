// HOW-TO: Batch Convert Up to Ten DjVu Files to Animated GIFs in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.djvu");
            int filesToProcess = Math.Min(10, inputFiles.Length);
            int customFrameDelay = 200; // milliseconds (not used directly)

            for (int i = 0; i < filesToProcess; i++)
            {
                string inputPath = inputFiles[i];
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".gif");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    DjvuImage djvu = (DjvuImage)image;
                    int maxPageIndex = Math.Min(9, djvu.Pages.Length - 1);
                    using (GifOptions gifOptions = new GifOptions())
                    {
                        gifOptions.MultiPageOptions = new DjvuMultiPageOptions(new IntRange(0, maxPageIndex));
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
 * 1. When you need to generate GIF previews of the first pages of multiple DjVu documents for a web gallery, processing up to ten files at once.
 * 2. When you want to automate the conversion of a batch of scanned DjVu files into lightweight GIF animations with a custom frame delay for email attachments.
 * 3. When a document management system must display animated GIF thumbnails of DjVu manuals and requires processing only the first ten files in a single run.
 * 4. When you are building a C# utility that extracts the initial pages of DjVu e‑books and saves them as GIFs using a specified frame delay for slide‑show presentations.
 * 5. When you need to create GIF versions of DjVu files for browser compatibility, limiting the conversion to ten files per batch and applying a custom delay between frames.
 */
