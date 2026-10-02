// HOW-TO: Batch Convert Up To 30 DjVu Files To TIFF In C# (Aspose.Imaging for .NET)
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

            string[] files = Directory.GetFiles(inputDirectory, "*.djvu");
            int processed = 0;

            foreach (var inputPath in files)
            {
                if (processed >= 30)
                    break;

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".tiff");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
                {
                    using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                    {
                        djvu.Save(outputPath, tiffOptions);
                    }
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
 * 1. When a developer needs to automate conversion of a large set of scanned DjVu documents into multi‑page TIFF files for archival or OCR processing.
 * 2. When an application must limit the conversion to the first thirty DjVu files in a folder to avoid excessive memory usage.
 * 3. When a batch job has to create TIFF versions of DjVu files to ensure compatibility with legacy systems that only accept TIFF.
 * 4. When a C# service processes incoming DjVu uploads and stores them as TIFF images for downstream image analysis pipelines.
 * 5. When a developer wants to use a foreach loop to iterate through files, load each DjVu image, and save it with default TIFF options in a specified output directory.
 */
