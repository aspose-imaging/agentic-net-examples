using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jp2";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Jpeg2000Image jpeg2000 = new Jpeg2000Image(inputPath))
            {
                int newWidth = jpeg2000.Width / 2;
                int newHeight = jpeg2000.Height / 2;

                jpeg2000.Resize(newWidth, newHeight);

                PngOptions pngOptions = new PngOptions();

                jpeg2000.Save(outputPath, pngOptions);
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
 * 1. When a web application needs to serve high‑resolution satellite JPEG2000 imagery as smaller, progressive PNG files for faster page loads on mobile browsers.
 * 2. When an archival system converts large medical JPEG2000 scans into half‑size interlaced PNGs to reduce storage while preserving visual quality for remote diagnosis.
 * 3. When a digital publishing workflow downsamples high‑definition JPEG2000 artwork to PNG with interlacing to enable progressive rendering in e‑books and online magazines.
 * 4. When a GIS tool prepares thumbnail previews of JPEG2000 map tiles by resizing them to 50 % and saving as interlaced PNG for quick preview in mapping applications.
 * 5. When an automated batch process migrates legacy JPEG2000 product photos to web‑friendly PNG format, applying half‑size scaling and interlaced encoding to improve SEO and user experience.
 */