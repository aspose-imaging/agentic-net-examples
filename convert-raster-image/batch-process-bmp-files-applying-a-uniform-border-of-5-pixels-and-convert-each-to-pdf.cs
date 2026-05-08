using System;
using System.IO;
using System.Linq;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.RasterImage src = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    int border = 5;
                    int newWidth = src.Width + border * 2;
                    int newHeight = src.Height + border * 2;

                    // Create a blank canvas
                    BmpOptions canvasOptions = new BmpOptions();
                    using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(canvasOptions, newWidth, newHeight))
                    {
                        // Fill canvas with white background
                        Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                        graphics.Clear(Aspose.Imaging.Color.White);

                        // Draw the source image onto the canvas with border offset
                        Aspose.Imaging.Rectangle destRect = new Aspose.Imaging.Rectangle(border, border, src.Width, src.Height);
                        canvas.SaveArgb32Pixels(destRect, src.LoadArgb32Pixels(src.Bounds));

                        // Save the canvas as PDF
                        canvas.Save(outputPath, new PdfOptions());
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