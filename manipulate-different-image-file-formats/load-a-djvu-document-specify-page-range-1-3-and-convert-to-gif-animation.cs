// HOW-TO: Convert DjVu Pages 1 To 3 Into Animated GIF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

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

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                GifOptions gifOptions = new GifOptions();
                gifOptions.MultiPageOptions = new DjvuMultiPageOptions(new IntRange(1, 3));
                djvu.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract the first three pages of a DjVu e‑book and create a lightweight animated GIF for preview on a website.
 * 2. When you want to generate a short looping animation from selected DjVu pages to embed in a mobile app tutorial.
 * 3. When you must convert a multi‑page DjVu technical manual into a GIF that can be displayed in email clients that only support GIF images.
 * 4. When you are building a document‑conversion service that offers users the ability to download the first few pages of a DjVu file as an animated GIF.
 * 5. When you need to automate batch processing of DjVu files to produce GIF animations of specific page ranges for archival or sharing purposes.
 */
