using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: program <input1.jpg> [<input2.jpg> ...] <output.pdf>");
            return;
        }

        string outputPdfPath = args[args.Length - 1];
        string[] imagePaths = args.Take(args.Length - 1).ToArray();

        string tempTiffPath = Path.Combine(Path.GetTempPath(), "temp_big.tif");
        if (File.Exists(tempTiffPath))
            File.Delete(tempTiffPath);

        int width = 0, height = 0;
        using (RasterImage firstImg = (RasterImage)Image.Load(imagePaths[0]))
        {
            width = firstImg.Width;
            height = firstImg.Height;
        }

        BigTiffOptions bigTiffOptions = new BigTiffOptions(TiffExpectedFormat.Default);
        bigTiffOptions.Source = new FileCreateSource(tempTiffPath, false);

        using (BigTiffImage bigTiff = (BigTiffImage)Image.Create(bigTiffOptions, width, height))
        {
            foreach (string imgPath in imagePaths)
            {
                using (RasterImage raster = (RasterImage)Image.Load(imgPath))
                {
                    if (raster.Width != width || raster.Height != height)
                    {
                        raster.Resize(width, height, ResizeType.NearestNeighbourResample);
                    }
                    bigTiff.AddPage(raster);
                }
            }

            bigTiff.Save();
        }

        using (Image bigTiffImg = Image.Load(tempTiffPath))
        {
            PdfOptions pdfOptions = new PdfOptions();
            bigTiffImg.Save(outputPdfPath, pdfOptions);
        }

        if (File.Exists(tempTiffPath))
            File.Delete(tempTiffPath);
    }
}