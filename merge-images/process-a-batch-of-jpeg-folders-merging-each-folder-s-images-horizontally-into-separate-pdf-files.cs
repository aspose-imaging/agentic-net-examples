// HOW-TO: Merge JPEG Images Horizontally from Multiple Folders into PDFs using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputRoot = "InputFolders";
            string outputRoot = "OutputPdfs";

            string[] folders = Directory.GetDirectories(inputRoot);
            foreach (string folder in folders)
            {
                string[] jpgFiles = Directory.GetFiles(folder, "*.jpg");
                string[] jpegFiles = Directory.GetFiles(folder, "*.jpeg");
                string[] imageFiles = jpgFiles.Concat(jpegFiles).ToArray();

                if (imageFiles.Length == 0)
                    continue;

                List<Size> sizes = new List<Size>();
                List<string> validFiles = new List<string>();

                foreach (string file in imageFiles)
                {
                    if (!File.Exists(file))
                    {
                        Console.Error.WriteLine($"File not found: {file}");
                        continue;
                    }

                    using (RasterImage img = (RasterImage)Image.Load(file))
                    {
                        sizes.Add(img.Size);
                        validFiles.Add(file);
                    }
                }

                if (sizes.Count == 0)
                    continue;

                int newWidth = sizes.Sum(s => s.Width);
                int newHeight = sizes.Max(s => s.Height);

                JpegOptions canvasOptions = new JpegOptions();
                using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, newWidth, newHeight))
                {
                    int offsetX = 0;
                    foreach (string file in validFiles)
                    {
                        using (RasterImage img = (RasterImage)Image.Load(file))
                        {
                            Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                            canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                            offsetX += img.Width;
                        }
                    }

                    string folderName = Path.GetFileName(folder);
                    string outputPath = Path.Combine(outputRoot, folderName + ".pdf");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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

/*
 * Real-World Use Cases:
 * 1. When you need to combine all photos in each client’s folder into a single wide‑format PDF for easy review.
 * 2. When automating the creation of printable catalogs where each product’s images are stored in separate directories.
 * 3. When generating batch reports that require merging scanned JPEG receipts from different days into one PDF per day.
 * 4. When preparing slide‑show handouts by stitching together event photos from each venue folder into a single PDF file.
 * 5. When consolidating image assets for a marketing campaign, turning each folder of JPEGs into a horizontally merged PDF for quick sharing.
 */
