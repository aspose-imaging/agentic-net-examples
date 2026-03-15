using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\multipage.tif";
        string outputFolder = @"C:\Images\Frames";
        string outputExtension = ".png";

        Directory.CreateDirectory(outputFolder);

        using (TiffImage tiff = (TiffImage)Aspose.Imaging.Image.Load(inputPath))
        {
            for (int i = 0; i < tiff.Frames.Length; i++)
            {
                TiffFrame frame = tiff.Frames[i];
                string outputPath = Path.Combine(outputFolder, $"frame_{i + 1}{outputExtension}");

                if (outputExtension.Equals(".png", StringComparison.OrdinalIgnoreCase))
                {
                    frame.Save(outputPath, new PngOptions());
                }
                else if (outputExtension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                         outputExtension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    frame.Save(outputPath, new JpegOptions());
                }
                else if (outputExtension.Equals(".bmp", StringComparison.OrdinalIgnoreCase))
                {
                    frame.Save(outputPath, new BmpOptions());
                }
                else if (outputExtension.Equals(".tif", StringComparison.OrdinalIgnoreCase) ||
                         outputExtension.Equals(".tiff", StringComparison.OrdinalIgnoreCase))
                {
                    frame.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
                }
                else
                {
                    frame.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}