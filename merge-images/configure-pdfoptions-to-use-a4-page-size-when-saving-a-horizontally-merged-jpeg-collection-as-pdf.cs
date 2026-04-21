using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
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
            // Input JPEG files (hardcoded relative paths)
            string[] inputPaths = new string[]
            {
                "Input/image1.jpg",
                "Input/image2.jpg",
                "Input/image3.jpg"
            };

            // Validate each input file
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Collect image sizes
            List<Size> sizes = new List<Size>();
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(new Size(img.Width, img.Height));
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Prepare temporary JPEG canvas
            string tempJpegPath = "temp/merged.jpg";
            Directory.CreateDirectory(Path.GetDirectoryName(tempJpegPath));
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = new FileCreateSource(tempJpegPath, false),
                Quality = 100
            };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }
                // Save the merged JPEG to the temporary file
                canvas.Save();
            }

            // Convert the merged JPEG to PDF with A4 page size
            string pdfOutputPath = "Output/merged.pdf";
            Directory.CreateDirectory(Path.GetDirectoryName(pdfOutputPath));

            using (Image mergedJpeg = Image.Load(tempJpegPath))
            {
                PdfOptions pdfOptions = new PdfOptions
                {
                    PageSize = new Size(595, 842) // A4 size in points
                };
                mergedJpeg.Save(pdfOutputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}