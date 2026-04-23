using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                DjvuImage djvu = (DjvuImage)image;
                var frames = new List<Image>();

                foreach (Image pageImg in djvu.Pages)
                {
                    DjvuPage page = (DjvuPage)pageImg;
                    page.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);
                    frames.Add(page);
                }

                using (Image gif = Image.Create(frames.ToArray(), true))
                {
                    gif.Save(outputPath, new GifOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}