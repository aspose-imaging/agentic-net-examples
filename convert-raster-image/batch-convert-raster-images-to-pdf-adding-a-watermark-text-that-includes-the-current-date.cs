using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input image paths
        string[] inputPaths = {
            "image1.jpg",
            "image2.png",
            "image3.bmp"
        };

        foreach (string inputPath in inputPaths)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Determine output PDF path
            string outputPath = Path.ChangeExtension(inputPath, ".pdf");
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Cast to RasterImage for drawing
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                // Create graphics object (do NOT wrap in using)
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(raster);

                // Prepare watermark text with current date
                string watermarkText = $"Generated on {DateTime.Now:yyyy-MM-dd}";

                // Create font and brush
                Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 24);
                Aspose.Imaging.Brushes.SolidBrush brush = new Aspose.Imaging.Brushes.SolidBrush(Aspose.Imaging.Color.Yellow);

                // Position the text at bottom‑right corner with a small margin
                float margin = 10f;
                float x = raster.Width - margin;
                float y = raster.Height - margin;
                Aspose.Imaging.PointF position = new Aspose.Imaging.PointF(x, y);

                // Draw the watermark text
                graphics.DrawString(watermarkText, font, brush, position);

                // Save as PDF
                PdfOptions pdfOptions = new PdfOptions();
                raster.Save(outputPath, pdfOptions);
            }
        }
    }
}