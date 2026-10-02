// HOW-TO: Convert Multiple SVG Files to PDF With Filename Footer In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                string fileName = Path.GetFileName(filePath);
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(fileName) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image svgImage = Image.Load(filePath))
                {
                    var svg = (SvgImage)svgImage;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (PngOptions pngOptions = new PngOptions())
                        {
                            svg.Save(ms, pngOptions);
                            ms.Position = 0;
                            using (RasterImage raster = (RasterImage)Image.Load(ms))
                            {
                                int width = raster.Width;
                                int height = raster.Height;

                                var createSource = new FileCreateSource(outputPath, false);
                                using (PdfOptions pdfOptions = new PdfOptions())
                                {
                                    pdfOptions.Source = createSource;
                                    using (Image pdfImage = Image.Create(pdfOptions, width, height))
                                    {
                                        Graphics graphics = new Graphics(pdfImage);
                                        graphics.Clear(Color.White);
                                        graphics.DrawImage(raster, new Point(0, 0));

                                        using (SolidBrush brush = new SolidBrush(Color.Black))
                                        {
                                            Font font = new Font("Arial", 12);
                                            graphics.DrawString(Path.GetFileNameWithoutExtension(fileName), font, brush, new Point(0, height - 20));
                                        }

                                        pdfImage.Save();
                                    }
                                }
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
 * 1. When you need to generate printable PDFs from a batch of SVG icons and include each original file name as a footer for documentation purposes.
 * 2. When an automated build process must convert design assets stored as SVG into PDF reports while labeling each page with the source filename.
 * 3. When a web service exports user‑uploaded SVG diagrams as PDFs and adds a footer so recipients can identify the original file.
 * 4. When a desktop application prepares a portfolio of vector graphics by converting them to PDF and appending the file name for easy reference.
 * 5. When a data‑migration script moves SVG assets to a PDF archive and requires a visible filename footer for audit trails.
 */
