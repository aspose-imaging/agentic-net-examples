using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "sample.djvu";
            string bmpOutputDir = "bmp_pages";
            string pdfOutputPath = "combined.pdf";

            // Validate input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(bmpOutputDir);
            Directory.CreateDirectory(Path.GetDirectoryName(pdfOutputPath));

            // Load DjVu document
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Save pages 4‑6 as BMP (zero‑based indexes 3,4,5)
                for (int i = 3; i <= 5 && i < djvuImage.Pages.Length; i++)
                {
                    string bmpPath = Path.Combine(bmpOutputDir, $"page{i + 1}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));
                    djvuImage.Pages[i].Save(bmpPath, new BmpOptions());
                }
            }

            // Collect BMP sizes
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            List<string> bmpPaths = new List<string>();
            foreach (string file in Directory.GetFiles(bmpOutputDir, "*.bmp"))
            {
                bmpPaths.Add(file);
                using (RasterImage img = (RasterImage)Image.Load(file))
                {
                    sizes.Add(img.Size);
                }
            }

            if (sizes.Count == 0)
            {
                Console.Error.WriteLine("No BMP pages were generated.");
                return;
            }

            // Calculate canvas size (vertical stacking)
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (var sz in sizes)
            {
                if (sz.Width > canvasWidth) canvasWidth = sz.Width;
                canvasHeight += sz.Height;
            }

            // Temporary JPEG canvas (required for PDF saving)
            string tempJpegPath = Path.Combine(Path.GetTempPath(), "temp_canvas.jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(tempJpegPath));
            Source tempSource = new FileCreateSource(tempJpegPath, true);
            JpegOptions jpegOptions = new JpegOptions() { Source = tempSource, Quality = 100 };

            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string bmpPath in bmpPaths)
                {
                    using (RasterImage bmp = (RasterImage)Image.Load(bmpPath))
                    {
                        Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(0, offsetY, bmp.Width, bmp.Height);
                        canvas.SaveArgb32Pixels(bounds, bmp.LoadArgb32Pixels(bmp.Bounds));
                        offsetY += bmp.Height;
                    }
                }

                // Save combined PDF
                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(pdfOutputPath, pdfOptions);
            }

            // Cleanup temporary JPEG file
            if (File.Exists(tempJpegPath))
            {
                try { File.Delete(tempJpegPath); } catch { }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}