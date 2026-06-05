using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

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

            foreach (var inputPath in files.Take(30))
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".tiff");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
                {
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    djvuImage.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to batch convert a collection of DjVu documents to TIFF files using C# and Aspose.Imaging for archival or printing purposes.
 * 2. When an automated .NET service must read up to thirty DjVu files from an input directory, loop through them with a foreach construct, and save each as a TIFF to ensure compatibility with legacy imaging pipelines.
 * 3. When a document management application requires converting user‑uploaded DjVu images to TIFF format on the fly, using Aspose.Imaging’s Image.Load and TiffOptions within a foreach loop.
 * 4. When a background job has to process a folder of DjVu scans, skip any missing files, and generate corresponding TIFF files for downstream OCR or indexing workflows.
 * 5. When a developer wants to create a simple console utility that creates an output folder, loads DjVu files, and batch converts the first thirty pages to TIFF while handling exceptions gracefully.
 */