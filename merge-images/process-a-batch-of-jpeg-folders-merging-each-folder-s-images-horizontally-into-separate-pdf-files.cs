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
        // Hardcoded input and output root directories
        string inputRoot = "Input";
        string outputRoot = "Output";

        // Ensure the output root directory exists
        Directory.CreateDirectory(outputRoot);

        // Get all subfolders in the input root
        var folders = Directory.GetDirectories(inputRoot);

        foreach (var folder in folders)
        {
            // Collect JPEG files (both .jpg and .jpeg) in the current folder
            var jpgFiles = Directory.GetFiles(folder, "*.jpg");
            var jpegFiles = Directory.GetFiles(folder, "*.jpeg");
            var imageFiles = jpgFiles.Concat(jpegFiles).ToArray();

            if (imageFiles.Length == 0)
                continue; // Skip folders without JPEG images

            // Collect sizes of all images
            List<Size> sizes = new List<Size>();
            foreach (var filePath in imageFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(filePath))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Temporary JPEG file to bind the canvas
            string tempJpegPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".jpg");
            Source tempSource = new FileCreateSource(tempJpegPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = tempSource, Quality = 100 };

            // Create JPEG canvas
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (var filePath in imageFiles)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    using (RasterImage img = (RasterImage)Image.Load(filePath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Prepare output PDF path (one PDF per folder)
                string folderName = Path.GetFileName(folder);
                string outputPdfPath = Path.Combine(outputRoot, folderName + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

                // Save the merged canvas as PDF
                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(outputPdfPath, pdfOptions);
            }
        }
    }
}