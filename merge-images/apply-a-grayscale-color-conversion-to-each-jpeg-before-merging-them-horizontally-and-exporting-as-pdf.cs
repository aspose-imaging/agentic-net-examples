using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        string[] files = Directory.GetFiles(inputDirectory, "*.jpg");
        if (files.Length == 0)
        {
            Console.WriteLine("No JPEG files found in input directory.");
            return;
        }

        List<Size> sizeList = new List<Size>();
        List<string> grayPaths = new List<string>();

        foreach (string file in files)
        {
            if (!File.Exists(file))
            {
                Console.Error.WriteLine($"File not found: {file}");
                return;
            }

            using (JpegImage jpeg = (JpegImage)Image.Load(file))
            {
                jpeg.Grayscale();

                string grayPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(file) + "_gray.jpg");
                Directory.CreateDirectory(Path.GetDirectoryName(grayPath));
                jpeg.Save(grayPath);

                grayPaths.Add(grayPath);
                sizeList.Add(jpeg.Size);
            }
        }

        int totalWidth = 0;
        int maxHeight = 0;
        foreach (Size sz in sizeList)
        {
            totalWidth += sz.Width;
            if (sz.Height > maxHeight) maxHeight = sz.Height;
        }

        string mergedJpegPath = Path.Combine(outputDirectory, "merged.jpg");
        Directory.CreateDirectory(Path.GetDirectoryName(mergedJpegPath));
        Source source = new FileCreateSource(mergedJpegPath, false);
        JpegOptions jpegOptions = new JpegOptions() { Source = source, Quality = 100 };

        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, totalWidth, maxHeight))
        {
            int offsetX = 0;
            foreach (string grayPath in grayPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(grayPath))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }
            canvas.Save();
        }

        string pdfPath = Path.Combine(outputDirectory, "merged.pdf");
        Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));
        using (Image merged = Image.Load(mergedJpegPath))
        {
            merged.Save(pdfPath, new PdfOptions());
        }

        Console.WriteLine("Processing completed.");
    }
}