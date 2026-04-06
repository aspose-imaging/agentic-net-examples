using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Pdf;
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
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPG files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        string[] jpgFiles = Directory.GetFiles(inputDirectory, "*.jpg")
            .Concat(Directory.GetFiles(inputDirectory, "*.jpeg"))
            .ToArray();

        if (jpgFiles.Length == 0)
        {
            Console.WriteLine("No JPG files found in input directory.");
            return;
        }

        // Load first image to determine canvas size
        string firstPath = jpgFiles[0];
        if (!File.Exists(firstPath))
        {
            Console.Error.WriteLine($"File not found: {firstPath}");
            return;
        }

        using (Image firstImg = Image.Load(firstPath))
        {
            int width = firstImg.Width;
            int height = firstImg.Height;

            using (var dicomOptions = new DicomOptions())
            {
                using (DicomImage dicomImage = (DicomImage)Image.Create(dicomOptions, width, height))
                {
                    // Set pixels for the first page
                    using (Image srcImg = Image.Load(firstPath))
                    {
                        var raster = (RasterImage)srcImg;
                        if (raster.Width != width || raster.Height != height)
                        {
                            raster.Resize(width, height, ResizeType.NearestNeighbourResample);
                        }
                        int[] srcPixels = raster.LoadArgb32Pixels(raster.Bounds);
                        dicomImage.SaveArgb32Pixels(dicomImage.Bounds, srcPixels);
                    }

                    // Add remaining images as pages
                    for (int i = 1; i < jpgFiles.Length; i++)
                    {
                        string imgPath = jpgFiles[i];
                        if (!File.Exists(imgPath))
                        {
                            Console.Error.WriteLine($"File not found: {imgPath}");
                            return;
                        }

                        using (Image srcImg = Image.Load(imgPath))
                        {
                            var raster = (RasterImage)srcImg;
                            if (raster.Width != width || raster.Height != height)
                            {
                                raster.Resize(width, height, ResizeType.NearestNeighbourResample);
                            }
                            int[] srcPixels = raster.LoadArgb32Pixels(raster.Bounds);
                            DicomPage page = dicomImage.AddPage();
                            page.SaveArgb32Pixels(page.Bounds, srcPixels);
                        }
                    }

                    // Save combined document as PDF
                    string outputPdfPath = Path.Combine(outputDirectory, "Combined.pdf");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));
                    using (var pdfOptions = new PdfOptions())
                    {
                        dicomImage.Save(outputPdfPath, pdfOptions);
                    }
                }
            }
        }
    }
}