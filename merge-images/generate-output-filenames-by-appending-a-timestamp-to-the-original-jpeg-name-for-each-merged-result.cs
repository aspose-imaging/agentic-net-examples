using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.jpg"
        };

        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (RasterImage src = (RasterImage)Image.Load(inputPath))
            {
                string directory = Path.GetDirectoryName(inputPath);
                string nameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string outputPath = Path.Combine(directory, $"{nameWithoutExt}_{timestamp}.jpg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                FileCreateSource outSource = new FileCreateSource(outputPath, false);

                JpegOptions jpegOptions = new JpegOptions
                {
                    Source = outSource,
                    Quality = 90
                };

                using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, src.Width, src.Height))
                {
                    canvas.SaveArgb32Pixels(
                        new Rectangle(0, 0, src.Width, src.Height),
                        src.LoadArgb32Pixels(src.Bounds));

                    canvas.Save();
                }
            }
        }
    }
}