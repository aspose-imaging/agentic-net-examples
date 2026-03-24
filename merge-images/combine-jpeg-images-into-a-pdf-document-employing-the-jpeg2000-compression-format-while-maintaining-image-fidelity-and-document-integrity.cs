using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPEG files and output PDF path
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg",
            "input3.jpg"
        };
        string outputPath = "output.pdf";

        // Verify input files exist
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Convert each JPEG to a temporary JPEG2000 file
        List<string> jp2Paths = new List<string>();
        int tempIndex = 0;
        foreach (string jpegPath in inputPaths)
        {
            string tempJp2Path = Path.Combine(Path.GetTempPath(), $"temp_{tempIndex}.jp2");
            using (Image jpegImage = Image.Load(jpegPath))
            {
                Jpeg2000Options jp2Options = new Jpeg2000Options
                {
                    Irreversible = true // Use lossless compression
                };
                jpegImage.Save(tempJp2Path, jp2Options);
            }
            jp2Paths.Add(tempJp2Path);
            tempIndex++;
        }

        // Load the first JP2 to determine page size
        using (RasterImage firstImage = (RasterImage)Image.Load(jp2Paths[0]))
        {
            int pageWidth = firstImage.Width;
            int pageHeight = firstImage.Height;

            // Create PDF canvas bound to the output file
            Source pdfSource = new FileCreateSource(outputPath, false);
            PdfOptions pdfOptions = new PdfOptions
            {
                Source = pdfSource
            };
            using (RasterImage pdfCanvas = (RasterImage)Image.Create(pdfOptions, pageWidth, pageHeight))
            {
                Graphics graphics = new Graphics(pdfCanvas);
                int offsetY = 0;

                foreach (string jp2Path in jp2Paths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(jp2Path))
                    {
                        // Draw the JP2 image onto the PDF canvas
                        graphics.DrawImage(img, new Rectangle(0, offsetY, img.Width, img.Height));
                        offsetY += img.Height;
                    }
                }

                // Save the bound PDF document
                pdfCanvas.Save();
            }
        }

        // Cleanup temporary JP2 files
        foreach (string tempPath in jp2Paths)
        {
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
        }
    }
}