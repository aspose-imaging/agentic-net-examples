using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

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

            int processed = 0;
            foreach (string inputPath in files)
            {
                if (processed >= 30)
                    break;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".tif");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    image.Save(outputPath, tiffOptions);
                }

                processed++;
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
 * 1. When a developer needs to migrate a large collection of scanned archival documents stored as DjVu files into a widely supported TIFF format for integration with enterprise document management systems.
 * 2. When an application must automatically process up to thirty DjVu pages at a time, converting each to TIFF for downstream OCR processing in a C# batch workflow.
 * 3. When a digital publishing pipeline requires converting user‑uploaded DjVu illustrations to TIFF thumbnails in a server‑side .NET service using a foreach loop.
 * 4. When a legal firm wants to batch convert a folder of DjVu evidence files to TIFF to ensure compatibility with court‑approved imaging software.
 * 5. When a cloud‑based image processing API needs to limit the number of DjVu files it converts per request, saving each result as a TIFF file in an output directory.
 */