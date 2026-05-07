using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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
            // Hardcoded input and output paths
            string inputPath1 = "Input/image1.jpg";
            string inputPath2 = "Input/image2.jpg";
            string outputPath = "Output/merged.pdf";

            // Validate input files
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect image sizes
            List<Size> sizes = new List<Size>();
            using (JpegImage img1 = (JpegImage)Image.Load(inputPath1))
            {
                sizes.Add(img1.Size);
            }
            using (JpegImage img2 = (JpegImage)Image.Load(inputPath2))
            {
                sizes.Add(img2.Size);
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Create a temporary JPEG canvas with 300 DPI
            string tempCanvasPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp_canvas.jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(tempCanvasPath));
            Source tempSource = new FileCreateSource(tempCanvasPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = tempSource,
                Quality = 100,
                ResolutionSettings = new ResolutionSetting(300, 300),
                ResolutionUnit = ResolutionUnit.Inch
            };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                // Merge first image
                int offsetX = 0;
                using (JpegImage img1 = (JpegImage)Image.Load(inputPath1))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img1.Width, img1.Height);
                    canvas.SaveArgb32Pixels(bounds, img1.LoadArgb32Pixels(img1.Bounds));
                    offsetX += img1.Width;
                }

                // Merge second image
                using (JpegImage img2 = (JpegImage)Image.Load(inputPath2))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img2.Width, img2.Height);
                    canvas.SaveArgb32Pixels(bounds, img2.LoadArgb32Pixels(img2.Bounds));
                    offsetX += img2.Width;
                }

                // Save the merged canvas as PDF
                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}