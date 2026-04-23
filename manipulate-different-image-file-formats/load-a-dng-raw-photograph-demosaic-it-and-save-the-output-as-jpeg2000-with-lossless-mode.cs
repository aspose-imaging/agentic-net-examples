using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\photo.dng";
        string outputPath = "Output\\photo.jp2";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                var dngImage = (Aspose.Imaging.FileFormats.Dng.DngImage)image;
                dngImage.UseRawData = false; // ensure demosaicing

                Jpeg2000Options saveOptions = new Jpeg2000Options
                {
                    Irreversible = false // lossless compression
                };

                using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(dngImage))
                {
                    jpeg2000Image.Save(outputPath, saveOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}