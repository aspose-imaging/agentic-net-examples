using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputEps";
            string outputFolder = "OutputPdf";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all EPS files in the input folder
            var epsFiles = Directory.GetFiles(inputFolder, "*.eps");

            foreach (var epsPath in epsFiles)
            {
                if (!File.Exists(epsPath))
                {
                    Console.Error.WriteLine($"File not found: {epsPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(epsPath);
                string pdfPath = Path.Combine(outputFolder, fileName + ".pdf");

                // Ensure output directory exists (unconditional)
                Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

                using (var image = (EpsImage)Image.Load(epsPath))
                {
                    // Add watermark text
                    var graphics = new Graphics(image);
                    var font = new Font("Arial", 36);
                    var brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0)); // semi‑transparent red
                    graphics.DrawString("CONFIDENTIAL", font, brush, new PointF(10, 10));

                    var pdfOptions = new PdfOptions();
                    image.Save(pdfPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}