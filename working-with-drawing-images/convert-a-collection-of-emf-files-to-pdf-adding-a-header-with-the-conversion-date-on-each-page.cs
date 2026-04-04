using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine("Input", "sample.emf");
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputPath = Path.Combine("Output", "sample.pdf");
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            EmfImage emfImage = (EmfImage)image;
            EmfRecorderGraphics2D graphics = EmfRecorderGraphics2D.FromEmfImage(emfImage);

            string headerText = $"Converted on {DateTime.Now:yyyy-MM-dd}";
            graphics.DrawString(headerText, new Font("Arial", 24), Aspose.Imaging.Color.Black, 10, 10);

            using (EmfImage annotatedEmf = graphics.EndRecording())
            {
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = annotatedEmf.Width,
                    PageHeight = annotatedEmf.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                annotatedEmf.Save(outputPath, pdfOptions);
            }
        }
    }
}