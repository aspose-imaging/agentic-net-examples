using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the metafile
        using (Image image = Image.Load(inputPath))
        {
            // Access font information if the image is a MetaImage
            MetaImage meta = image as MetaImage;
            if (meta != null)
            {
                string[] usedFonts = meta.GetUsedFonts();
                Console.WriteLine("Used fonts:");
                foreach (string font in usedFonts)
                {
                    Console.WriteLine(font);
                }

                string[] missedFonts = meta.GetMissedFonts();
                Console.WriteLine("Missed fonts:");
                foreach (string font in missedFonts)
                {
                    Console.WriteLine(font);
                }
            }

            // Convert the metafile to PNG format
            PngOptions pngOptions = new PngOptions();
            image.Save(outputPath, pngOptions);
        }
    }
}