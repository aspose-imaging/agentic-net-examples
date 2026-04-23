using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.bigtiff";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image srcImage = Image.Load(inputPath))
            {
                TiffImage srcTiff = (TiffImage)srcImage;

                BigTiffOptions options = new BigTiffOptions(TiffExpectedFormat.Default);
                options.Source = new FileCreateSource(outputPath, false);

                using (BigTiffImage bigTiff = (BigTiffImage)Image.Create(options, srcTiff.Width, srcTiff.Height))
                {
                    bigTiff.RemoveFrame(0);

                    foreach (TiffFrame frame in srcTiff.Frames)
                    {
                        bigTiff.AddFrame(TiffFrame.CopyFrame(frame));
                    }

                    bigTiff.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}