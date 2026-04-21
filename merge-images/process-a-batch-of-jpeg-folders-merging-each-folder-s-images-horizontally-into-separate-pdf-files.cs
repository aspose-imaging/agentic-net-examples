using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputRoot = "Input";
            string outputRoot = "Output";

            // Ensure input and output directories exist
            if (!Directory.Exists(inputRoot))
            {
                Directory.CreateDirectory(inputRoot);
                Console.WriteLine($"Input directory created at: {inputRoot}. Add folders with JPEG images and rerun.");
                return;
            }
            if (!Directory.Exists(outputRoot))
            {
                Directory.CreateDirectory(outputRoot);
            }

            // Process each subfolder
            foreach (string folderPath in Directory.GetDirectories(inputRoot))
            {
                string folderName = Path.GetFileName(folderPath);
                string[] allFiles = Directory.GetFiles(folderPath);
                List<string> jpegFiles = new List<string>();
                foreach (string f in allFiles)
                {
                    string ext = Path.GetExtension(f).ToLowerInvariant();
                    if (ext == ".jpg" || ext == ".jpeg")
                    {
                        jpegFiles.Add(f);
                    }
                }

                if (jpegFiles.Count == 0)
                {
                    continue; // No JPEGs in this folder
                }

                // Collect sizes
                List<Size> sizes = new List<Size>();
                foreach (string imgPath in jpegFiles)
                {
                    if (!File.Exists(imgPath))
                    {
                        Console.Error.WriteLine($"File not found: {imgPath}");
                        return;
                    }
                    using (RasterImage img = (RasterImage)Image.Load(imgPath))
                    {
                        sizes.Add(img.Size);
                    }
                }

                // Calculate canvas dimensions (horizontal merge)
                int totalWidth = 0;
                int maxHeight = 0;
                foreach (Size sz in sizes)
                {
                    totalWidth += sz.Width;
                    if (sz.Height > maxHeight) maxHeight = sz.Height;
                }

                // Create canvas
                using (RasterImage canvas = (RasterImage)Image.Create(new JpegOptions(), totalWidth, maxHeight))
                {
                    int offsetX = 0;
                    foreach (string imgPath in jpegFiles)
                    {
                        using (RasterImage img = (RasterImage)Image.Load(imgPath))
                        {
                            Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                            canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                            offsetX += img.Width;
                        }
                    }

                    // Prepare output PDF path
                    string outputPath = Path.Combine(outputRoot, folderName + ".pdf");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save canvas as PDF
                    PdfOptions pdfOptions = new PdfOptions();
                    canvas.Save(outputPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}