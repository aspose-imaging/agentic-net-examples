using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.png";
            string outputPdfPath = "Output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            using (RasterImage original = (RasterImage)Image.Load(inputPath))
            {
                const int targetSize = 800;
                float scale = Math.Min((float)targetSize / original.Width, (float)targetSize / original.Height);
                int newWidth = (int)(original.Width * scale);
                int newHeight = (int)(original.Height * scale);

                original.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                using (RasterImage canvas = (RasterImage)Image.Create(new PngOptions(), targetSize, targetSize))
                {
                    Graphics g = new Graphics(canvas);
                    g.Clear(Color.Transparent);

                    int offsetX = (targetSize - newWidth) / 2;
                    int offsetY = (targetSize - newHeight) / 2;

                    canvas.SaveArgb32Pixels(
                        new Rectangle(offsetX, offsetY, newWidth, newHeight),
                        original.LoadArgb32Pixels(original.Bounds));

                    PdfOptions pdfOptions = new PdfOptions();
                    canvas.Save(outputPdfPath, pdfOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}