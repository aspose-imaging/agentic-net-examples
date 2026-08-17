// HOW-TO: Batch Convert EPS to PDF with Confidential Watermark in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "input_eps";
            string outputDir = "output_pdf";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add EPS files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            var epsFiles = Directory.GetFiles(inputDir, "*.eps");
            foreach (var epsPath in epsFiles)
            {
                if (!File.Exists(epsPath))
                {
                    Console.Error.WriteLine($"File not found: {epsPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(epsPath);
                string pdfPath = Path.Combine(outputDir, fileName + ".pdf");

                // Ensure output directory exists before saving PDF
                Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

                // Convert EPS to PDF
                using (var epsImage = (EpsImage)Image.Load(epsPath))
                {
                    var pdfOptions = new PdfOptions();
                    epsImage.Save(pdfPath, pdfOptions);
                }

                // Load the generated PDF to add watermark
                using (var pdfImage = Image.Load(pdfPath))
                {
                    var raster = (RasterImage)pdfImage;

                    // Draw watermark text
                    var graphics = new Graphics(raster);
                    var font = new Font("Arial", 48);
                    var brush = new SolidBrush(Color.Red);
                    var position = new PointF(10, 10);
                    graphics.DrawString("CONFIDENTIAL", font, brush, position);

                    // Ensure output directory exists before saving final PDF
                    Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));
                    var saveOptions = new PdfOptions();
                    raster.Save(pdfPath, saveOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a company needs to archive multiple EPS design files as PDF documents while marking them as confidential.
 * 2. When an automated publishing pipeline must transform vector EPS artwork into PDF format and embed a security watermark before distribution.
 * 3. When a legal department wants to batch‑process client‑submitted EPS drawings, convert them to PDF, and label each file as confidential for internal review.
 * 4. When a cloud service generates PDF reports from EPS charts and must add a "Confidential" overlay to comply with data‑privacy policies.
 * 5. When a desktop utility is required to convert a folder of EPS logos into PDFs and apply a watermark to prevent unauthorized reuse.
 */
