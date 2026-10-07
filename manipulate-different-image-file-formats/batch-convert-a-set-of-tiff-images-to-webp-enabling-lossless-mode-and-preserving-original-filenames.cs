// HOW-TO: Batch Convert TIFF Images to Lossless WebP in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

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

            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string inputPath in files)
            {
                string ext = Path.GetExtension(inputPath).ToLowerInvariant();
                if (ext != ".tif" && ext != ".tiff")
                {
                    continue;
                }

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".webp");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (WebPOptions options = new WebPOptions())
                    {
                        options.Lossless = true;
                        image.Save(outputPath, options);
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
 * 1. When you need to shrink a collection of high‑resolution TIFF scans for web delivery while keeping them lossless, you can batch convert them to WebP using this code.
 * 2. When migrating a legacy archive of medical or satellite TIFF files to a modern, browser‑compatible format without altering original filenames, this routine automates the conversion.
 * 3. When building an automated image‑processing pipeline that receives TIFF uploads and must store them as compact WebP assets for a content‑management system, the sample shows how to do it in C#.
 * 4. When creating a backup script that preserves the original file names while converting TIFF documents to a smaller, lossless format for cloud storage, this code provides the necessary steps.
 * 5. When developing a desktop utility that lets users drop a folder of TIFF pictures and instantly get matching WebP files for faster loading in web applications, the example demonstrates the required logic.
 */
