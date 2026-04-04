using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = Path.Combine("Input", "sample.svg");
        string outputPath = Path.Combine("Output", "styled.pdf");

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the vector image
        using (Image image = Image.Load(inputPath))
        {
            // Verify that the loaded image is a vector image
            if (image is VectorImage)
            {
                // Prepare PDF export options
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    // Configure vector rasterization options (background and page size)
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };

                    // Create a PDF canvas with the same dimensions as the source image
                    using (Image pdfCanvas = Image.Create(pdfOptions, image.Width, image.Height))
                    {
                        // Create a Graphics object for drawing
                        Graphics graphics = new Graphics(pdfCanvas);

                        // Define a pen with a custom dash pattern
                        Pen dashPen = new Pen(Color.Black, 2);
                        dashPen.DashPattern = new float[] { 5f, 3f }; // 5px dash, 3px gap

                        // Draw a rectangle around the image bounds using the dashed pen
                        graphics.DrawRectangle(dashPen, new Rectangle(0, 0, image.Width, image.Height));

                        // Optionally, draw the original vector image onto the canvas
                        // (DrawImage does not accept a Pen, so we simply render the image)
                        graphics.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));

                        // Save the styled PDF
                        pdfCanvas.Save(outputPath, pdfOptions);
                    }
                }
            }
            else
            {
                Console.Error.WriteLine("The provided file is not a vector image.");
            }
        }
    }
}