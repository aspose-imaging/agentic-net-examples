using System;
using System.IO;
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
            // Define input and output directories
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

            // Get JPEG files from input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.jpg");
            string[] jpegFiles = Directory.GetFiles(inputDirectory, "*.jpeg");
            List<string> allFiles = new List<string>();
            allFiles.AddRange(files);
            allFiles.AddRange(jpegFiles);

            if (allFiles.Count == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // Collect sizes of all images
            List<Size> sizes = new List<Size>();
            foreach (string path in allFiles)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }

                using (RasterImage img = (RasterImage)Image.Load(path))
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

            // Prepare temporary source for canvas creation
            string tempCanvasPath = Path.Combine(outputDirectory, "tempCanvas.jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(tempCanvasPath));
            Source canvasSource = new FileCreateSource(tempCanvasPath, false);

            // Configure JPEG options with 300 DPI
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = canvasSource,
                Quality = 100,
                ResolutionSettings = new ResolutionSetting(300.0, 300.0),
                ResolutionUnit = ResolutionUnit.Inch
            };

            // Create JPEG canvas
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                // Merge images horizontally
                int offsetX = 0;
                foreach (string path in allFiles)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Ensure output PDF directory exists
                string outputPdfPath = Path.Combine(outputDirectory, "merged.pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

                // Save canvas as PDF
                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(outputPdfPath, pdfOptions);
            }

            // Cleanup temporary canvas file
            if (File.Exists(tempCanvasPath))
            {
                File.Delete(tempCanvasPath);
            }

            Console.WriteLine("Merging completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}