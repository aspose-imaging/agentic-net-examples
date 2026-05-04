using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.otg";
            string outputPath = "Output\\sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                using (JpegOptions jpegOptions = new JpegOptions())
                {
                    jpegOptions.HorizontalSampling = new byte[] { 2, 1, 1 };
                    jpegOptions.VerticalSampling = new byte[] { 2, 1, 1 };
                    jpegOptions.ColorType = JpegCompressionColorMode.YCbCr;

                    VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };
                    jpegOptions.VectorRasterizationOptions = vectorOptions;

                    image.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}