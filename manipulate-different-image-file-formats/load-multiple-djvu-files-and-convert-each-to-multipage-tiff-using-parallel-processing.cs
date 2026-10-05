// HOW-TO: Convert Multiple DjVu Files To Multipage TIFF In Parallel With C# (Aspose.Imaging for .NET)
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
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.djvu");

            System.Threading.Tasks.Parallel.ForEach(files, inputPath =>
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".tif");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    djvu.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to batch‑convert a large collection of scanned DjVu documents into searchable multipage TIFFs for archival systems, this code provides a fast parallel solution.
 * 2. When integrating a document‑management workflow that receives DjVu files from users and must store them as TIFF images compatible with existing .NET applications, the example shows how to automate the conversion.
 * 3. When optimizing server‑side processing time for converting dozens of DjVu pages into a single TIFF per file, the parallel loop reduces overall execution time.
 * 4. When preparing DjVu‑based e‑books for printing or OCR pipelines that require multipage TIFF input, this snippet demonstrates the required format conversion using Aspose.Imaging.
 * 5. When building a background service that monitors an input folder and instantly transforms any new DjVu files into TIFFs without blocking other operations, the code illustrates the necessary file handling and parallel execution.
 */
