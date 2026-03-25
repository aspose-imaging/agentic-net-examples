using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        Directory.CreateDirectory(outputDirectory);

        string[] files = Directory.GetFiles(inputDirectory, "*.cmx");

        foreach (var filePath in files)
        {
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"File not found: {filePath}");
                return;
            }

            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(filePath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    var vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };
                    pdfOptions.VectorRasterizationOptions = vectorOptions;

                    image.Save(outputPath, pdfOptions);
                }
            }
        }
    }
}