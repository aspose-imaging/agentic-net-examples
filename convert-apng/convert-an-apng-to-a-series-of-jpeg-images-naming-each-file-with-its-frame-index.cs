using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/animation.apng";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDirectory = "Output";

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                int frameCount = apng.PageCount;
                for (int i = 0; i < frameCount; i++)
                {
                    var frame = apng.Pages[i];
                    using (RasterImage raster = (RasterImage)frame)
                    {
                        string outputPath = Path.Combine(outputDirectory, $"frame_{i}.jpg");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        JpegOptions jpegOptions = new JpegOptions();
                        raster.Save(outputPath, jpegOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}