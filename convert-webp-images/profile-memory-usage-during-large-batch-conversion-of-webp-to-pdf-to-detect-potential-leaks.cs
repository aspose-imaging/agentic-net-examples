using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Pdf;

public class Program
{
    public static void Main(string[] args)
    {
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        string[] files = Directory.GetFiles(inputDirectory, "*.webp", SearchOption.AllDirectories);

        foreach (string inputPath in files)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            long memBeforeLoad = GC.GetTotalMemory(true);
            Console.WriteLine($"Memory before loading '{inputPath}': {memBeforeLoad} bytes");

            using (Image image = Image.Load(inputPath))
            {
                long memAfterLoad = GC.GetTotalMemory(true);
                Console.WriteLine($"Memory after loading '{inputPath}': {memAfterLoad} bytes");

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    image.Save(outputPath, pdfOptions);
                }

                long memAfterSave = GC.GetTotalMemory(true);
                Console.WriteLine($"Memory after saving '{outputPath}': {memAfterSave} bytes");
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}