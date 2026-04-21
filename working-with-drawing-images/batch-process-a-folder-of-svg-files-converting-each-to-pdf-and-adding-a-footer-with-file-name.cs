using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Brushes;

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
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add SVG files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        string[] files = Directory.GetFiles(inputDirectory, "*.svg");

        foreach (var filePath in files)
        {
            string inputPath = filePath;
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string pdfPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height
                    }
                })
                {
                    svgImage.Save(pdfPath, pdfOptions);
                }
            }

            using (Image pdfImage = Image.Load(pdfPath))
            {
                Graphics graphics = new Graphics(pdfImage);

                Font font = new Font("Arial", 12, FontStyle.Regular);
                using (SolidBrush brush = new SolidBrush(Color.Black))
                {
                    int margin = 10;
                    int yPosition = pdfImage.Height - margin - 12;
                    graphics.DrawString(fileNameWithoutExt, font, brush, new Point(margin, yPosition));
                }

                pdfImage.Save(pdfPath);
            }
        }
    }
}