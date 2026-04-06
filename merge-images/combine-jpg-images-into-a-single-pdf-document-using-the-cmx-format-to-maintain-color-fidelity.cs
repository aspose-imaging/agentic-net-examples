using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPG files
        string[] inputPaths = { "image1.jpg", "image2.jpg", "image3.jpg" };
        // Hardcoded CMX canvas file (used for dimensions)
        string cmxPath = "canvas.cmx";
        // Hardcoded output PDF file
        string outputPath = "output.pdf";

        // Validate input JPG files
        foreach (var path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Validate CMX canvas file
        if (!File.Exists(cmxPath))
        {
            Console.Error.WriteLine($"File not found: {cmxPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load CMX canvas to obtain dimensions
        using (CmxImage cmx = (CmxImage)Image.Load(cmxPath))
        {
            int canvasWidth = cmx.Width;
            int canvasHeight = cmx.Height;

            // Create a raster canvas with the same dimensions
            JpegOptions canvasOptions = new JpegOptions();
            using (Image canvas = Image.Create(canvasOptions, canvasWidth, canvasHeight))
            {
                // Use Graphics to draw each JPG onto the canvas
                Graphics graphics = new Graphics(canvas);
                int offsetY = 0;

                foreach (var imgPath in inputPaths)
                {
                    using (Image img = Image.Load(imgPath))
                    {
                        graphics.DrawImage(img, 0, offsetY);
                        offsetY += img.Height;
                    }
                }

                // Save the combined canvas as a single PDF document
                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(outputPath, pdfOptions);
            }
        }
    }
}