using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output root directories
            string inputRoot = "Input";
            string outputRoot = "Output";

            // Ensure output root exists
            Directory.CreateDirectory(outputRoot);

            // Get all subfolders in the input root
            string[] folders = Directory.GetDirectories(inputRoot);

            foreach (string folder in folders)
            {
                // Prepare output PDF path for this folder
                string folderName = Path.GetFileName(folder);
                string outputPath = Path.Combine(outputRoot, folderName + ".pdf");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Get JPEG files in the current folder
                string[] imageFiles = Directory.GetFiles(folder, "*.jpg")
                    .Concat(Directory.GetFiles(folder, "*.jpeg"))
                    .ToArray();

                if (imageFiles.Length == 0)
                {
                    continue; // No images to process
                }

                // Collect sizes of all images
                List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
                foreach (string imgPath in imageFiles)
                {
                    if (!File.Exists(imgPath))
                    {
                        Console.Error.WriteLine($"File not found: {imgPath}");
                        continue;
                    }

                    using (RasterImage img = (RasterImage)Image.Load(imgPath))
                    {
                        sizes.Add(img.Size);
                    }
                }

                if (sizes.Count == 0)
                {
                    continue; // All files missing
                }

                // Calculate canvas dimensions for horizontal merge
                int newWidth = sizes.Sum(s => s.Width);
                int newHeight = sizes.Max(s => s.Height);

                // Create an unbound canvas (no source) using PNG options
                PngOptions canvasOptions = new PngOptions();
                using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, newWidth, newHeight))
                {
                    int offsetX = 0;
                    foreach (string imgPath in imageFiles)
                    {
                        if (!File.Exists(imgPath))
                        {
                            Console.Error.WriteLine($"File not found: {imgPath}");
                            continue;
                        }

                        using (RasterImage img = (RasterImage)Image.Load(imgPath))
                        {
                            Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                            canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                            offsetX += img.Width;
                        }
                    }

                    // Save the merged canvas as PDF
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
 * 1. When a developer needs to generate product catalogs by combining multiple JPEG product photos stored in separate category folders into single PDF brochures for each category using Aspose.Imaging for .NET.
 * 2. When an e‑learning platform must automatically convert sets of lecture slide JPEG images organized by module into horizontally stitched PDF handouts for students.
 * 3. When a real‑estate agency wants to create printable property brochures by merging room‑by‑room JPEG photos from each property folder into one landscape PDF per property.
 * 4. When a marketing team requires batch creation of campaign PDFs by stitching together campaign‑specific JPEG assets from different folders into separate PDF files for distribution.
 * 5. When a document management system needs to archive scanned JPEG pages stored in folder batches as combined PDF documents while preserving the original image dimensions.
 */