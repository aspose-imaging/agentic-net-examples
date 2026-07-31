using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
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
            // Define input and output directories (hardcoded literals)
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all JPEG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.jpg");

            if (files.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // Validate each input file exists
            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }
            }

            // Collect sizes of all images
            List<Size> sizes = new List<Size>();
            foreach (string filePath in files)
            {
                using (RasterImage img = (RasterImage)Image.Load(filePath))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            // Prepare temporary JPEG canvas source
            string tempJpegPath = Path.Combine(outputDirectory, "merged.jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(tempJpegPath));
            Source tempSource = new FileCreateSource(tempJpegPath, false);

            // Configure JPEG options with 300 DPI
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = tempSource,
                Quality = 100,
                ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                ResolutionUnit = ResolutionUnit.Inch
            };

            // Create the canvas image
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (string filePath in files)
                {
                    using (RasterImage img = (RasterImage)Image.Load(filePath))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the merged image
                canvas.Save();
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
 * 1. When a developer needs to combine multiple JPEG product photos into a single high‑resolution PDF catalog page with a 300 DPI setting for professional printing.
 * 2. When creating side‑by‑side comparison sheets of before‑and‑after images, merging the JPEGs horizontally and exporting a 300 DPI PDF for clear visual analysis.
 * 3. When generating a printable invoice that includes scanned JPEG receipts stitched together, ensuring the final PDF meets 300 DPI quality standards for audit compliance.
 * 4. When assembling a large‑format poster from several high‑resolution JPEG sections, merging them horizontally and saving as a 300 DPI PDF for accurate print scaling.
 * 5. When preparing a legal evidence document that requires multiple JPEG photographs to be merged into a single PDF with 300 DPI to satisfy court‑mandated image quality requirements.
 */