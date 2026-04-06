using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.dcm";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
        {
            int width = rasterImage.Width;
            int height = rasterImage.Height;

            int[] pixels = rasterImage.LoadArgb32Pixels(rasterImage.Bounds);

            var dicomOptions = new DicomOptions
            {
                ColorType = ColorType.Rgb24Bit
            };

            using (DicomImage dicomImage = new DicomImage(dicomOptions, width, height))
            {
                dicomImage.SaveArgb32Pixels(dicomImage.Bounds, pixels);
                dicomImage.Save(outputPath, dicomOptions);
            }
        }
    }
}