using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cmx";
        string outputPath = "output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                int width = cmx.Width;
                int height = cmx.Height;

                var jpegOptions = new JpegOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = width,
                        PageHeight = height
                    }
                };

                cmx.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}