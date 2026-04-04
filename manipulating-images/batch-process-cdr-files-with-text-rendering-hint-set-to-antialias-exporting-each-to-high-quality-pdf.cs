using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
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

        string[] files = Directory.GetFiles(inputDirectory, "*.cdr");
        foreach (string file in files)
        {
            string inputPath = file;
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + ".pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage image = (CdrImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
                var rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.AntiAlias,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}