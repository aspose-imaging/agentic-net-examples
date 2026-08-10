// HOW-TO: Combine Multiple JPEG Images Horizontally and Save as PDF in C# (Aspose.Imaging for .NET)
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
            // Define input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Define output PDF path
            string outputPath = Path.Combine(outputDirectory, "merged.pdf");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Get JPEG files from input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.jpg");
            if (files.Length == 0)
            {
                Console.Error.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // Validate each input file exists and collect sizes
            List<Size> sizes = new List<Size>();
            List<string> validFiles = new List<string>();
            foreach (string file in files)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }
                using (RasterImage img = (RasterImage)Image.Load(file))
                {
                    sizes.Add(img.Size);
                }
                validFiles.Add(file);
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Temporary file for the intermediate JPEG canvas
            string tempCanvasPath = Path.Combine(outputDirectory, "temp_canvas.jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(tempCanvasPath));

            // Create JPEG canvas bound to temporary file
            Source tempSource = new FileCreateSource(tempCanvasPath, true);
            JpegOptions jpegOptions = new JpegOptions() { Source = tempSource, Quality = 100 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (string imgPath in validFiles)
                {
                    using (RasterImage img = (RasterImage)Image.Load(imgPath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the canvas (writes to temporary JPEG file)
                canvas.Save();

                // Export the canvas as PDF
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

/*
 * Real-World Use Cases:
 * 1. When you need to create a single PDF catalog page that shows product photos side‑by‑side from a folder of JPEG files.
 * 2. When you want to generate a printable proof sheet that merges scanned JPEG pages into one horizontal layout before archiving as PDF.
 * 3. When an application must batch‑process user‑uploaded JPEG screenshots and combine them into a single PDF for easy sharing.
 * 4. When you are building a reporting tool that stitches together chart images horizontally and exports the result as a PDF document.
 * 5. When you need to automate the creation of a PDF brochure by concatenating multiple JPEG advertisements in a single row.
 */
