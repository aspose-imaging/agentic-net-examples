using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add BMP files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all BMP files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

        foreach (string inputPath in files)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output PDF path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

            // Ensure output directory exists for this file
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load source BMP image
            using (RasterImage src = (RasterImage)Image.Load(inputPath))
            {
                // Ensure image data is cached
                if (!src.IsCached)
                {
                    src.CacheData();
                }

                // Calculate canvas size with a 5-pixel border on each side
                int border = 5;
                int canvasWidth = src.Width + border * 2;
                int canvasHeight = src.Height + border * 2;

                // Create a blank canvas
                using (BmpOptions canvasOptions = new BmpOptions())
                {
                    using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, canvasWidth, canvasHeight))
                    {
                        // Fill canvas with white background (border color)
                        Graphics graphics = new Graphics(canvas);
                        graphics.Clear(Aspose.Imaging.Color.White);

                        // Draw the original image onto the canvas at the offset (border, border)
                        graphics.DrawImage(src, new Rectangle(border, border, src.Width, src.Height));

                        // Save the canvas as PDF
                        using (PdfOptions pdfOptions = new PdfOptions())
                        {
                            canvas.Save(outputPath, pdfOptions);
                        }
                    }
                }
            }
        }
    }
}