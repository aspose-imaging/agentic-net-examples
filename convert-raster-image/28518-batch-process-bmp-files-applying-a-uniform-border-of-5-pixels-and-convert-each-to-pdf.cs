using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

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
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add BMP files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load source BMP image
                using (RasterImage srcImage = (RasterImage)Image.Load(inputPath))
                {
                    int border = 5;
                    int newWidth = srcImage.Width + border * 2;
                    int newHeight = srcImage.Height + border * 2;

                    // Create temporary JPEG canvas bound to a file
                    string tempCanvasPath = Path.Combine(outputDirectory, fileNameWithoutExt + "_temp.jpg");
                    Source tempSource = new FileCreateSource(tempCanvasPath, true);
                    JpegOptions jpegOptions = new JpegOptions() { Source = tempSource, Quality = 100 };

                    using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
                    {
                        // Fill background with white
                        Graphics graphics = new Graphics(canvas);
                        graphics.Clear(Aspose.Imaging.Color.White);

                        // Draw the source image onto the canvas with border offset
                        Rectangle destRect = new Rectangle(border, border, srcImage.Width, srcImage.Height);
                        canvas.SaveArgb32Pixels(destRect, srcImage.LoadArgb32Pixels(srcImage.Bounds));

                        // Save canvas as PDF
                        PdfOptions pdfOptions = new PdfOptions();
                        canvas.Save(outputPath, pdfOptions);
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