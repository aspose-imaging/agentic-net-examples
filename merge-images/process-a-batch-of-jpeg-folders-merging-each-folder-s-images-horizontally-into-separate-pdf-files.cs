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
        // Hardcoded input and output directories
        string inputRoot = "Input";
        string outputRoot = "Output";

        // Ensure output directory exists
        Directory.CreateDirectory(outputRoot);

        // Get all subfolders in the input directory
        string[] folders = Directory.GetDirectories(inputRoot);

        foreach (string folder in folders)
        {
            // Name of the folder will be used for the output PDF file
            string folderName = Path.GetFileName(folder);
            // Get all JPEG files in the current folder
            string[] imageFiles = Directory.GetFiles(folder, "*.*")
                                           .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                                       f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                                           .ToArray();

            if (imageFiles.Length == 0)
                continue; // No images to process

            // Collect widths and heights of all images
            List<int> widths = new List<int>();
            List<int> heights = new List<int>();

            foreach (string imgPath in imageFiles)
            {
                if (!File.Exists(imgPath))
                {
                    Console.Error.WriteLine($"File not found: {imgPath}");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(imgPath))
                {
                    widths.Add(img.Width);
                    heights.Add(img.Height);
                }
            }

            int totalWidth = widths.Sum();
            int maxHeight = heights.Max();

            // Temporary JPEG canvas file (required for Image.Create)
            string tempCanvasPath = Path.Combine(outputRoot, $"{folderName}_temp.jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(tempCanvasPath));

            // Create JPEG canvas
            Source tempSource = new FileCreateSource(tempCanvasPath, false);
            JpegOptions jpegOptions = new JpegOptions() { Source = tempSource, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
            {
                int offsetX = 0;
                foreach (string imgPath in imageFiles)
                {
                    using (RasterImage img = (RasterImage)Image.Load(imgPath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the merged canvas as PDF
                string pdfPath = Path.Combine(outputRoot, $"{folderName}.pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));
                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(pdfPath, pdfOptions);
            }

            // Optionally delete the temporary JPEG canvas file
            // File.Delete(tempCanvasPath);
        }
    }
}