using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\animation.apng";
            string outputPath = "Output\\animation.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                int width = apng.Width;
                int height = apng.Height;

                using (GifOptions gifOptions = new GifOptions())
                {
                    gifOptions.Source = new FileCreateSource(outputPath, false);

                    using (GifImage gif = (GifImage)Image.Create(gifOptions, width, height))
                    {
                        foreach (var page in apng.Pages)
                        {
                            gif.AddPage((RasterImage)page);
                        }

                        gif.Save();
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