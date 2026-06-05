using System;
using System.IO;
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
            string inputPath = "input.jpg";
            string outputPath = "output.pdf";
            string tempJpegPath = "temp_thumbnail.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempJpegPath));

            int thumbWidth = 150;
            int thumbHeight = 150;

            using (Aspose.Imaging.RasterImage src = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                src.Resize(thumbWidth, thumbHeight);

                FileCreateSource source = new FileCreateSource(tempJpegPath, false);
                JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 90 };

                using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, src.Width, src.Height))
                {
                    canvas.SaveArgb32Pixels(new Aspose.Imaging.Rectangle(0, 0, src.Width, src.Height), src.LoadArgb32Pixels(src.Bounds));
                    canvas.Save();
                }
            }

            using (Aspose.Imaging.Image pdfImage = Aspose.Imaging.Image.Load(tempJpegPath))
            {
                pdfImage.Save(outputPath, new PdfOptions());
            }

            if (File.Exists(tempJpegPath))
            {
                File.Delete(tempJpegPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}