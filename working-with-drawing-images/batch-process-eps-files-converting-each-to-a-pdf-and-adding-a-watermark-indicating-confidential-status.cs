using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Get all EPS files in the input directory
        string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

        foreach (string epsPath in epsFiles)
        {
            // Verify input file exists
            if (!File.Exists(epsPath))
            {
                Console.Error.WriteLine($"File not found: {epsPath}");
                return;
            }

            // Prepare output PDF path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(epsPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

            // Ensure output directory exists (unconditional creation)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(epsPath))
            {
                // Add watermark text
                var graphics = new Graphics(epsImage);
                var font = new Font("Arial", 48);
                var brush = new SolidBrush(Color.Yellow);
                // Position watermark at the center of the image
                var position = new PointF(epsImage.Width / 2f, epsImage.Height / 2f);
                graphics.DrawString("CONFIDENTIAL", font, brush, position);

                // Save as PDF
                var pdfOptions = new PdfOptions();
                epsImage.Save(outputPath, pdfOptions);
            }
        }
    }
}