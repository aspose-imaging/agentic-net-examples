using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string jpegOutputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");
                string pngOutputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(jpegOutputPath));
                Directory.CreateDirectory(Path.GetDirectoryName(pngOutputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (JpegOptions jpegOptions = new JpegOptions())
                    {
                        image.Save(jpegOutputPath, jpegOptions);
                    }

                    using (PngOptions pngOptions = new PngOptions())
                    {
                        image.Save(pngOutputPath, pngOptions);
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
 * 1. When a developer must convert a large collection of vector drawings into high‑resolution JPEGs for fast web preview and lossless PNGs for print‑ready distribution, this C# batch‑processing code provides an automated solution.
 * 2. When an e‑commerce platform needs to generate both compressed JPEG thumbnails and full‑quality PNG assets from supplier‑provided SVG or AI files, the code can be integrated into the image pipeline.
 * 3. When a marketing team requires daily conversion of newly uploaded vector artwork into dual formats for email campaigns (JPEG) and social media posts (PNG), the script automates the task on a Windows server.
 * 4. When a document management system has to archive vector illustrations as JPEG for quick indexing and PNG for archival integrity, developers can employ this code to process all files in a designated folder.
 * 5. When a desktop publishing workflow demands simultaneous creation of screen‑optimized JPEGs and lossless PNGs from source vector files before sending them to designers and printers, this example handles the batch conversion in C#.
 */