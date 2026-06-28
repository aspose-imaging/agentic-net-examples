using System;
using System.IO;
using System.Collections.Generic;
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
            // Hardcoded input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Define input JPEG files (modify names as needed)
            string[] inputFiles = new string[]
            {
                Path.Combine(inputDirectory, "img1.jpg"),
                Path.Combine(inputDirectory, "img2.jpg"),
                Path.Combine(inputDirectory, "img3.jpg")
            };

            // Define output PDF path
            string outputPath = Path.Combine(outputDirectory, "merged.pdf");

            // Validate each input file
            foreach (string file in inputFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect image sizes
            List<Size> sizes = new List<Size>();
            foreach (string file in inputFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(file))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = 0;
            int newHeight = 0;
            foreach (Size sz in sizes)
            {
                newWidth += sz.Width;
                if (sz.Height > newHeight) newHeight = sz.Height;
            }

            // Create temporary JPEG canvas (bound image)
            string tempJpegPath = Path.Combine(outputDirectory, "temp.jpg");
            Source jpegSource = new FileCreateSource(tempJpegPath, false);
            JpegOptions jpegOptions = new JpegOptions { Source = jpegSource, Quality = 100 };
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                // Merge images horizontally onto the canvas
                int offsetX = 0;
                foreach (string file in inputFiles)
                {
                    using (RasterImage img = (RasterImage)Image.Load(file))
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
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a printable product catalog by horizontally merging JPEG product photos into a single PDF using C# image processing.
 * 2. When an e‑learning application must combine scanned lecture slide JPEGs side‑by‑side and export the result as a PDF handout.
 * 3. When a real‑estate portal wants to create a PDF floor‑plan overview by aligning room‑by‑room JPEG images horizontally.
 * 4. When a medical imaging system requires stitching sequential X‑ray JPEG images into one wide image and saving it as a PDF report.
 * 5. When a marketing automation script assembles multiple campaign banner JPEGs into a single horizontal PDF for client review.
 */