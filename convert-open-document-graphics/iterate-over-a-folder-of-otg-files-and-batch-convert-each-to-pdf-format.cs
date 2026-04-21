using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        string[] files = Directory.GetFiles(inputDirectory, "*.otg");

        foreach (string inputPath in files)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var otgOptions = new OtgRasterizationOptions();
                otgOptions.PageSize = image.Size;
                otgOptions.BackgroundColor = Aspose.Imaging.Color.White;

                var pdfOptions = new PdfOptions();
                pdfOptions.VectorRasterizationOptions = otgOptions;

                image.Save(outputPath, pdfOptions);
            }
        }
    }
}