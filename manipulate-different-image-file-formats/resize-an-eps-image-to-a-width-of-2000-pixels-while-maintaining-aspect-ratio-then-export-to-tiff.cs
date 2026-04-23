using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.eps";
            string outputPath = "output/output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                int newWidth = 2000;
                int newHeight = (int)Math.Round((double)originalHeight * newWidth / originalWidth);

                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);
                image.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}