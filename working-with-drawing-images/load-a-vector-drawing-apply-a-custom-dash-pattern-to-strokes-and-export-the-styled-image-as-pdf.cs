using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/vector.svg";
        string outputPath = "Output/styled.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image vectorImage = Image.Load(inputPath))
        {
            int width = vectorImage.Width;
            int height = vectorImage.Height;

            BmpOptions bmpOptions = new BmpOptions();
            using (Image rasterImage = Image.Create(bmpOptions, width, height))
            {
                // Create graphics for drawing
                Graphics graphics = new Graphics(rasterImage);
                graphics.Clear(Color.White);

                // Define a pen with custom dash pattern
                Pen dashPen = new Pen(Color.Black, 2);
                dashPen.DashStyle = DashStyle.Custom;
                dashPen.DashPattern = new float[] { 5f, 3f };

                // Draw the vector image bounds with the custom dash pattern
                graphics.DrawRectangle(dashPen, new Rectangle(0, 0, width, height));

                // Export the styled raster image as PDF
                PdfOptions pdfOptions = new PdfOptions();
                rasterImage.Save(outputPath, pdfOptions);
            }
        }
    }
}