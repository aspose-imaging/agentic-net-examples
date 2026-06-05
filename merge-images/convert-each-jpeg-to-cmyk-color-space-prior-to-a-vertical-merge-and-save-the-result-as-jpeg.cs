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
            // Define input and output directories (relative paths)
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure input and output directories exist
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all JPEG files in the input directory
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpg")
                .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
                .ToArray();

            if (jpegFiles.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // Verify each input file exists
            foreach (string filePath in jpegFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }
            }

            // Collect sizes of all images
            List<Size> imageSizes = new List<Size>();
            foreach (string filePath in jpegFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(filePath))
                {
                    imageSizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for vertical merge
            int canvasWidth = imageSizes.Max(s => s.Width);
            int canvasHeight = imageSizes.Sum(s => s.Height);

            // Define output file path
            string outputPath = Path.Combine(outputDirectory, "merged_cmyk.jpg");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare JPEG options for CMYK output
            Source fileSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = fileSource,
                Quality = 100,
                ColorType = JpegCompressionColorMode.Cmyk
                // Note: Custom ICC profiles can be set via RgbColorProfile and CmykColorProfile if needed
            };

            // Create a bound JPEG canvas
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                // Draw each image onto the canvas vertically
                foreach (string filePath in jpegFiles)
                {
                    using (RasterImage src = (RasterImage)Image.Load(filePath))
                    {
                        Rectangle destRect = new Rectangle(0, offsetY, src.Width, src.Height);
                        canvas.SaveArgb32Pixels(destRect, src.LoadArgb32Pixels(src.Bounds));
                        offsetY += src.Height;
                    }
                }

                // Save the bound image (no need to pass path again)
                canvas.Save();
            }

            Console.WriteLine($"Merged CMYK JPEG saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When preparing print‑ready brochures, a developer can use this code to convert individual JPEG images to CMYK, stack them vertically, and output a single JPEG that matches the printer’s color profile.
 * 2. When generating a continuous product catalog page from separate photo shots, the code ensures each JPEG is in CMYK color space before merging them vertically, preserving color consistency for offset printing.
 * 3. When automating the creation of vertical banner ads from multiple JPEG assets, the developer can convert each image to CMYK and combine them into one JPEG to meet the advertising platform’s color requirements.
 * 4. When consolidating scanned receipts or invoices into a single printable PDF page, the code first converts each JPEG to CMYK and then merges them vertically, guaranteeing accurate color reproduction in the final document.
 * 5. When building a batch workflow for a publishing house that needs to combine chapter header images into a single JPEG for e‑book layouts, the code converts each source JPEG to CMYK and stacks them vertically to maintain consistent color across devices.
 */