using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";
            string outputPath = Path.Combine(outputDirectory, "merged.pdf");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect JPEG files
            List<string> allFiles = new List<string>();
            allFiles.AddRange(Directory.GetFiles(inputDirectory, "*.jpg"));
            allFiles.AddRange(Directory.GetFiles(inputDirectory, "*.jpeg"));

            if (allFiles.Count == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // Load images, apply grayscale, and collect sizes
            List<RasterImage> images = new List<RasterImage>();
            List<Size> sizes = new List<Size>();

            foreach (string filePath in allFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                JpegImage img = (JpegImage)Image.Load(filePath);
                img.Grayscale();
                images.Add(img);
                sizes.Add(img.Size);
            }

            // Calculate canvas dimensions for horizontal merge
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Prepare temporary source for canvas creation
            string tempCanvasPath = Path.Combine(outputDirectory, "temp_canvas.jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(tempCanvasPath));
            Source tempSource = new FileCreateSource(tempCanvasPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = tempSource, Quality = 100 };

            // Create canvas and merge images horizontally
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (RasterImage img in images)
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }

                // Save the merged canvas as PDF
                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(outputPath, pdfOptions);
            }

            // Dispose loaded images
            foreach (RasterImage img in images)
            {
                img.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}