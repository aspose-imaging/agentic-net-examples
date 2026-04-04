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
        // Hardcoded input and output directories
        string inputFolder = "InputEps";
        string outputFolder = "OutputPdf";

        // Ensure input directory exists; create if missing and exit
        if (!Directory.Exists(inputFolder))
        {
            Directory.CreateDirectory(inputFolder);
            Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        // Process each EPS file in the input folder
        string[] epsFiles = Directory.GetFiles(inputFolder, "*.eps");
        foreach (string filePath in epsFiles)
        {
            // Verify the file exists
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"File not found: {filePath}");
                return;
            }

            // Determine output PDF path
            string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(filePath) + ".pdf");

            // Ensure the output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load EPS image
            using (EpsImage epsImage = (EpsImage)Image.Load(filePath))
            {
                // Add watermark text
                Graphics graphics = new Graphics(epsImage);
                Font font = new Font("Arial", 48);
                SolidBrush brush = new SolidBrush(Color.Yellow);
                graphics.DrawString("CONFIDENTIAL", font, brush, new PointF(10, 10));

                // Save as PDF
                epsImage.Save(outputPath, new PdfOptions());
            }
        }
    }
}