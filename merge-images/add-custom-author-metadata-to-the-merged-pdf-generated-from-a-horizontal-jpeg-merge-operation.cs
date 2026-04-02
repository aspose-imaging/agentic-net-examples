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
        // Define input and output directories relative to the current directory
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

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

        // Get all files from the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.*");

        // Collect sizes of all input images
        List<Size> sizeList = new List<Size>();
        foreach (string filePath in files)
        {
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"File not found: {filePath}");
                return;
            }

            using (RasterImage img = (RasterImage)Image.Load(filePath))
            {
                sizeList.Add(img.Size);
            }
        }

        if (sizeList.Count == 0)
        {
            Console.WriteLine("No images found in the input directory.");
            return;
        }

        // Calculate canvas dimensions for horizontal merge
        int newWidth = 0;
        int newHeight = 0;
        foreach (Size sz in sizeList)
        {
            newWidth += sz.Width;
            if (sz.Height > newHeight) newHeight = sz.Height;
        }

        // Prepare output PDF path
        string outputPdfPath = Path.Combine(outputDirectory, "Merged.pdf");
        Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

        // Temporary JPEG canvas file (bound source)
        string tempJpegPath = Path.Combine(outputDirectory, "temp_canvas.jpg");
        Directory.CreateDirectory(Path.GetDirectoryName(tempJpegPath));
        Source tempSource = new FileCreateSource(tempJpegPath, false);
        JpegOptions jpegOptions = new JpegOptions() { Source = tempSource, Quality = 100 };

        // Create JPEG canvas
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
        {
            // Merge images horizontally onto the canvas
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

            // Save the bound JPEG canvas (writes temp JPEG file)
            canvas.Save();

            // Prepare PDF options with custom author metadata
            PdfOptions pdfOptions = new PdfOptions();
            pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
            pdfOptions.PdfDocumentInfo.Author = "Custom Author";

            // Save the canvas as PDF with metadata
            canvas.Save(outputPdfPath, pdfOptions);
        }

        // Cleanup temporary JPEG canvas file
        if (File.Exists(tempJpegPath))
        {
            File.Delete(tempJpegPath);
        }

        Console.WriteLine($"Merged PDF created at: {outputPdfPath}");
    }
}