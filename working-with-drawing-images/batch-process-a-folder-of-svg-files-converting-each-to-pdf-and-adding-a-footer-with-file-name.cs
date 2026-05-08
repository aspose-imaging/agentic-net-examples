using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Batch processing directories
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

            // Get all SVG files in the input folder
            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (var inputPath in files)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load SVG image
                using (Image image = Image.Load(inputPath))
                {
                    var svgImage = image as SvgImage;
                    if (svgImage == null)
                    {
                        Console.Error.WriteLine($"Failed to load SVG: {inputPath}");
                        continue;
                    }

                    int width = svgImage.Width;
                    int height = svgImage.Height;

                    // Create PDF canvas bound to the output file
                    using (PdfOptions pdfOptions = new PdfOptions())
                    {
                        pdfOptions.Source = new FileCreateSource(outputPath, false);
                        using (Image pdfImage = Image.Create(pdfOptions, width, height))
                        {
                            // Draw the SVG onto the PDF
                            Graphics graphics = new Graphics(pdfImage);
                            graphics.DrawImage(svgImage, new Point(0, 0));

                            // Add footer text with the file name
                            using (var brush = new SolidBrush(Color.Black))
                            {
                                Font font = new Font("Arial", 12, FontStyle.Regular);
                                graphics.DrawString(fileName, font, brush, new Point(10, height - 20));
                            }

                            // Save the bound PDF
                            pdfImage.Save();
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