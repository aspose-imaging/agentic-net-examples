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
            // Hardcoded input and output root directories
            string inputRoot = "Input";
            string outputRoot = "Output";

            // Ensure output root exists
            Directory.CreateDirectory(outputRoot);

            // Get all subfolders in the input root
            string[] folders = Directory.GetDirectories(inputRoot);

            foreach (string folder in folders)
            {
                // Get JPEG files in the current folder
                string[] imageFiles = Directory.GetFiles(folder, "*.jpg")
                    .Concat(Directory.GetFiles(folder, "*.jpeg"))
                    .ToArray();

                if (imageFiles.Length == 0)
                    continue; // Skip folders without images

                // Collect sizes of all images
                List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
                foreach (string imgPath in imageFiles)
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

                // Calculate canvas dimensions for horizontal merge
                int canvasWidth = sizes.Sum(s => s.Width);
                int canvasHeight = sizes.Max(s => s.Height);

                // Create an unbound JPEG canvas
                JpegOptions canvasOptions = new JpegOptions();
                using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, canvasWidth, canvasHeight))
                {
                    int offsetX = 0;
                    foreach (string imgPath in imageFiles)
                    {
                        if (!File.Exists(imgPath))
                        {
                            Console.Error.WriteLine($"File not found: {imgPath}");
                            return;
                        }

                        using (RasterImage img = (RasterImage)Image.Load(imgPath))
                        {
                            Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                            canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                            offsetX += img.Width;
                        }
                    }

                    // Prepare PDF output path
                    string relativeFolder = Path.GetFileName(folder);
                    string outputPath = Path.Combine(outputRoot, relativeFolder + ".pdf");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When a developer needs to convert product catalog image folders into single‑page PDF brochures by stitching each folder’s JPEG photos side‑by‑side.
 * 2. When an e‑commerce platform must generate printable order‑summary PDFs that combine all uploaded JPEG receipts from each customer’s folder into a horizontal layout.
 * 3. When a real‑estate agency wants to create PDF floor‑plan sheets that merge multiple room‑view JPEG images stored per property into one wide PDF page.
 * 4. When a medical imaging system requires batch processing of patient scan JPEG directories to produce horizontally merged PDF reports for quick review.
 * 5. When a marketing team automates the creation of PDF mood boards by horizontally merging themed JPEG assets from separate folders into individual PDF files.
 */