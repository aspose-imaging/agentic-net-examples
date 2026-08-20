// HOW-TO: Batch Convert SVG Files to PDF with Filename Footer in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
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

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image svgImage = Image.Load(inputPath))
                {
                    using (MemoryStream pngStream = new MemoryStream())
                    {
                        var pngOptions = new PngOptions();
                        pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = svgImage.Width,
                            PageHeight = svgImage.Height
                        };
                        svgImage.Save(pngStream, pngOptions);
                        pngStream.Position = 0;

                        using (RasterImage rasterSvg = (RasterImage)Image.Load(pngStream))
                        {
                            var pdfOptions = new PdfOptions();
                            pdfOptions.Source = new FileCreateSource(outputPath, false);
                            using (Image pdfImage = Image.Create(pdfOptions, svgImage.Width, svgImage.Height))
                            {
                                Graphics graphics = new Graphics(pdfImage);
                                graphics.Clear(Color.White);
                                graphics.DrawImage(rasterSvg, new Point(0, 0));

                                Font font = new Font("Arial", 12, FontStyle.Regular);
                                using (SolidBrush brush = new SolidBrush(Color.Black))
                                {
                                    int footerY = svgImage.Height - 20;
                                    graphics.DrawString(fileName, font, brush, new Point(10, footerY));
                                }

                                pdfImage.Save();
                            }
                        }
                    }
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
 * 1. When you need to automatically generate printable PDFs from a collection of SVG icons and include each original file name as a footer for documentation purposes.
 * 2. When a web application must batch‑process user‑uploaded SVG diagrams into PDF reports while labeling each page with the source file name.
 * 3. When a CI/CD pipeline should convert design assets stored as SVG into PDF assets and embed the asset name for version tracking.
 * 4. When an enterprise system has to archive vector graphics as PDFs and add a filename footer to comply with audit‑trail requirements.
 * 5. When a desktop utility must scan a folder of SVG logos, create PDF versions, and append the logo name at the bottom for easy identification.
 */
